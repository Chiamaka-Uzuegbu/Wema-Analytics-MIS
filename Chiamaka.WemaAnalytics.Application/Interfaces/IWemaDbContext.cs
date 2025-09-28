using Chiamaka.WemaAnalytics.Domain.Entitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Application.Interfaces
{
    public interface IWemaDbContext
    {
        DbSet<Branch> Branches { get; }
        DbSet<Account> Accounts { get; }
        DbSet<KpiSnapshot> KpiSnapshots { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
