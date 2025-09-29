using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Domain.Entitity
{
    public class KpiSnapshot
    {
        public int Id { get; set; }
        public DateTime SnapshotDate { get; set; }
        public int TotalAccounts { get; set; }
        public int ActiveAccounts { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal AverageBalance { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    }
}