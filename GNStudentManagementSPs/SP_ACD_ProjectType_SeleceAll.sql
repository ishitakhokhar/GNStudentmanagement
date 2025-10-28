CREATE PROCEDURE [dbo].[ACD_PRJ_ProjectType_SelectAll]
AS
    SELECT 
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID],
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
        [dbo].[ACD_PRJ_ProjectType].[Description],
        [dbo].[ACD_PRJ_ProjectType].[Created],
        [dbo].[ACD_PRJ_ProjectType].[Modified]
    FROM [dbo].[ACD_PRJ_ProjectType]


CREATE PROCEDURE [dbo].[ACD_PRJ_ProjectType_SelectByID]
    @ProjectTypeID INT
AS
    SELECT 
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID],
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
        [dbo].[ACD_PRJ_ProjectType].[Description],
        [dbo].[ACD_PRJ_ProjectType].[Created],
        [dbo].[ACD_PRJ_ProjectType].[Modified]
    FROM [dbo].[ACD_PRJ_ProjectType]
    WHERE [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID] = @ProjectTypeID;

CREATE PROCEDURE [dbo].[ACD_PRJ_ProjectType_Insert]
    @ProjectTypeName NVARCHAR(50),
    @Description NVARCHAR(500)
AS
    INSERT INTO [dbo].[ACD_PRJ_ProjectType] (
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
        [dbo].[ACD_PRJ_ProjectType].[Description],
        [dbo].[ACD_PRJ_ProjectType].[Created]
    )
    VALUES (
        @ProjectTypeName,
        @Description,
        GETDATE()
    );


CREATE PROCEDURE [dbo].[ACD_PRJ_ProjectType_Update]
    @ProjectTypeID INT,
    @ProjectTypeName NVARCHAR(50),
    @Description NVARCHAR(500)
AS
    UPDATE [dbo].[ACD_PRJ_ProjectType]
    SET 
        [dbo].[ACD_PRJ_ProjectType].[ProjectTypeName] = @ProjectTypeName,
        [dbo].[ACD_PRJ_ProjectType].[Description] = @Description,
        [dbo].[ACD_PRJ_ProjectType].[Modified] = GETDATE()
    WHERE [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID] = @ProjectTypeID;



CREATE PROCEDURE [dbo].[ACD_PRJ_ProjectType_Delete]
    @ProjectTypeID INT
AS
    DELETE FROM [dbo].[ACD_PRJ_ProjectType]
    WHERE [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID] = @ProjectTypeID;

	select * from ACD_PRJ_ProjectType


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectType_DropDown]
AS
    SELECT 
        [ProjectTypeID],
        [ProjectTypeName]
    FROM [dbo].[ACD_PRJ_ProjectType]
    ORDER BY [ProjectTypeName];


select * from ACD_PRJ_ProjectType

INSERT INTO ACD_PRJ_ProjectType (ProjectTypeName, Description)
VALUES ('Major Project', 'Final year capstone project'),
       ('Minor Project', 'Mid-semester short-term project');




