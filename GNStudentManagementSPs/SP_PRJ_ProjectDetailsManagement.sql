ALTER TABLE ACD_PRJ_ProjectGroup
ADD ProposalDoc NVARCHAR(500) NULL,            
    ProposalStatus NVARCHAR(50) NULL,          
    IsApproved BIT DEFAULT 0,                    
    ApprovedBy INT NULL FOREIGN KEY REFERENCES ACD_Staff(StaffID),
    ApprovedDate DATETIME NULL;


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectGroup_Approve]
    @ProjectGroupID INT,
    @ApprovedBy INT
AS
    UPDATE ACD_PRJ_ProjectGroup
    SET IsApproved = 1,
        ApprovedBy = @ApprovedBy,
        ApprovedDate = GETDATE(),
        Modified = GETDATE()
    WHERE ProjectGroupID = @ProjectGroupID;


CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectProposal_Submit]
    @ProjectGroupID INT,
    @ProposalDoc NVARCHAR(500),
    @Description NVARCHAR(500) = NULL
AS
    UPDATE ACD_PRJ_ProjectGroup
    SET ProposalDoc = @ProposalDoc,
        ProposalStatus = 'Pending',
        Description = @Description,
        Modified = GETDATE()
    WHERE ProjectGroupID = @ProjectGroupID;




CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectProposal_Approve]
    @ProjectGroupID INT,
    @ProposalStatus NVARCHAR(50),    
    @ApprovedBy INT
AS
    UPDATE ACD_PRJ_ProjectGroup
    SET ProposalStatus = @ProposalStatus,
        ApprovedBy = @ApprovedBy,
        ApprovedDate = GETDATE(),
        Modified = GETDATE()
    WHERE ProjectGroupID = @ProjectGroupID;



CREATE OR ALTER PROCEDURE [dbo].[ACD_PRJ_ProjectDetails_SelectByGroup]
@ProjectGroupID INT
AS
SELECT
[dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID],
[dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupName],
[dbo].[ACD_PRJ_ProjectGroup].[ProjectTitle],
[dbo].[ACD_PRJ_ProjectGroup].[ProjectArea],
[dbo].[ACD_PRJ_ProjectGroup].[ProjectDescription],
[dbo].[ACD_PRJ_ProjectGroup].[AverageCPI],
[dbo].[ACD_PRJ_ProjectGroup].[ProposalDoc],
[dbo].[ACD_PRJ_ProjectGroup].[ProposalStatus],
[dbo].[ACD_PRJ_ProjectGroup].[IsApproved],
[dbo].[ACD_PRJ_ProjectGroup].[ApprovedBy],
approver.[StaffName] AS ApprovedByName,
[dbo].[ACD_PRJ_ProjectGroup].[ApprovedDate],
[dbo].[ACD_PRJ_ProjectType].[ProjectTypeName],
[dbo].[ACD_Staff].[StaffName] AS GuideStaffName,
[dbo].[ACD_Staff].[Email] AS GuideEmail,
[dbo].[ACD_Staff].[Phone] AS GuidePhone
FROM [dbo].[ACD_PRJ_ProjectGroup]
INNER JOIN [dbo].[ACD_PRJ_ProjectType]
ON [dbo].[ACD_PRJ_ProjectGroup].[ProjectTypeID] = [dbo].[ACD_PRJ_ProjectType].[ProjectTypeID]
LEFT JOIN [dbo].[ACD_Staff]
ON [dbo].[ACD_PRJ_ProjectGroup].[GuideStaffID] = [dbo].[ACD_Staff].[StaffID]
LEFT JOIN [dbo].[ACD_Staff] approver
ON [dbo].[ACD_PRJ_ProjectGroup].[ApprovedBy] = approver.[StaffID]
WHERE [dbo].[ACD_PRJ_ProjectGroup].[ProjectGroupID] = @ProjectGroupID;




EXEC dbo.ACD_PRJ_ProjectProposal_Submit
    @ProjectGroupID = 1,
    @ProposalDoc = 'https://github.com/yourrepo/project',
    @Description = 'Initial project submission';

SELECT ProjectGroupID, ProposalDoc, ProposalStatus, Description, Modified
FROM dbo.ACD_PRJ_ProjectGroup
WHERE ProjectGroupID = 4;

SELECT ProjectGroupID, ProposalStatus, ApprovedBy, ApprovedDate
FROM dbo.ACD_PRJ_ProjectGroup
WHERE ProjectGroupID = 3;

SELECT ProjectGroupID, IsApproved, ApprovedBy, ApprovedDate
FROM dbo.ACD_PRJ_ProjectGroup
WHERE ProjectGroupID = 3;

EXEC dbo.ACD_PRJ_ProjectDetails_SelectByGroup @ProjectGroupID = 4;



SELECT TOP 10 
    ProjectGroupID, 
    ProposalDoc, 
    ProposalStatus, 
    IsApproved, 
    ApprovedBy, 
    ApprovedDate, 
    Modified 
FROM dbo.ACD_PRJ_ProjectGroup;


