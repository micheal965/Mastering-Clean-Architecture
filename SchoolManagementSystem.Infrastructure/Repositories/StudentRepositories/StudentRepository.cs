using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data.Models;
using SchoolManagementSystem.Infrastructure.Abstracts.StudentRepositories;
using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories.StudentRepositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Student>> GetStudentsAsync(CancellationToken cancellationToken)
                      => await _dbContext.Students.Include(s => s.Department).ToListAsync(cancellationToken);
    }
}
