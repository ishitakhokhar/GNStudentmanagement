namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_PRJ_ProjectSubmissionValidator : AbstractValidator<ACD_PRJ_ProjectSubmission>
    {
        public ACD_PRJ_ProjectSubmissionValidator()
        {
            
            RuleFor(x => x.ProjectSubmissionID)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ProjectSubmissionID must be greater than or equal to 0.");

            
            RuleFor(x => x.ProjectGroupID)
                .GreaterThan(0)
                .WithMessage("ProjectGroupID is required and must be greater than 0.");

            
            RuleFor(x => x.StudentID)
                .GreaterThan(0)
                .WithMessage("StudentID is required and must be greater than 0.");

            RuleFor(x => x.SubmissionLink)
                .NotEmpty().WithMessage("Submission link is required.")
                .MaximumLength(300).WithMessage("Submission link cannot exceed 300 characters.")
                .Must(link => Uri.TryCreate(link, UriKind.Absolute, out _))
                .WithMessage("Submission link must be a valid URL.");

            
            RuleFor(x => x.SubmissionRemarks)
                .MaximumLength(500)
                .WithMessage("Submission remarks cannot exceed 500 characters.");

            
            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .WithMessage("Description cannot exceed 1000 characters.");

            
            RuleFor(x => x.SubmissionDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Submission date cannot be in the future.");

            
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
