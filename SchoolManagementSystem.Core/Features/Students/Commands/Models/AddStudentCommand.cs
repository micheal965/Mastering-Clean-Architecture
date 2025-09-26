using MediatR;
using SchoolManagementSystem.Core.APIBases;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public class AddStudentCommand : IRequest<APIResponse<string>>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
