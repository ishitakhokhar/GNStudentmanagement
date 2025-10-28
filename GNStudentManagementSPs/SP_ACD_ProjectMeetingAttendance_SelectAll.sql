CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeetingAttendance_SelectAll]
AS
SELECT 
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[ProjectMeetingAttendanceID],
    [dbo].[ACD_PRJ_ProjectMeeting].[ProjectMeetingID],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingPurpose],
    [dbo].[ACD_Student].[StudentID],
    [dbo].[ACD_Student].[StudentName],           
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[IsPresent],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[AttendanceRemarks],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[Description],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[Created],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[Modified]
FROM [dbo].[ACD_PRJ_ProjectMeetingAttendance]
INNER JOIN [dbo].[ACD_PRJ_ProjectMeeting]
    ON [dbo].[ACD_PRJ_ProjectMeetingAttendance].[ProjectMeetingID] = [dbo].[ACD_PRJ_ProjectMeeting].[ProjectMeetingID]
INNER JOIN [dbo].[ACD_Student]
    ON [dbo].[ACD_PRJ_ProjectMeetingAttendance].[StudentID] = [dbo].[ACD_Student].[StudentID];




-- Select Attendance By ID without aliases
CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeetingAttendance_SelectByID]
    @ProjectMeetingAttendanceID INT
AS
SELECT 
   [dbo].[ACD_PRJ_ProjectMeetingAttendance].[ProjectMeetingAttendanceID],
    [dbo].[ACD_PRJ_ProjectMeeting].[ProjectMeetingID],
    [dbo].[ACD_PRJ_ProjectMeeting].[MeetingPurpose],
    [dbo].[ACD_Student].[StudentID],
    [dbo].[ACD_Student].[StudentName],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[IsPresent],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[AttendanceRemarks],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[Description],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[Created],
    [dbo].[ACD_PRJ_ProjectMeetingAttendance].[Modified]
FROM [dbo].[ACD_PRJ_ProjectMeetingAttendance]
INNER JOIN [dbo].[ACD_PRJ_ProjectMeeting]
    ON [ACD_PRJ_ProjectMeetingAttendance].[ProjectMeetingID] = [ACD_PRJ_ProjectMeeting].[ProjectMeetingID]
INNER JOIN [dbo].[ACD_Student]
    ON [ACD_PRJ_ProjectMeetingAttendance].[StudentID] = [ACD_Student].[StudentID]
WHERE [ACD_PRJ_ProjectMeetingAttendance].[ProjectMeetingAttendanceID] = @ProjectMeetingAttendanceID;



CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeetingAttendance_Insert]
    @ProjectMeetingID INT,
    @StudentID INT,
    @IsPresent BIT = 0,
    @AttendanceRemarks NVARCHAR(200) = NULL,
    @Description NVARCHAR(500) = NULL
AS
INSERT INTO [dbo].[ACD_PRJ_ProjectMeetingAttendance] (
    [ProjectMeetingID],
    [StudentID],
    [IsPresent],
    [AttendanceRemarks],
    [Description],
    [Created]
)
VALUES (
    @ProjectMeetingID,
    @StudentID,
    @IsPresent,
    @AttendanceRemarks,
    @Description,
    GETDATE()
);


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeetingAttendance_Update]
    @ProjectMeetingAttendanceID INT,
    @ProjectMeetingID INT,
    @StudentID INT,
    @IsPresent BIT = 0,
    @AttendanceRemarks NVARCHAR(200) = NULL,
    @Description NVARCHAR(500) = NULL
AS
UPDATE [dbo].[ACD_PRJ_ProjectMeetingAttendance]
SET
    [ProjectMeetingID] = @ProjectMeetingID,
    [StudentID] = @StudentID,
    [IsPresent] = @IsPresent,
    [AttendanceRemarks] = @AttendanceRemarks,
    [Description] = @Description,
    [Modified] = GETDATE()
WHERE [ProjectMeetingAttendanceID] = @ProjectMeetingAttendanceID;



CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectMeetingAttendance_Delete]
    @ProjectMeetingAttendanceID INT
AS
DELETE FROM [dbo].[ACD_PRJ_ProjectMeetingAttendance]
WHERE [ProjectMeetingAttendanceID] = @ProjectMeetingAttendanceID;

select * from ACD_PRJ_ProjectMeetingAttendance



INSERT INTO ACD_PRJ_ProjectMeetingAttendance (ProjectMeetingID, StudentID, IsPresent, AttendanceRemarks)
VALUES 
(2, 2010, 1, 'Participated actively')



