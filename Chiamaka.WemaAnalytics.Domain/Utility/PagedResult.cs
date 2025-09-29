using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chiamaka.WemaAnalytics.Domain.Utility
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; }
        public int Total { get; }
        public int Page { get; }
        public int PageSize { get; }

        public PagedResult(IEnumerable<T> items, int total, int page, int pageSize)
        {
            Items = items;
            Total = total;
            Page = page;
            PageSize = pageSize;
        }
    }
}