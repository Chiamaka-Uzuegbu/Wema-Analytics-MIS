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
    public class WemaDbContext : DbContext, IWemaDbContext
    {
        public WemaDbContext(DbContextOptions<WemaDbContext> options) : base(options)
        {
        }
        public DbSet<Branch> Branches { get; set; } 
        public DbSet<Account> Accounts { get; set; } 
        public DbSet<KpiSnapshot> KpiSnapshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();

            modelBuilder.Entity<KpiSnapshot>()
                .HasIndex(k => k.SnapshotDate)
                .IsUnique(); 
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
