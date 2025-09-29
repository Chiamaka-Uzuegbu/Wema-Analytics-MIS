using Chiamaka.WemaAnalytics.Application.Commands;
using Chiamaka.WemaAnalytics.Application.Dtos;
using Chiamaka.WemaAnalytics.Application.Interfaces;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Application.CommandHandlers
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Result<int>>
    {
        private readonly IWemaDbContext _context;
        public CreateBranchCommandHandler(IWemaDbContext context)
        {
            _context = context;
        }
        public async Task<Result<int>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
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
            await _context.Branches.AddAsync(newBranch);
            return await _context.SaveChangesAsync(cancellationToken) > 0
                ? Result<int>.Success(1,"Branch created succesfully")
                : Result<int>.Failure("Failed to create branch");
        }
    }
}
