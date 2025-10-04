using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Core.Wrappers
{
    public static class QueryableExtensions
    {
        public static async Task<PaginedResult<T>> ToPaginedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new Exception("No source detected");

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : pageSize;
            int count = await source.AsNoTracking().CountAsync();
            if (count == 0)
                return PaginedResult<T>.Success(new List<T>(), count, pageNumber, pageSize);

            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginedResult<T>.Success(items, count, pageNumber, pageSize);
        }
    }
}
