CREATE OR ALTER PROCEDURE [dbo].[ACD_RPT_ProjectSummary_SelectAll]
AS
SELECT
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectTitle],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectArea],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectDescription],
    [dbo].[ACD_PRJ_ProjectGroup].[AverageCPI],
    [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID],
    [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
    [dbo].[ACD_PRJ_ProjectType].[Description] AS [ProjectTypeDescription],
    [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID],
    [GuideStaff].[StaffName] AS [GuideStaffName],
    [GuideStaff].[Email] AS [GuideEmail],
    [GuideStaff].[Phone] AS [GuidePhone],
    [dbo].[ACD_PRJ_ProjectGroup].[Created],
    [dbo].[ACD_PRJ_ProjectGroup].[Modified]
FROM [dbo].[ACD_PRJ_ProjectGroup]
INNER JOIN [dbo].[ACD_PRJ_ProjectType]
    ON [dbo].[ACD_PRJ_ProjectGroup].[ProjectTypeID] = [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID]
LEFT JOIN [dbo].[ACD_Staff] AS [GuideStaff]
    ON [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID] = [GuideStaff].[StaffID]
ORDER BY [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName];





-- Get full group details with members and attendance
CREATE OR ALTER PROCEDURE [dbo].[ACD_RPT_ProjectGroup_SelectByID]
    @ProjectGroupID INT
AS
    SELECT 
        [ACD_PRJ_ProjectGroup].[ProjectGroupID],
        [ACD_PRJ_ProjectGroup].[ProjectGroupName],
        [ACD_PRJ_ProjectGroup].[ProjectTitle],
        [ACD_PRJ_ProjectGroup].[ProjectArea],
        [ACD_PRJ_ProjectGroup].[AverageCPI],
        [ACD_PRJ_ProjectGroup].[Description] AS [GroupDescription],

        [ACD_PRJ_ProjectGroupMember].[ProjectGroupMemberID],
        [ACD_PRJ_ProjectGroupMember].[StudentID],
        [ACD_Student].[StudentName],
        [ACD_PRJ_ProjectGroupMember].[IsGroupLeader],
        [ACD_PRJ_ProjectGroupMember].[StudentCGPA],

        [ACD_PRJ_ProjectMeeting].[ProjectMeetingID],
        [ACD_PRJ_ProjectMeeting].[MeetingPurpose],
        [ACD_PRJ_ProjectMeeting].[MeetingDateTime],
        [ACD_PRJ_ProjectMeetingAttendance].[ProjectMeetingAttendanceID],
        [ACD_PRJ_ProjectMeetingAttendance].[IsPresent],
        [ACD_PRJ_ProjectMeetingAttendance].[AttendanceRemarks]

    FROM [dbo].[ACD_PRJ_ProjectGroup]
    INNER JOIN [dbo].[ACD_PRJ_ProjectGroupMember]
        ON [ACD_PRJ_ProjectGroup].[ProjectGroupID] = [ACD_PRJ_ProjectGroupMember].[ProjectGroupID]
    INNER JOIN [dbo].[ACD_Student]
        ON [ACD_PRJ_ProjectGroupMember].[StudentID] = [ACD_Student].[StudentID]
    LEFT JOIN [dbo].[ACD_PRJ_ProjectMeeting]
        ON [ACD_PRJ_ProjectGroup].[ProjectGroupID] = [ACD_PRJ_ProjectMeeting].[ProjectGroupID]
    LEFT JOIN [dbo].[ACD_PRJ_ProjectMeetingAttendance]
        ON [ACD_Student].[StudentID] = [ACD_PRJ_ProjectMeetingAttendance].[StudentID]
        AND [ACD_PRJ_ProjectMeeting].[ProjectMeetingID] = [ACD_PRJ_ProjectMeetingAttendance].[ProjectMeetingID]
    WHERE [ACD_PRJ_ProjectGroup].[ProjectGroupID] = @ProjectGroupID;

EXEC ACD_RPT_ProjectGroup_SelectByID @ProjectGroupID = 1;




CREATE OR ALTER PROCEDURE [dbo].[ACD_RPT_EXCEL_SelectAll]
AS
    SELECT 
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectTitle],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectArea],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectDescription],
        [dbo].[ACD_PRJ_ProjectGroup].[AverageCPI],
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID],
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
        [dbo].[ACD_PRJ_ProjectType].[Description] AS [ProjectTypeDescription],
        [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID],
        [dbo].[ACD_Staff].[StaffName] AS [GuideStaffName],
        [dbo].[ACD_Staff].[Email] AS [GuideEmail],
        [dbo].[ACD_Staff].[Phone] AS [GuidePhone],
        [dbo].[ACD_PRJ_ProjectGroup].[ProposalStatus],
        [dbo].[ACD_PRJ_ProjectGroup].[IsApproved],
        [dbo].[ACD_PRJ_ProjectGroup].[ApprovedBy],
        [dbo].[ACD_PRJ_ProjectGroup].[ApprovedDate],
        [dbo].[ACD_PRJ_ProjectGroup].[Created],
        [dbo].[ACD_PRJ_ProjectGroup].[Modified]
    FROM [dbo].[ACD_PRJ_ProjectGroup]
    LEFT JOIN [dbo].[ACD_PRJ_ProjectType] 
        ON [dbo].[ACD_PRJ_ProjectGroup].[ProjectTypeID] = [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID]
    LEFT JOIN [dbo].[ACD_Staff] 
        ON [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID] = [dbo].[ACD_Staff].[StaffID]
    ORDER BY [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName];




CREATE OR ALTER PROCEDURE [dbo].[ACD_RPT_EXCEL_SelectByGroupID]
    @ProjectGroupID INT
AS
    SELECT 
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectTitle],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectArea],
        [dbo].[ACD_PRJ_ProjectGroup].[ProjectDescription],
        [dbo].[ACD_PRJ_ProjectGroup].[AverageCPI],
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID],
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
        [dbo].[ACD_PRJ_ProjectType].[Description] AS [ProjectTypeDescription],
        [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID],
        [dbo].[ACD_Staff].[StaffName] AS [GuideStaffName],
        [dbo].[ACD_Staff].[Email] AS [GuideEmail],
        [dbo].[ACD_Staff].[Phone] AS [GuidePhone],
        [dbo].[ACD_PRJ_ProjectGroup].[ProposalDoc],
        [dbo].[ACD_PRJ_ProjectGroup].[ProposalStatus],
        [dbo].[ACD_PRJ_ProjectGroup].[IsApproved],
        [dbo].[ACD_PRJ_ProjectGroup].[ApprovedBy],
        [dbo].[ACD_PRJ_ProjectGroup].[ApprovedDate],
        [dbo].[ACD_PRJ_ProjectGroup].[Created],
        [dbo].[ACD_PRJ_ProjectGroup].[Modified]
    FROM [dbo].[ACD_PRJ_ProjectGroup]
    LEFT JOIN [dbo].[ACD_PRJ_ProjectType] 
        ON [dbo].[ACD_PRJ_ProjectGroup].[ProjectTypeID] = [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID]
    LEFT JOIN [dbo].[ACD_Staff] 
        ON [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID] = [dbo].[ACD_Staff].[StaffID]
    WHERE [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID] = @ProjectGroupID;



