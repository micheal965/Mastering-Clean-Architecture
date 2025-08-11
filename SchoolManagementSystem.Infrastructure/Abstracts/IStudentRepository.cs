using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();

    }
}
