namespace GNStudentManagement.Validator
{
    using FluentValidation;
    using GNStudentManagement.Models;

    public class ACD_RPT_ProjectGroupDetailValidator : AbstractValidator<ACD_RPT_ProjectGroupDetail>
    {
        public ACD_RPT_ProjectGroupDetailValidator()
        {
            
            RuleFor(x => x.ProjectGroupID)
                .GreaterThan(0)
                .WithMessage("ProjectGroupID must be greater than 0.");

            
            RuleFor(x => x.projectGroupMemberID)
                .GreaterThan(0)
                .WithMessage("ProjectGroupMemberID must be greater than 0.");

            
            RuleFor(x => x.studentID)
                .GreaterThan(0)
                .WithMessage("StudentID must be greater than 0.");

            
            RuleFor(x => x.projectMeetingID)
                .GreaterThan(0)
                .WithMessage("ProjectMeetingID must be greater than 0.");

            
            RuleFor(x => x.ProjectMeetingAttendanceID)
                .GreaterThan(0)
                .WithMessage("ProjectMeetingAttendanceID must be greater than 0.");
        }
    }

}
