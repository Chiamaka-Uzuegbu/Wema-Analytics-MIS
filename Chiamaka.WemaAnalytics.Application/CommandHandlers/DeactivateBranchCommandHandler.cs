using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiamaka.WemaAnalytics.Application.Commands;
using Chiamaka.WemaAnalytics.Application.Dtos;
using Chiamaka.WemaAnalytics.Application.Interfaces;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chiamaka.WemaAnalytics.Application.CommandHandlers
{
    public class DeactivateBranchCommandHandler : IRequestHandler<DeactivateBranchCommand, Result<int>>
    {
        private readonly IWemaDbContext _context;
        public DeactivateBranchCommandHandler(IWemaDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(DeactivateBranchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Branches.FirstOrDefaultAsync(b => b.ID == request.Id && !b.IsDeleted, cancellationToken);
            if (entity == null) throw new KeyNotFoundException("Branch not found");
            entity.IsActive = false;
            entity.UpdatedAtUtc = DateTime.UtcNow;
            return await _context.SaveChangesAsync(cancellationToken)> 0
                ? Result<int>.Success(1,"Branch deactivated succesfully")
                : Result<int>.Failure("Failed to deactivate branch");
        }
    }
}