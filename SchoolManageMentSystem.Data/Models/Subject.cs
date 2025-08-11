namespace SchoolManagementSystem.Data.Models
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Period { get; set; }
        public ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
                                                        = new HashSet<DepartmentSubject>();
        public ICollection<StudentSubject> StudentSubjects { get; set; }
                                                        = new HashSet<StudentSubject>();
    }
}
