using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Models;
using SchoolManagementSystem.Infrastructure.Abstracts.StudentRepositories;
using SchoolManagementSystem.Service.Abstracts;

namespace SchoolManagementSystem.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Student>> GetStudentsListAsync(CancellationToken cancellationToken)
        {
            return await _unitOfWork.Students.GetStudentsAsync(cancellationToken);
        }
        public async Task<Student> GetStudentByIdAsync(int id, CancellationToken cancellationToken)
             => await _unitOfWork.Students.GetTableNoTracking()
                .Include(s => s.Department)
                .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        public async Task<string> AddAsync(Student student, CancellationToken cancellationToken)
        {
            var studentResult = await _unitOfWork.Students.GetTableNoTracking().FirstOrDefaultAsync(s => s.Name.Equals(student.Name));
            if (studentResult != null) return "Exist";

            await _unitOfWork.Students.AddAsync(student, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return "success";
        }
    }
}
