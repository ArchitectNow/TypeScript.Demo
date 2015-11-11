using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectNow.Framework.Models
{
    public class PagedResultEnvelope<T> : Envelope<IEnumerable<T>>
    {
        public class PagingInfo
        {
            public int Page { get; set; }

            public int Limit { get; set; }

            public int PageCount { get; set; }

            public long TotalCount { get; set; }

        }

        public PagingInfo Paging { get; private set; }

        public PagedResultEnvelope(IEnumerable<T> items, int page, int limit, long totalCount)
        {
            Content = new List<T>(items);
            Paging = new PagingInfo
            {
                Page = page,
                Limit = limit,
                TotalCount = totalCount,
                PageCount = totalCount > 0
                    ? (int)Math.Ceiling(totalCount / (double)limit)
                    : 0
            };
        }

        public PagedResultEnvelope()
        {
        }
    }
}
