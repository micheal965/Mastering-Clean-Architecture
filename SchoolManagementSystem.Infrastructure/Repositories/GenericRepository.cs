using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        public IQueryable<T> GetTableNoTracking() => _dbSet.AsNoTracking().AsQueryable();
        public IQueryable<T> GetTableAsTracking() => _dbSet.AsTracking().AsQueryable();

        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken)
            => await _dbSet.AddAsync(entity, cancellationToken);
        public virtual async Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken)
            => await _dbSet.AddRangeAsync(entities, cancellationToken);

        public virtual async Task DeleteAsync(T entity) => _dbSet.Remove(entity);
        public virtual async Task DeleteRangeAsync(ICollection<T> entities) => _dbSet.RemoveRange(entities);

        public virtual async Task UpdateAsync(T entity) => _dbSet.Update(entity);
        public virtual async Task UpdateRangeAsync(ICollection<T> entities) => _dbSet.UpdateRange(entities);


    }
}
