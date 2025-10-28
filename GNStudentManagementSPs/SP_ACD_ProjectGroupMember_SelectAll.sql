CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroupMember_SelectAll]
AS
SELECT
    [dbo].[ACD_PRJ_ProjectGroupMember].[ProjectGroupMemberID],
    [dbo].[ACD_PRJ_ProjectGroupMember].[ProjectGroupID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
    [dbo].[ACD_PRJ_ProjectGroupMember].[StudentID],
    [dbo].[ACD_Student].[StudentName],
    [dbo].[ACD_PRJ_ProjectGroupMember].[IsGroupLeader],
    [dbo].[ACD_PRJ_ProjectGroupMember].[StudentCGPA],
    [dbo].[ACD_PRJ_ProjectGroupMember].[Description],
    [dbo].[ACD_PRJ_ProjectGroupMember].[Created],
    [dbo].[ACD_PRJ_ProjectGroupMember].[Modified]
FROM [dbo].[ACD_PRJ_ProjectGroupMember]
INNER JOIN [dbo].[ACD_PRJ_ProjectGroup]
    ON [dbo].[ACD_PRJ_ProjectGroupMember].[ProjectGroupID] = [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID]
INNER JOIN [dbo].[ACD_Student]
    ON [dbo].[ACD_PRJ_ProjectGroupMember].[StudentID] = [dbo].[ACD_Student].[StudentID];


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroupMember_SelectByID]
    @ProjectGroupMemberID INT
AS
    SELECT 
        [ProjectGroupMemberID],
        [ProjectGroupID],
        [StudentID],
        [IsGroupLeader],
        [StudentCGPA],
        [Description],
        [Created],
        [Modified]
    FROM [dbo].[ACD_PRJ_ProjectGroupMember]
    WHERE [ProjectGroupMemberID] = @ProjectGroupMemberID;




CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroupMember_Insert]
    @ProjectGroupID INT,
    @StudentID INT,
    @IsGroupLeader BIT = 0,
    @StudentCGPA DECIMAL(4,2) = NULL,
    @Description NVARCHAR(500) = NULL
AS
INSERT INTO [dbo].[ACD_PRJ_ProjectGroupMember] (
    [ProjectGroupID],
    [StudentID],
    [IsGroupLeader],
    [StudentCGPA],
    [Description],
    [Created]
)
VALUES (
    @ProjectGroupID,
    @StudentID,
    @IsGroupLeader,
    @StudentCGPA,
    @Description,
    GETDATE()
);



CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroupMember_Update]
    @ProjectGroupMemberID INT,
    @ProjectGroupID INT,
    @StudentID INT,
    @IsGroupLeader BIT = 0,
    @StudentCGPA DECIMAL(4,2) = NULL,
    @Description NVARCHAR(500) = NULL
AS
UPDATE [dbo].[ACD_PRJ_ProjectGroupMember]
SET
    [ProjectGroupID] = @ProjectGroupID,
    [StudentID] = @StudentID,
    [IsGroupLeader] = @IsGroupLeader,
    [StudentCGPA] = @StudentCGPA,
    [Description] = @Description,
    [Modified] = GETDATE()
WHERE [ProjectGroupMemberID] = @ProjectGroupMemberID;


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroupMember_Delete]
    @ProjectGroupMemberID INT
AS
BEGIN
    DELETE FROM [dbo].[ACD_PRJ_ProjectGroupMember]
    WHERE [ProjectGroupMemberID] = @ProjectGroupMemberID;
END

INSERT INTO ACD_PRJ_ProjectGroupMember 
(ProjectGroupID, StudentID, IsGroupLeader, StudentCGPA, Description)
VALUES 
(1010, 2011, 1, 8.90, 'Team leader')


select * from ACD_PRJ_ProjectGroupMember


