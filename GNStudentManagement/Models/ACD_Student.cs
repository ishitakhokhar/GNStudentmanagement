using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;
/// <summary>
/// 
/// </summary>
public partial class ACD_Student
{
    /// <summary>
    /// 
    /// </summary>
    public int StudentId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string StudentName { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string? Password { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Email { get; set; }
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
