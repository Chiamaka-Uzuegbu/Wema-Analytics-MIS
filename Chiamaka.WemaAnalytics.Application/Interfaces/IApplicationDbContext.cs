using Chiamaka.WemaAnalytics.Domain.Entitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Branch> Branches { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
