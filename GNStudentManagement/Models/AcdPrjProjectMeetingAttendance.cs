using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;

public partial class AcdPrjProjectMeetingAttendance
{
    public int ProjectMeetingAttendanceId { get; set; }

    public int ProjectMeetingId { get; set; }

    public int StudentId { get; set; }

    public bool IsPresent { get; set; }

    public string? AttendanceRemarks { get; set; }

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual AcdPrjProjectMeeting ProjectMeeting { get; set; } = null!;

    public virtual AcdStudent Student { get; set; } = null!;
}
