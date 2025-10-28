namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_StudentValidators : AbstractValidator<ACD_Student>
    {
        public ACD_StudentValidators()
        {
            RuleFor(x => x.StudentId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("StudentId must be greater than or equal to 0.");

            
            RuleFor(x => x.StudentName)
                .NotEmpty().WithMessage("Student name is required.")
                .MaximumLength(100).WithMessage("Student name cannot exceed 100 characters.");

            
            //RuleFor(x => x.Password)
            //    .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            //    .Matches(@"^(?=.*[A-Za-z])(?=.*\d).+$")
            //    .When(x => !string.IsNullOrEmpty(x.Password))
            //    .WithMessage("Password must contain at least one letter and one number.");

  
            RuleFor(x => x.Phone)
                .Matches(@"^[0-9]{10}$")
                .When(x => !string.IsNullOrEmpty(x.Phone))
                .WithMessage("Phone number must be a valid 10-digit number.");

            
            RuleFor(x => x.Email)
                .EmailAddress()
                .When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Invalid email address.");

            
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description cannot exceed 500 characters.");

            
            RuleFor(x => x.Created)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Created date cannot be in the future.");

            
            RuleFor(x => x.Modified)
                .GreaterThanOrEqualTo(x => x.Created)
                .WithMessage("Modified date cannot be earlier than created date.");
        }
    }

}
