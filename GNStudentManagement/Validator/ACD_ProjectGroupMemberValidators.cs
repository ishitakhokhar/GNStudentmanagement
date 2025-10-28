namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_PRJ_ProjectGroupMemberValidator : AbstractValidator<ACD_PRJ_ProjectGroupMember>
    {
        public ACD_PRJ_ProjectGroupMemberValidator()
        {
            
            RuleFor(x => x.ProjectGroupMemberId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ProjectGroupMemberId must be greater than or equal to 0.");

            
            RuleFor(x => x.ProjectGroupId)
                .GreaterThan(0)
                .WithMessage("ProjectGroupId is required and must be greater than 0.");

            
            RuleFor(x => x.StudentId)
                .GreaterThan(0)
                .WithMessage("StudentId is required and must be greater than 0.");

            

            
            RuleFor(x => x.StudentCgpa)
                .InclusiveBetween(0, 10)
                .When(x => x.StudentCgpa.HasValue)
                .WithMessage("Student CGPA must be between 0 and 10.");

            
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Description cannot exceed 500 characters.");

            
            RuleFor(x => x.Created)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Created date cannot be in the future.");

            
            RuleFor(x => x.Modified)
                .GreaterThanOrEqualTo(x => x.Created)
                .When(x => x.Modified.HasValue)
                .WithMessage("Modified date cannot be earlier than created date.");
        }
    }

}
