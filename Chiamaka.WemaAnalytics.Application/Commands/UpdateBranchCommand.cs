using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiamaka.WemaAnalytics.Application.Dtos;
using FluentValidation;
using MediatR;

namespace Chiamaka.WemaAnalytics.Application.Commands
{
    public record UpdateBranchCommand : IRequest<Result<int>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
    }
    
    public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Branch name is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region is required");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Branch name must not exceed 100 characters");

        }
    }
}