CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroup_SelectAll]
AS
SELECT
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectTypeID],
    [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
    [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID],
    [GuideStaff].[StaffName] AS [GuideStaffName],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectTitle],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectArea],
    [dbo].[ACD_PRJ_ProjectGroup].[ProjectDescription],
    [dbo].[ACD_PRJ_ProjectGroup].[AverageCPI],
    [dbo].[ACD_PRJ_ProjectGroup].[ConvenerStaffID],
    [ConvenerStaff].[StaffName] AS [ConvenerStaffName],
    [dbo].[ACD_PRJ_ProjectGroup].[ExpertStaffID],
    [ExpertStaff].[StaffName] AS [ExpertStaffName],
    [dbo].[ACD_PRJ_ProjectGroup].[Description],
    [dbo].[ACD_PRJ_ProjectGroup].[Created],
    [dbo].[ACD_PRJ_ProjectGroup].[Modified]
FROM [dbo].[ACD_PRJ_ProjectGroup]
INNER JOIN [dbo].[ACD_PRJ_ProjectType]
    ON [dbo].[ACD_PRJ_ProjectGroup].[ProjectTypeID] = [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID]
LEFT JOIN [dbo].[ACD_Staff] AS [GuideStaff]
    ON [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID] = [GuideStaff].[StaffID]
LEFT JOIN [dbo].[ACD_Staff] AS [ConvenerStaff]
    ON [dbo].[ACD_PRJ_ProjectGroup].[ConvenerStaffID] = [ConvenerStaff].[StaffID]
LEFT JOIN [dbo].[ACD_Staff] AS [ExpertStaff]
    ON [dbo].[ACD_PRJ_ProjectGroup].[ExpertStaffID] = [ExpertStaff].[StaffID];








CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroup_SelectByID]
    @ProjectGroupID INT
AS
BEGIN
    SELECT 
        ProjectGroupID,
        ProjectGroupName,
        ProjectTypeID,
        GuideStaffID,
        ProjectTitle,
        ProjectArea,
        ProjectDescription,
        AverageCPI,
        ConvenerStaffID,
        ExpertStaffID,
        Description,
        Created,
        Modified
    FROM ACD_PRJ_ProjectGroup
    WHERE ProjectGroupID = @ProjectGroupID;
END




CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroup_Insert]
    @ProjectGroupName NVARCHAR(100),
    @ProjectTypeID INT,
    @GuideStaffID INT = NULL,
    @ProjectTitle NVARCHAR(200),
    @ProjectArea NVARCHAR(100) = NULL,
    @ProjectDescription NVARCHAR(MAX) = NULL,
    @AverageCPI DECIMAL(4,2) = NULL,
    @ConvenerStaffID INT = NULL,
    @ExpertStaffID INT = NULL,
    @Description NVARCHAR(500) = NULL
AS
INSERT INTO [dbo].[ACD_PRJ_ProjectGroup] (
    [ProjectGroupName],
    [ProjectTypeID],
    [GuideStaffID],
    [ProjectTitle],
    [ProjectArea],
    [ProjectDescription],
    [AverageCPI],
    [ConvenerStaffID],
    [ExpertStaffID],
    [Description],
    [Created]
)
VALUES (
    @ProjectGroupName,
    @ProjectTypeID,
    @GuideStaffID,
    @ProjectTitle,
    @ProjectArea,
    @ProjectDescription,
    @AverageCPI,
    @ConvenerStaffID,
    @ExpertStaffID,
    @Description,
    GETDATE()
);





CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroup_Update]
    @ProjectGroupID INT,
    @ProjectGroupName NVARCHAR(100),
    @ProjectTypeID INT,
    @GuideStaffID INT = NULL,
    @ProjectTitle NVARCHAR(200),
    @ProjectArea NVARCHAR(100) = NULL,
    @ProjectDescription NVARCHAR(MAX) = NULL,
    @AverageCPI DECIMAL(4,2) = NULL,
    @ConvenerStaffID INT = NULL,
    @ExpertStaffID INT = NULL,
    @Description NVARCHAR(500) = NULL
AS
UPDATE [dbo].[ACD_PRJ_ProjectGroup]
SET
    [ProjectGroupName] = @ProjectGroupName,
    [ProjectTypeID] = @ProjectTypeID,
    [GuideStaffID] = @GuideStaffID,
    [ProjectTitle] = @ProjectTitle,
    [ProjectArea] = @ProjectArea,
    [ProjectDescription] = @ProjectDescription,
    [AverageCPI] = @AverageCPI,
    [ConvenerStaffID] = @ConvenerStaffID,
    [ExpertStaffID] = @ExpertStaffID,
    [Description] = @Description,
    [Modified] = GETDATE()
WHERE [ProjectGroupID] = @ProjectGroupID;




CREATE PROCEDURE [dbo].[ACD_PRJ_ProjectGroup_Delete]
    @ProjectGroupID INT
AS
BEGIN
    DELETE FROM [dbo].[ACD_PRJ_ProjectGroup]
    WHERE [ProjectGroupID] = @ProjectGroupID;
END


select * from ACD_PRJ_ProjectGroup

INSERT INTO ACD_PRJ_ProjectGroup 
(ProjectGroupName, ProjectTypeID, GuideStaffID, ProjectTitle, ProjectArea, ProjectDescription, AverageCPI, ConvenerStaffID, ExpertStaffID, Description)
VALUES 
('AI Team', 1006, 15, 'AI-Based Disease Detection', 'Artificial Intelligence', 'Detecting diseases using AI models', 8.45, 8, 11, 'Approved by guide');


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroup_DropDown]
AS
    SELECT 
        [ProjectGroupID],
        [ProjectGroupName]
    FROM [dbo].[ACD_PRJ_ProjectGroup]
    ORDER BY [ProjectGroupName];

