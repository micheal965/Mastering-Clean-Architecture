using MediatR;
using SchoolManagementSystem.Core.APIBases;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<APIResponse<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
