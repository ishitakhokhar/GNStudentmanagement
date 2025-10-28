namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_PRJ_ProjectMeetingAttendanceValidator : AbstractValidator<ACD_PRJ_ProjectMeetingAttendance>
    {
        public ACD_PRJ_ProjectMeetingAttendanceValidator()
        {
            
            RuleFor(x => x.ProjectMeetingAttendanceId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("ProjectMeetingAttendanceId must be greater than or equal to 0.");

            
            RuleFor(x => x.ProjectMeetingId)
                .GreaterThan(0)
                .WithMessage("ProjectMeetingId is required and must be greater than 0.");

            
            RuleFor(x => x.StudentId)
                .GreaterThan(0)
                .WithMessage("StudentId is required and must be greater than 0.");

            
            RuleFor(x => x.IsPresent)
                .NotNull()
                .WithMessage("Attendance status must be specified.");

            
            RuleFor(x => x.AttendanceRemarks)
                .MaximumLength(500)
                .WithMessage("Attendance remarks cannot exceed 500 characters.");

            
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
