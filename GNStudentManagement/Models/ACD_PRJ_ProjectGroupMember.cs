using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;
/// <summary>
/// 
/// </summary>
public partial class ACD_PRJ_ProjectGroupMember
{
    /// <summary>
    /// 
    /// </summary>
    public int ProjectGroupMemberId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ProjectGroupId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int StudentId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool IsGroupLeader { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public decimal? StudentCgpa { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime Created { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? Modified { get; set; }

}
