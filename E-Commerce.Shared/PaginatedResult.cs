using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared
{
    public class PaginatedResult<T>
    {
        public PaginatedResult(int pageIndex, int pageSize, int totalCount, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            count = totalCount;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
