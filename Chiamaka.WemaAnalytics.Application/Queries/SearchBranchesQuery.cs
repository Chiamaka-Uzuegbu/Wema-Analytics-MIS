using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using Chiamaka.WemaAnalytics.Domain.Utility;
using MediatR;

namespace Chiamaka.WemaAnalytics.Application.Queries
{
    public record SearchBranchesQuery(string? q, int page = 1, int pageSize = 20) : IRequest<PagedResult<Branch>>;
    
}