using Mapster;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Core.Mapping
{
    public class StudentMapping
    {
        public static void RegisterStudentMapping()
        {
            TypeAdapterConfig<Student, GetStudentResponse>.NewConfig().Map(dest => dest.Department, src => src.Department.Name);
        }
    }
}
