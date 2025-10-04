using MediatR;
using SchoolManagementSystem.Core.APIBases;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class EditStudentCommand : IStudentCommand, IRequest<APIResponse<string>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
