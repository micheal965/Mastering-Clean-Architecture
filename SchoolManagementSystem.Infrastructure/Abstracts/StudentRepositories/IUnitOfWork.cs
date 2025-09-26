using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolManagementSystem.Infrastructure.Abstracts.StudentRepositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IStudentRepository Students { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task Commit();
        Task RollBack();
        Task SaveChangesAsync();
    }
}
