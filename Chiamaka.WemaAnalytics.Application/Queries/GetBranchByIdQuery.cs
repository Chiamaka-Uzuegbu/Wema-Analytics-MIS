using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiamaka.WemaAnalytics.Application.Dtos;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using MediatR;

namespace Chiamaka.WemaAnalytics.Application.Queries
{
    public class GetBranchByIdQuery: IRequest<Branch>
    {
        public Guid Id { get; set; }
    }
}