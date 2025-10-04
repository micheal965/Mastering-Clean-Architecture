using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Helpers;
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
        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var student = await _unitOfWork.Students.GetTableNoTracking().FirstOrDefaultAsync(s => s.Name.Equals(name) && s.Id != id);
            return student == null ? false : true;
        }
        public async Task<string> EditAsync(Student student)
        {
            try
            {
                await _unitOfWork.Students.UpdateAsync(student);
                await _unitOfWork.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }
        public async Task<string> DeleteAsync(Student student)
        {
            try
            {
                await _unitOfWork.Students.DeleteAsync(student);
                await _unitOfWork.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                return "fail";
            }
        }
        public IQueryable<Student> GetStudentsWithFiltrationQueryable(StudentOrderingEnum studentOrderingEnum, string? search)
        {
            IQueryable<Student> query = _unitOfWork.Students.GetTableNoTracking().Include(s => s.Department);
            if (search != null)
                query = query.Where(s => s.Name.Contains(search) || s.Address.Contains(search));
            switch (studentOrderingEnum)
            {
                case StudentOrderingEnum.Name:
                    query = query.OrderBy(s => s.Name);
                    break;
                case StudentOrderingEnum.Address:
                    query = query.OrderBy(s => s.Address);
                    break;
                case StudentOrderingEnum.Phone:
                    query = query.OrderBy(s => s.Phone);
                    break;
                case StudentOrderingEnum.Department:
                    query = query.OrderBy(s => s.Department);
                    break;
            }
            return query;
        }
    }
}
