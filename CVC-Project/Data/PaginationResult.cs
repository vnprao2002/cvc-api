using System.Collections.Generic;

namespace CVC_Project.Data
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
    }
}