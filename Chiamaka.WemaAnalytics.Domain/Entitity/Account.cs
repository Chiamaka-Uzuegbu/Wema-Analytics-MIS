using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Domain.Entitity
{
    public class Account
    {
        public int AccountId { get; set; }
        public string AccountNumber { get; set; } = null!;
        public string? AccountName { get; set; }
        public decimal Balance { get; set; }
        public string? Status { get; set; } 
        public DateTime? LastUpdatedAt { get; set; }
    }
}