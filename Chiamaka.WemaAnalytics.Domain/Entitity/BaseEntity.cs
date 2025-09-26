using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Domain.Entitity
{
    public class BaseEntity<T>
    {
        public T ID { get; set; }
        public DateTimeOffset CreatedAtUtc { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpadatedAtUtc { get; set; } 
    }
}
