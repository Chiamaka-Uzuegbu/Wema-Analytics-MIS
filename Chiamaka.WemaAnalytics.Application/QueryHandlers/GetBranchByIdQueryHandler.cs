using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiamaka.WemaAnalytics.Application.Dtos;
using Chiamaka.WemaAnalytics.Application.Interfaces;
using Chiamaka.WemaAnalytics.Application.Queries;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chiamaka.WemaAnalytics.Application.QueryHandlers
{
    public class GetBranchByIdQueryHandler: IRequestHandler<GetBranchByIdQuery, Branch>
    {
        private readonly IWemaDbContext _context;
        public GetBranchByIdQueryHandler(IWemaDbContext context)
        {
            _context = context;
        }

        public async Task<Branch> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var newBranch = new Branch
            {
                ID = Guid.NewGuid()
            };
            return await _context.Branches.AsNoTracking().FirstOrDefaultAsync(b => b.ID == newBranch.ID && !b.IsDeleted, cancellationToken!);
        }
    }
}