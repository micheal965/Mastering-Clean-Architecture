using SchoolManagementSystem.Data.Helpers;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync(CancellationToken cancellationToken);
        Task<Student> GetStudentByIdAsync(int id, CancellationToken cancellationToken);
        Task<string> AddAsync(Student student, CancellationToken cancellationToken);
        Task<string> EditAsync(Student student);
        Task<string> DeleteAsync(Student student);
        IQueryable<Student> GetStudentsWithFiltrationQueryable(StudentOrderingEnum studentOrderingEnum, string? search);
    }
}
