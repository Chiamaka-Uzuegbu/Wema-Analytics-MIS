using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Domain.Entitity
{
    public class Branch: BaseEntity<Guid>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string City { get; set; } = string.Empty;
        public string  Region { get; set; } = string.Empty;
        public bool  IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
