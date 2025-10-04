using Mapster;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Core.Mapping
{
    public class StudentMapping
    {
        public static void RegisterStudentMapping()
        {
            //Query
            TypeAdapterConfig<Student, GetStudentResponse>.NewConfig().Map(dest => dest.Department, src => src.Department.Name);

            //Command
            TypeAdapterConfig<EditStudentCommand, Student>.NewConfig().Ignore(dest => dest.Id);
        }
    }
}
