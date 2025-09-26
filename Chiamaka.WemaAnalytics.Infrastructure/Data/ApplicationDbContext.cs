using Chiamaka.WemaAnalytics.Application.Interfaces;
using Chiamaka.WemaAnalytics.Domain.Entitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Branch> Branches => Set<Branch>();
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
