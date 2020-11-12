using NSwag.Annotations;

namespace ProjectName.ModuleName.Domain.Common
{
    public class Pagination
    {
        private int _defaultPageSize = 10;
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        [OpenApiIgnore]
        public int Skip
        {
            get
            {
                if (PageIndex == 0)
                    return 0;
                return (PageIndex - 1) * PageSize;
            }
        }

        [OpenApiIgnore]
        public int TotalItem { get; set; }

        public Pagination()
        {
            this.PageIndex = 1;
            this.PageSize = _defaultPageSize;
            this.TotalItem = this.PageSize;
        }
    }
}
