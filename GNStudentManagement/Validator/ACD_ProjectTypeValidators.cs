namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_PRJ_ProjectTypeValidator : AbstractValidator<ACD_PRJ_ProjectType>
    {
        public ACD_PRJ_ProjectTypeValidator()
        {
            
            RuleFor(x => x.ProjectTypeId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ProjectTypeId must be greater than or equal to 0.");

            
            RuleFor(x => x.ProjectTypeName)
                .NotEmpty().WithMessage("Project type name is required.")
                .MaximumLength(100).WithMessage("Project type name cannot exceed 100 characters.");

            
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
