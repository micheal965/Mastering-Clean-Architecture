namespace SchoolManagementSystem.Data.Models
{
    public class StudentSubject : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
