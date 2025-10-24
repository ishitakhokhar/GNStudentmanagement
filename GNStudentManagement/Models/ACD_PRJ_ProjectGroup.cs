using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;
/// <summary>
/// 
/// </summary>
public  class ACD_PRJ_ProjectGroup
{
    /// <summary>
    /// Represent unique id for project group
    /// </summary>
    public int ProjectGroupId { get; set; }
    /// <summary>
    /// Represent project group name
    /// </summary>
    public string ProjectGroupName { get; set; } = null!;
    /// <summary>
    /// Represent project type id
    /// </summary>
    public int ProjectTypeId { get; set; }

    /// <summary>
    /// Represenet project title
    /// </summary>
    public string ProjectTitle { get; set; } = null!;
    /// <summary>
    /// Represent project area
    /// </summary>
    public string? ProjectArea { get; set; }
    /// <summary>
    /// Represent project description
    /// </summary>
    public string? ProjectDescription { get; set; }
    /// <summary>
    /// Represent average cpi
    /// </summary>
    public decimal? AverageCpi { get; set; }
    /// <summary>
    /// Represent convener staff id
    /// </summary>
    /// 

    public int? ConvenerStaffId { get; set; }
    /// <summary>
    /// Represent expert staff id
    /// </summary>
    public int? ExpertStaffId { get; set; }
    /// <summary>
    /// Represent description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public int GuideStaffID { get; set; }
    /// <summary>
    /// Represent created date time
    /// </summary>
    public DateTime Created { get; set; }
    /// <summary>
    /// Represent modified date time
    /// </summary>
    public DateTime? Modified { get; set; }
}
