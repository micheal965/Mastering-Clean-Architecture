namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();

        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken);

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);

        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(ICollection<T> entities);

    }
}
