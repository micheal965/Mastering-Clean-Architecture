using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Models;
using SchoolManagementSystem.Infrastructure.Abstracts;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Student>> GetStudentsAsync()
                      => await _dbContext.Students.ToListAsync();
    }
}
