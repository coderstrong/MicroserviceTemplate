using System.Linq;
using System.Runtime.Serialization;
using NSwag.Annotations;

namespace Stu.AspNetCore.Mvc
{
    public class Pagination
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        [IgnoreDataMember]
        [OpenApiIgnore]
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

        [IgnoreDataMember]
        [OpenApiIgnore]
        public int TotalItem { get; set; }

        public Pagination()
        {
            PageIndex = 1;
            PageSize = 10;
            TotalItem = PageSize;
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
