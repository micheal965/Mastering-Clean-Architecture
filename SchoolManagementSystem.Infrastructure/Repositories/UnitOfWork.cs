using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagementSystem.Infrastructure.Abstracts.StudentRepositories;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IStudentRepository Students { get; }
        public UnitOfWork(ApplicationDbContext dbContext, IStudentRepository studentRepository)
        {
            _dbContext = dbContext;
            Students = studentRepository;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _dbContext.Database.BeginTransactionAsync();
        public async Task Commit() => await _dbContext.Database.CommitTransactionAsync();
        public async Task RollBack() => await _dbContext.Database.RollbackTransactionAsync();
        public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();

    }
}
