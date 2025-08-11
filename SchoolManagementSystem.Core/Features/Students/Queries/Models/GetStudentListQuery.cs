using MediatR;
using SchoolManagementSystem.Data.Models;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<List<Student>>
    {
    }
}
