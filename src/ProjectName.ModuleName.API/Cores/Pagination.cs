using System.Linq;
using System.Runtime.Serialization;

namespace Stu.AspNetCore.Mvc
{
    public class Pagination
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        [IgnoreDataMember]
        public int Skip
        {
            get
            {
                if (PageIndex == 0)
                {
                    return 0;
                }

                return (PageIndex - 1) * PageSize;
            }
        }

        public Pagination()
        {
            PageIndex = 1;
            PageSize = 10;
        }
    }

    public static class PaginationExtentions
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, Pagination pagination)
        {
            return query.Skip(pagination.Skip).Take(pagination.PageSize);
        }
    }
}
