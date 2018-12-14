namespace RESTful.Catalog.API.Utilities.Resource
{    public abstract class ApiResourceParameters
    {
        const int maxPageSize = 20;
        public int PageNumber { get; set; } = 1;
        public int _pageSize { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
