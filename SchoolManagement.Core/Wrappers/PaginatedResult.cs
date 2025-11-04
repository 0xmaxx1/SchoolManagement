
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Wrappers
{
    public class PaginatedResult<T> : Response<T>
    {
        public PaginatedResult()
        {

        }

        public PaginatedResult(string message)
        {
            Message = message;
            Data = new List<T>();

        }

        public PaginatedResult(bool succeeded, IEnumerable<T> data, int pageSize, int pageIndex, int count = 0) : base(succeeded)

        {
            Data = data;
            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = count;
            TotalPages = pageSize > 0 ? (int)Math.Ceiling(count / (double)pageSize) : 0;
        }

        public static PaginatedResult<T> Success(IEnumerable<T> data, int pageSize, int pageIndex, int count)
        {
            return new PaginatedResult<T>(true, data, pageSize, pageIndex, count)
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Successfully"
            };
        }
        public static PaginatedResult<T> Failed()
        {
            return new PaginatedResult<T>("Failed")
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false
            };
        }




        public new IEnumerable<T>? Data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

    }
}
