using SchoolManagementSystem.Core.Features.Students.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : StudentBaseValidator<AddStudentCommand>
    {
        public AddStudentValidator()
        {
            //Add custom validator to the addStudent 
        }

    }
}
