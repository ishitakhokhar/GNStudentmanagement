using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;

public partial class AcdStaff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<AcdPrjProjectGroup> AcdPrjProjectGroupConvenerStaffs { get; set; } = new List<AcdPrjProjectGroup>();

    public virtual ICollection<AcdPrjProjectGroup> AcdPrjProjectGroupExpertStaffs { get; set; } = new List<AcdPrjProjectGroup>();

    public virtual ICollection<AcdPrjProjectMeeting> AcdPrjProjectMeetings { get; set; } = new List<AcdPrjProjectMeeting>();
}
