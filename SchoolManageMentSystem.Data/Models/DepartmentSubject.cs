namespace SchoolManagementSystem.Data.Models
{
    public class DepartmentSubject : BaseEntity
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

    }
}
