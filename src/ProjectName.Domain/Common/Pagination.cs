using Newtonsoft.Json;
using NSwag.Annotations;

namespace ProjectName.Domain.Common
{
    public class Pagination
    {
        [JsonProperty(PropertyName = "pageIndex")]
        public int PageIndex { get; set; }

        [JsonProperty(PropertyName = "pageSize")]
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
            this.PageSize = DataDefine.DefaultPageSize;
            this.TotalItem = this.PageSize;
        }
    }
}
