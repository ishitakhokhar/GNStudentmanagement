using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;
/// <summary>
/// 
/// </summary>
public partial class ACD_PRJ_ProjectMeetingAttendance
{
    /// <summary>
    /// 
    /// </summary>
    public int ProjectMeetingAttendanceId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ProjectMeetingId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int StudentId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool IsPresent { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? AttendanceRemarks { get; set; }
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
