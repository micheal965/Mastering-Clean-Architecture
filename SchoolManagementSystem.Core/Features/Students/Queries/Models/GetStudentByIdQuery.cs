using MediatR;
using SchoolManagementSystem.Core.APIBases;
using SchoolManagementSystem.Core.Features.Students.Queries.Results;

namespace SchoolManagementSystem.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<APIResponse<GetStudentResponse>>
    {
        public int Id { get; set; }
    }
}
