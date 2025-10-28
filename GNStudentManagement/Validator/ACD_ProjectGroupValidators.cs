namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_PRJ_ProjectGroupValidator : AbstractValidator<ACD_PRJ_ProjectGroup>
    {
        public ACD_PRJ_ProjectGroupValidator()
        {
            
            RuleFor(x => x.ProjectGroupId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ProjectGroupId must be greater than or equal to 0.");

            
            RuleFor(x => x.ProjectGroupName)
                .NotEmpty().WithMessage("Project group name is required.")
                .MaximumLength(200).WithMessage("Project group name cannot exceed 200 characters.");

            
            RuleFor(x => x.ProjectTypeId)
                .GreaterThan(0)
                .WithMessage("ProjectTypeId must be greater than 0.");

            
            RuleFor(x => x.ProjectTitle)
                .NotEmpty().WithMessage("Project title is required.")
                .MaximumLength(200).WithMessage("Project title cannot exceed 200 characters.");

            
            RuleFor(x => x.ProjectArea)
                .MaximumLength(200)
                .WithMessage("Project area cannot exceed 200 characters.");

            
            RuleFor(x => x.ProjectDescription)
                .MaximumLength(1000)
                .WithMessage("Project description cannot exceed 1000 characters.");

            
            RuleFor(x => x.AverageCpi)
                .InclusiveBetween(0, 10)
                .When(x => x.AverageCpi.HasValue)
                .WithMessage("Average CPI must be between 0 and 10.");

            
            RuleFor(x => x.ConvenerStaffId)
                .GreaterThan(0)
                .When(x => x.ConvenerStaffId.HasValue)
                .WithMessage("ConvenerStaffId must be greater than 0 if specified.");

            
            RuleFor(x => x.ExpertStaffId)
                .GreaterThan(0)
                .When(x => x.ExpertStaffId.HasValue)
                .WithMessage("ExpertStaffId must be greater than 0 if specified.");

            
            RuleFor(x => x.GuideStaffID)
                .GreaterThan(0)
                .WithMessage("GuideStaffID must be greater than 0.");

            
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
