using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;

public partial class AcdStudent
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string? Password { get; set; }
    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<AcdPrjProjectGroupMember> AcdPrjProjectGroupMembers { get; set; } = new List<AcdPrjProjectGroupMember>();

    public virtual ICollection<AcdPrjProjectMeetingAttendance> AcdPrjProjectMeetingAttendances { get; set; } = new List<AcdPrjProjectMeetingAttendance>();
}
