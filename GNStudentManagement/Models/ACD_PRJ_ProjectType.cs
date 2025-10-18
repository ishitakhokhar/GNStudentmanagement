using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;
/// <summary>
/// 
/// </summary>
public partial class ACD_PRJ_ProjectType
{
    /// <summary>
    /// 
    /// </summary>
    public int ProjectTypeId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string ProjectTypeName { get; set; } = null!;
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
