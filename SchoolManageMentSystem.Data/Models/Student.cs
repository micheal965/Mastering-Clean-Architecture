namespace SchoolManagementSystem.Data.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
                                                = new HashSet<StudentSubject>();

    }
}
