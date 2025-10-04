namespace SchoolManagementSystem.Core.Wrappers
{
    public class PaginedResult<T>
    {
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public object Meta { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public bool IsSucceeded { get; set; }
        public PaginedResult(List<T> data)
        {
            Data = data;
        }
        public PaginedResult(int totalCount, int currentPage, int pageSize, bool isSucceded, List<T> data = default)
        {
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Data = data;
            IsSucceeded = isSucceded;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }


        //Factory method
        public static PaginedResult<T> Success(List<T> data, int totalCount, int currentPage, int pageSize)
          => new(totalCount, currentPage, pageSize, true, data);

    }
}
