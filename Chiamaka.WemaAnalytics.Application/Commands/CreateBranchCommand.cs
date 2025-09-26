using Chiamaka.WemaAnalytics.Application.Dtos;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Application.Commands
{
    public class CreateBranchCommand : IRequest<Result<int>>
    {
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;

    }

    public class  CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBranchCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Branch name is required");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.Region).NotEmpty().WithMessage("Region is required");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Branch name must not exceed 100 characters");
            
        }
    }
}
