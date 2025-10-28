CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeeting_SelectAll]
AS
SELECT
    [dbo].[ACD_PRJ_ProjectMeeting].[ProjectMeetingID],
    [dbo].[ACD_PRJ_ProjectMeeting].[ProjectGroupID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
    [dbo].[ACD_PRJ_ProjectMeeting].[GuideStaffID],
    [dbo].[ACD_Staff].[StaffName],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingDateTime],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingPurpose],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingLocation],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingNotes],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingStatus],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingStatusDescription],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingStatusDatetime],
    [dbo].[ACD_PRJ_ProjectMeeting].[Description],
    [dbo].[ACD_PRJ_ProjectMeeting].[Created],
    [dbo].[ACD_PRJ_ProjectMeeting].[Modified]
FROM [dbo].[ACD_PRJ_ProjectMeeting]
INNER JOIN [dbo].[ACD_PRJ_ProjectGroup]
    ON [dbo].[ACD_PRJ_ProjectMeeting].[ProjectGroupID] = [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID]
INNER JOIN [dbo].[ACD_Staff]
    ON [dbo].[ACD_PRJ_ProjectMeeting].[GuideStaffID] = [dbo].[ACD_Staff].[StaffID];


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeeting_SelectByID]
    @ProjectMeetingID INT
AS
    SELECT 
        ProjectMeetingID,
        ProjectGroupID,
        GuideStaffID,
        MeetingDateTime,
        MeetingPurpose,
        MeetingLocation,
        MeetingNotes,
        MeetingStatus,
        MeetingStatusDescription,
        MeetingStatusDatetime,
        Description,
        Created,
        Modified
    FROM ACD_PRJ_ProjectMeeting
    WHERE ProjectMeetingID = @ProjectMeetingID;


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeeting_Insert]
    @ProjectGroupID INT,
    @GuideStaffID INT,
    @MeetingDateTime DATETIME,
    @MeetingPurpose NVARCHAR(200),
    @MeetingLocation NVARCHAR(200) = NULL,
    @MeetingNotes NVARCHAR(MAX) = NULL,
    @MeetingStatus NVARCHAR(50) = NULL,
    @MeetingStatusDescription NVARCHAR(200) = NULL,
    @MeetingStatusDatetime DATETIME = NULL,
    @Description NVARCHAR(500) = NULL
AS
INSERT INTO [dbo].[ACD_PRJ_ProjectMeeting] (
    [ProjectGroupID],
    [GuideStaffID],
    [MeetingDateTime],
    [MeetingPurpose],
    [MeetingLocation],
    [MeetingNotes],
    [MeetingStatus],
    [MeetingStatusDescription],
    [MeetingStatusDatetime],
    [Description],
    [Created]
)
VALUES (
    @ProjectGroupID,
    @GuideStaffID,
    @MeetingDateTime,
    @MeetingPurpose,
    @MeetingLocation,
    @MeetingNotes,
    @MeetingStatus,
    @MeetingStatusDescription,
    @MeetingStatusDatetime,
    @Description,
    GETDATE()
);



CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeeting_Update]
    @ProjectMeetingID INT,
    @ProjectGroupID INT,
    @GuideStaffID INT,
    @MeetingDateTime DATETIME,
    @MeetingPurpose NVARCHAR(200),
    @MeetingLocation NVARCHAR(200) = NULL,
    @MeetingNotes NVARCHAR(MAX) = NULL,
    @MeetingStatus NVARCHAR(50) = NULL,
    @MeetingStatusDescription NVARCHAR(200) = NULL,
    @MeetingStatusDatetime DATETIME = NULL,
    @Description NVARCHAR(500) = NULL
AS
UPDATE [dbo].[ACD_PRJ_ProjectMeeting]
SET
    [ProjectGroupID] = @ProjectGroupID,
    [GuideStaffID] = @GuideStaffID,
    [MeetingDateTime] = @MeetingDateTime,
    [MeetingPurpose] = @MeetingPurpose,
    [MeetingLocation] = @MeetingLocation,
    [MeetingNotes] = @MeetingNotes,
    [MeetingStatus] = @MeetingStatus,
    [MeetingStatusDescription] = @MeetingStatusDescription,
    [MeetingStatusDatetime] = @MeetingStatusDatetime,
    [Description] = @Description,
    [Modified] = GETDATE()
WHERE [ProjectMeetingID] = @ProjectMeetingID;



CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeeting_Delete]
    @ProjectMeetingID INT
AS
BEGIN
    DELETE FROM [dbo].[ACD_PRJ_ProjectMeeting]
    WHERE [ProjectMeetingID] = @ProjectMeetingID;
END

select * from ACD_PRJ_ProjectMeeting

INSERT INTO ACD_PRJ_ProjectMeeting 
(ProjectGroupID, GuideStaffID, MeetingDateTime, MeetingPurpose, MeetingLocation, MeetingNotes, MeetingStatus)
VALUES 
(1009, 14, '2025-10-10 10:00:00', 'Project Progress Review', 'Lab 204', 'Reviewed model accuracy', 'Completed')