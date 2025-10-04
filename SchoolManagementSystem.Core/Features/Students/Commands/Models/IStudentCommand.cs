namespace SchoolManagementSystem.Core.Features.Students.Commands.Models
{
    public interface IStudentCommand
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
