namespace Application.Core
{
    public class PagingParams
    {
        // allows user to set maximum page size, which is generous but not forever
        private const int MaxPageSize = 100;
        public int PageNumber { get; set; } = 1;

        // default value is 25
        private int _pageSize = 25;

        // if user specifies nothing, will be 25
        // otherwise will be value user specifies
        // with max value of 100
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}