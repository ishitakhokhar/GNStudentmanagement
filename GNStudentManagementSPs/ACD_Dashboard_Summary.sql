CREATE OR ALTER PROCEDURE [dbo].[ACD_RPT_Dashboard_Summary]
AS
    SELECT 
        (SELECT COUNT(*) FROM ACD_PRJ_ProjectGroup) AS TotalProjects,
        (SELECT COUNT(*) FROM ACD_PRJ_ProjectMeeting) AS TotalMeetings,
        (SELECT COUNT(*) FROM ACD_PRJ_ProjectGroup WHERE IsApproved = 0) AS PendingApprovals,
        (SELECT COUNT(*) FROM ACD_Student) AS TotalStudents;




CREATE OR ALTER PROCEDURE [dbo].[ACD_AUTH_Profile_SelectByID]
    @UserID INT,
    @Role NVARCHAR(50)
AS
    IF @Role IN('Staff','Admin')
    BEGIN
        SELECT 
            StaffID AS UserID,
            StaffName AS Name,
            Email,
            Phone,
            @Role AS Role
        FROM ACD_Staff
        WHERE StaffID = @UserID;
    END
    ELSE IF @Role = 'Student'
    BEGIN
        SELECT 
            StudentID AS UserID,
            StudentName AS Name,
            Email,
            Phone,
            'Student' AS Role
        FROM ACD_Student
        WHERE StudentID = @UserID;
    END
