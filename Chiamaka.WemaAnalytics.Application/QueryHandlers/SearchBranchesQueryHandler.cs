using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiamaka.WemaAnalytics.Application.Interfaces;
using Chiamaka.WemaAnalytics.Application.Queries;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using Chiamaka.WemaAnalytics.Domain.Utility;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chiamaka.WemaAnalytics.Application.QueryHandlers
{
    public class SearchBranchesQueryHandler : IRequestHandler<SearchBranchesQuery, PagedResult<Branch>>
    {
        private readonly IWemaDbContext _context;
        public SearchBranchesQueryHandler(IWemaDbContext context)
        {
            _context = context;
        }
        
        public async Task<PagedResult<Branch>> Handle(SearchBranchesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Branches.Where(b => !b.IsDeleted);

            if (!string.IsNullOrWhiteSpace(request.q))
            {
                var q = request.q.ToLower();
                query = query.Where(b => b.Code.ToLower().Contains(q) || b.Name.ToLower().Contains(q) || (b.City != null && b.City.ToLower().Contains(q)));
            }

            var total = await query.CountAsync(cancellationToken);
            var items = await query
                .OrderBy(b => b.Code)
                .Skip((request.page - 1) * request.pageSize)
                .Take(request.pageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new PagedResult<Branch>(items, total, request.page, request.pageSize);
        }
    }
}