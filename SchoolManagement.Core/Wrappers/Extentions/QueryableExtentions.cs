using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Core.Wrappers.Extentions
{
    public static class QueryableExtentions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedResult<T>(this IQueryable<T> source, int pageIndex = 0, int pageSize = 0)
        where T : class
        {

            if (source == null) throw new Exception("Failed To Paginat the data.");

            int count = await source.AsNoTracking().CountAsync();
            var pageIndexForPaginate = pageIndex == 0 ? 1 : pageIndex;
            var pageSizeForPaginate = ((pageSize == 0) && (count == 0)) ? 0 : (pageSize < 0 || pageSize == 0) ? 10 : pageSize;

            var forSkip = (pageIndexForPaginate <= 1 ? 0 : (pageIndexForPaginate - 1) * pageSizeForPaginate);

            IEnumerable<T> item = await source.Skip(forSkip).Take(pageSizeForPaginate).ToListAsync();

            var result = new PaginatedResult<T>(
              succeeded: true,
              data: item,
              pageSize: pageSizeForPaginate,
              pageIndex: pageIndexForPaginate,
              count: count
                  );
            return result;

        }
    }
}
