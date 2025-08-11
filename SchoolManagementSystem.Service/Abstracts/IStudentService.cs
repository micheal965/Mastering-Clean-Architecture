using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync();
    }
}
