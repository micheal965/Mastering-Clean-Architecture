namespace SchoolManagementSystem.Core.Features.Students.Queries.Results
{
    public class GetStudentResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public GetStudentResponse(string name, string address, string phone, string department)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Department = department;
        }
    }

}
