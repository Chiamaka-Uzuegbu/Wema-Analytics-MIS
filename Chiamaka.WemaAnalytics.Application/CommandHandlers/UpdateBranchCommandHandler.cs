using Chiamaka.WemaAnalytics.Application.Commands;
using Chiamaka.WemaAnalytics.Application.Dtos;
using Chiamaka.WemaAnalytics.Application.Interfaces;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Chiamaka.WemaAnalytics.Application.CommandHandlers
{
    public class UpdateBranchCommandHandler: IRequestHandler<UpdateBranchCommand, Result<int>>
    {
        private readonly IWemaDbContext _context;
        public UpdateBranchCommandHandler(IWemaDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
        
            var entity = await _context.Branches.FirstOrDefaultAsync(b => b.ID == request.Id && !b.IsDeleted, cancellationToken);
            if (entity == null) throw new KeyNotFoundException("Branch not found");

            if (!string.IsNullOrWhiteSpace(request.Name)) entity.Name = request.Name;
            if (entity.City != null) entity.City = request.City;
            if (entity.Region != null) entity.Region = request.Region;
            if (entity.IsActive) entity.IsActive = entity.IsActive;

            entity.UpdatedAtUtc = DateTime.UtcNow;
             _context.Branches.Update(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0
                ? Result<int>.Success(1, "Branch updated succesfully")
                : Result<int>.Failure("Failed to update branch");     
        }
    }
}