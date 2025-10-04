using FluentValidation;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;

namespace SchoolManagementSystem.Core.Features.Students.Commands.Validators
{
    public class StudentBaseValidator<T> : AbstractValidator<T> where T : IStudentCommand
    {
        public StudentBaseValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is Req").WithErrorCode("Name Error")
                .NotNull().WithMessage("Name must be not null").WithErrorCode("not null Error")
                .MaximumLength(10).WithMessage("Name must be less than 10 ch");

            RuleFor(s => s.Phone)
                .NotEmpty().WithMessage("Phone is Req").WithErrorCode("Error");
        }
    }
}
