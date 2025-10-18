using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;

public partial class AcdPrjProjectMeeting
{
    public int ProjectMeetingId { get; set; }

    public int ProjectGroupId { get; set; }

    public int GuideStaffId { get; set; }

    public DateTime MeetingDateTime { get; set; }

    public string MeetingPurpose { get; set; } = null!;

    public string? MeetingLocation { get; set; }

    public string? MeetingNotes { get; set; }

    public string? MeetingStatus { get; set; }

    public string? MeetingStatusDescription { get; set; }

    public DateTime? MeetingStatusDatetime { get; set; }

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<AcdPrjProjectMeetingAttendance> AcdPrjProjectMeetingAttendances { get; set; } = new List<AcdPrjProjectMeetingAttendance>();

    public virtual AcdStaff GuideStaff { get; set; } = null!;

    public virtual AcdPrjProjectGroup ProjectGroup { get; set; } = null!;
}
