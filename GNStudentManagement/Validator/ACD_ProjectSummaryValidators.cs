namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_RPT_ProjectSummaryValidator : AbstractValidator<ACD_RPT_ProjectSummary>
    {
        public ACD_RPT_ProjectSummaryValidator()
        {
            
            RuleFor(x => x.ProjectGroupID)
                .GreaterThan(0)
                .WithMessage("ProjectGroupID must be greater than 0.");

            
            RuleFor(x => x.ProjectGroupName)
                .NotEmpty().WithMessage("Project group name is required.")
                .MaximumLength(100).WithMessage("Project group name cannot exceed 100 characters.");

            
            RuleFor(x => x.ProjectTitle)
                .NotEmpty().WithMessage("Project title is required.")
                .MaximumLength(200).WithMessage("Project title cannot exceed 200 characters.");

            
            RuleFor(x => x.ProjectArea)
                .NotEmpty().WithMessage("Project area is required.")
                .MaximumLength(100).WithMessage("Project area cannot exceed 100 characters.");

            
            RuleFor(x => x.ProjectDescription)
                .MaximumLength(1000)
                .WithMessage("Project description cannot exceed 1000 characters.");

            
            RuleFor(x => x.AverageCPI)
                .InclusiveBetween(0, 10)
                .When(x => x.AverageCPI.HasValue)
                .WithMessage("Average CPI must be between 0 and 10.");

            
            RuleFor(x => x.ProjectTypeID)
                .GreaterThan(0)
                .WithMessage("ProjectTypeID must be greater than 0.");

            
            RuleFor(x => x.GuideStaffID)
                .GreaterThan(0)
                .When(x => x.GuideStaffID.HasValue)
                .WithMessage("GuideStaffID must be greater than 0.");

            
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
