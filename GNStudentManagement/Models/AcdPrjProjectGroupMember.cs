using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;

public partial class AcdPrjProjectGroupMember
{
    public int ProjectGroupMemberId { get; set; }

    public int ProjectGroupId { get; set; }

    public int StudentId { get; set; }

    public bool IsGroupLeader { get; set; }

    public decimal? StudentCgpa { get; set; }

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }

    public virtual AcdPrjProjectGroup ProjectGroup { get; set; } = null!;

    public virtual AcdStudent Student { get; set; } = null!;
}
