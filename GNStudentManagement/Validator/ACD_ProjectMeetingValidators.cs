namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_PRJ_ProjectMeetingValidator : AbstractValidator<ACD_PRJ_ProjectMeeting>
    {
        public ACD_PRJ_ProjectMeetingValidator()
        {
            
            RuleFor(x => x.ProjectMeetingId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ProjectMeetingId must be greater than or equal to 0.");

            
            RuleFor(x => x.ProjectGroupId)
                .GreaterThan(0)
                .WithMessage("ProjectGroupId is required and must be greater than 0.");

            
            RuleFor(x => x.GuideStaffId)
                .GreaterThan(0)
                .WithMessage("GuideStaffId is required and must be greater than 0.");

            
            RuleFor(x => x.MeetingDateTime)
                .GreaterThan(DateTime.Now.AddMinutes(-5))
                .WithMessage("Meeting date and time must be current or in the future.");

            
            RuleFor(x => x.MeetingPurpose)
                .NotEmpty().WithMessage("Meeting purpose is required.")
                .MaximumLength(200).WithMessage("Meeting purpose cannot exceed 200 characters.");

            
            RuleFor(x => x.MeetingLocation)
                .MaximumLength(200)
                .WithMessage("Meeting location cannot exceed 200 characters.");

            
            RuleFor(x => x.MeetingNotes)
                .MaximumLength(1000)
                .WithMessage("Meeting notes cannot exceed 1000 characters.");

            
            RuleFor(x => x.MeetingStatus)
                .MaximumLength(50)
                .WithMessage("Meeting status cannot exceed 50 characters.");

            
            RuleFor(x => x.MeetingStatusDescription)
                .MaximumLength(500)
                .WithMessage("Meeting status description cannot exceed 500 characters.");

            
            RuleFor(x => x.MeetingStatusDatetime)
                .GreaterThanOrEqualTo(x => x.MeetingDateTime)
                .When(x => x.MeetingStatusDatetime.HasValue)
                .WithMessage("Meeting status datetime cannot be earlier than the meeting datetime.");

            
            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .WithMessage("Description cannot exceed 1000 characters.");

            
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
