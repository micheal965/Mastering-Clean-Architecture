namespace SchoolManagementSystem.Data.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
                                             = new HashSet<Student>();
        public ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
                                             = new HashSet<DepartmentSubject>();

    }
}
