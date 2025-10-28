CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectSubmission_SelectAll]
AS
SELECT 
    [dbo].[ACD_PRJ_ProjectSubmission].[ProjectSubmissionID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
    [dbo].[ACD_Student].[StudentID],
    [dbo].[ACD_Student].[StudentName],
    [dbo].[ACD_PRJ_ProjectSubmission].[SubmissionLink],
    [dbo].[ACD_PRJ_ProjectSubmission].[SubmissionRemarks],
    [dbo].[ACD_PRJ_ProjectSubmission].[SubmissionDate],
    [dbo].[ACD_PRJ_ProjectSubmission].[Description],
    [dbo].[ACD_PRJ_ProjectSubmission].[Created],
    [dbo].[ACD_PRJ_ProjectSubmission].[Modified]
FROM [dbo].[ACD_PRJ_ProjectSubmission]
INNER JOIN [dbo].[ACD_PRJ_ProjectGroup]
    ON [dbo].[ACD_PRJ_ProjectSubmission].[ProjectGroupID] = [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID]
INNER JOIN [dbo].[ACD_Student]
    ON [dbo].[ACD_PRJ_ProjectSubmission].[StudentID] = [dbo].[ACD_Student].[StudentID];


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectSubmission_SelectByID]
    @ProjectSubmissionID INT
AS
SELECT 
    [dbo].[ACD_PRJ_ProjectSubmission].[ProjectSubmissionID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
    [dbo].[ACD_Student].[StudentID],
    [dbo].[ACD_Student].[StudentName],
    [dbo].[ACD_PRJ_ProjectSubmission].[SubmissionLink],
    [dbo].[ACD_PRJ_ProjectSubmission].[SubmissionRemarks],
    [dbo].[ACD_PRJ_ProjectSubmission].[SubmissionDate],
    [dbo].[ACD_PRJ_ProjectSubmission].[Description],
    [dbo].[ACD_PRJ_ProjectSubmission].[Created],
    [dbo].[ACD_PRJ_ProjectSubmission].[Modified]
FROM [dbo].[ACD_PRJ_ProjectSubmission]
INNER JOIN [dbo].[ACD_PRJ_ProjectGroup]
    ON [dbo].[ACD_PRJ_ProjectSubmission].[ProjectGroupID] = [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID]
INNER JOIN [dbo].[ACD_Student]
    ON [dbo].[ACD_PRJ_ProjectSubmission].[StudentID] = [dbo].[ACD_Student].[StudentID]
WHERE [dbo].[ACD_PRJ_ProjectSubmission].[ProjectSubmissionID] = @ProjectSubmissionID;


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectSubmission_Insert]
    @ProjectGroupID INT,
    @StudentID INT,
    @SubmissionLink NVARCHAR(500),
    @SubmissionRemarks NVARCHAR(500) = NULL,
    @Description NVARCHAR(500) = NULL
AS
INSERT INTO [dbo].[ACD_PRJ_ProjectSubmission] (
    [ProjectGroupID],
    [StudentID],
    [SubmissionLink],
    [SubmissionRemarks],
    [Description],
    [SubmissionDate],
    [Created]
)
VALUES (
    @ProjectGroupID,
    @StudentID,
    @SubmissionLink,
    @SubmissionRemarks,
    @Description,
    GETDATE(),
    GETDATE()
);


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectSubmission_Update]
    @ProjectSubmissionID INT,
    @ProjectGroupID INT,
    @StudentID INT,
    @SubmissionLink NVARCHAR(500),
    @SubmissionRemarks NVARCHAR(500) = NULL,
    @Description NVARCHAR(500) = NULL
AS
UPDATE [dbo].[ACD_PRJ_ProjectSubmission]
SET
    [ProjectGroupID] = @ProjectGroupID,
    [StudentID] = @StudentID,
    [SubmissionLink] = @SubmissionLink,
    [SubmissionRemarks] = @SubmissionRemarks,
    [Description] = @Description,
    [Modified] = GETDATE()
WHERE [dbo].[ACD_PRJ_ProjectSubmission].[ProjectSubmissionID] = @ProjectSubmissionID;


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectSubmission_Delete]
    @ProjectSubmissionID INT
AS
DELETE FROM [dbo].[ACD_PRJ_ProjectSubmission]
WHERE [dbo].[ACD_PRJ_ProjectSubmission].[ProjectSubmissionID] = @ProjectSubmissionID;


INSERT INTO [dbo].[ACD_PRJ_ProjectSubmission]
(
    [ProjectGroupID],
    [StudentID],
    [SubmissionLink],
    [SubmissionRemarks],
    [Description]
)
VALUES
(3, 9, 'https://github.com/ishitakhokhar/DataFetch', 'Initial submission', 'Submitted by group 2');


select * from ACD_PRJ_ProjectSubmission