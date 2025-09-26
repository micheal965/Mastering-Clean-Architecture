using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Infrastructure.Abstracts.StudentRepositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<List<Student>> GetStudentsAsync(CancellationToken cancellationToken);

    }
}
