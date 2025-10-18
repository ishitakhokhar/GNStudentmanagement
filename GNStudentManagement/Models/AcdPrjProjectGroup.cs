using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;

public partial class AcdPrjProjectGroup
{
    public int ProjectGroupId { get; set; }

    public string ProjectGroupName { get; set; } = null!;

    public int ProjectTypeId { get; set; }

    public string? GuideStaffName { get; set; }

    public string ProjectTitle { get; set; } = null!;

    public string? ProjectArea { get; set; }

    public string? ProjectDescription { get; set; }

    public decimal? AverageCpi { get; set; }

    public int? ConvenerStaffId { get; set; }

    public int? ExpertStaffId { get; set; }

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual ICollection<AcdPrjProjectGroupMember> AcdPrjProjectGroupMembers { get; set; } = new List<AcdPrjProjectGroupMember>();

    public virtual ICollection<AcdPrjProjectMeeting> AcdPrjProjectMeetings { get; set; } = new List<AcdPrjProjectMeeting>();

    public virtual AcdStaff? ConvenerStaff { get; set; }

    public virtual AcdStaff? ExpertStaff { get; set; }

    public virtual AcdPrjProjectType ProjectType { get; set; } = null!;
}
