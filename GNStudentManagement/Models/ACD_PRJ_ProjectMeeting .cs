using System;
using System.Collections.Generic;

namespace GNStudentManagement.Models;
/// <summary>
/// 
/// </summary>
public partial class ACD_PRJ_ProjectMeeting
{
    /// <summary>
    /// 
    /// </summary>
    public int ProjectMeetingId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int ProjectGroupId { get; set; }
/// <summary>
/// 
/// </summary>
    public int GuideStaffId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime MeetingDateTime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string MeetingPurpose { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public string? MeetingLocation { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? MeetingNotes { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? MeetingStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? MeetingStatusDescription { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime? MeetingStatusDatetime { get; set; }
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
