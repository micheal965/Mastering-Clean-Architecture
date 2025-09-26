using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync(CancellationToken cancellationToken);
        Task<Student> GetStudentByIdAsync(int id, CancellationToken cancellationToken);
        Task<string> AddAsync(Student student, CancellationToken cancellationToken);
    }
}
