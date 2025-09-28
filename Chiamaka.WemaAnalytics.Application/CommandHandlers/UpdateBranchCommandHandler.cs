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
            var newBranch = new Branch
            {
                ID = Guid.NewGuid(),
                Code = "WAB"+ DateTime.Now.ToString("yyMMddHHmmss"),
                Name = request.Name,
                City = request.City,
                Region = request.Region,
                IsActive = true
            };
            var entity = await _context.Branches.FirstOrDefaultAsync(b => b.ID == newBranch.ID && !b.IsDeleted, cancellationToken);
            if (entity == null) throw new KeyNotFoundException("Branch not found");

            if (!string.IsNullOrWhiteSpace(newBranch.Name)) entity.Name = newBranch.Name;
            if (newBranch.City != null) entity.City = newBranch.City;
            if (newBranch.Region != null) entity.Region = newBranch.Region;
            if (newBranch.IsActive) entity.IsActive = newBranch.IsActive;

            entity.UpdatedAtUtc = DateTime.UtcNow;
            return await _context.SaveChangesAsync(cancellationToken) > 0
                ? Result<int>.Success(1,"Branch updated succesfully")
                : Result<int>.Failure("Failed to update branch");
        
        }
    }
}