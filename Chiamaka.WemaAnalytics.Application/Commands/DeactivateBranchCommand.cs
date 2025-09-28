using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiamaka.WemaAnalytics.Application.Dtos;
using MediatR;

namespace Chiamaka.WemaAnalytics.Application.Commands
{
    public record DeactivateBranchCommand: IRequest<Result<int>>
    {
        public Guid Id { get; set; }
    }
}