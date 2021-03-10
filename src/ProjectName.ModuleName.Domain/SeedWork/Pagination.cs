namespace ProjectName.ModuleName.Domain.SeedWork
{
    public class Pagination
    {
        private int _defaultPageSize = 10;
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int Skip
        {
            get
            {
                if (PageIndex == 0)
                    return 0;
                return (PageIndex - 1) * PageSize;
            }
        }

        public Pagination()
        {
            this.PageIndex = 1;
            this.PageSize = _defaultPageSize;
        }
    }
}
