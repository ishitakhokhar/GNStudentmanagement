CREATE PROCEDURE [dbo].[ACD_Staff_SelectAll]
AS
    SELECT 
        [dbo].[ACD_Staff].[StaffID],
        [dbo].[ACD_Staff].[StaffName],
        [dbo].[ACD_Staff].[Phone],
        [dbo].[ACD_Staff].[Email],
        [dbo].[ACD_Staff].[Password],
        [dbo].[ACD_Staff].[Description],
        [dbo].[ACD_Staff].[Created],
        [dbo].[ACD_Staff].[Modified]
    FROM [dbo].[ACD_Staff];

CREATE PROCEDURE [dbo].[ACD_Staff_SelectByID]
    @StaffID INT
AS
    SELECT 
        [dbo].[ACD_Staff].[StaffID],
        [dbo].[ACD_Staff].[StaffName],
        [dbo].[ACD_Staff].[Phone],
        [dbo].[ACD_Staff].[Email],
        [dbo].[ACD_Staff].[Password],
        [dbo].[ACD_Staff].[Description],
        [dbo].[ACD_Staff].[Created],
        [dbo].[ACD_Staff].[Modified]
    FROM [dbo].[ACD_Staff]
    WHERE [dbo].[ACD_Staff].[StaffID] = @StaffID;

ALTER PROCEDURE [dbo].[ACD_Staff_Insert]
    @StaffName NVARCHAR(100),
    @Phone NVARCHAR(15),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100),
    @Description NVARCHAR(500)
AS
    INSERT INTO [dbo].[ACD_Staff] (
        [dbo].[ACD_Staff].[StaffName],
        [dbo].[ACD_Staff].[Phone],
        [dbo].[ACD_Staff].[Email],
        [dbo].[ACD_Staff].[Password],
        [dbo].[ACD_Staff].[Description],
		[dbo].[ACD_Staff].[Created]
    )
    VALUES (
        @StaffName,
        @Phone,
        @Email,
        @Password,
        @Description,
		GETDATE()
    );


CREATE PROCEDURE [dbo].[ACD_Staff_Update]
    @StaffID INT,
    @StaffName NVARCHAR(100),
    @Phone NVARCHAR(15),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100),
    @Description NVARCHAR(500)
AS
    UPDATE [dbo].[ACD_Staff]
    SET 
        [dbo].[ACD_Staff].[StaffName] = @StaffName,
        [dbo].[ACD_Staff].[Phone] = @Phone,
        [dbo].[ACD_Staff].[Email] = @Email,
        [dbo].[ACD_Staff].[Password] = @Password,
        [dbo].[ACD_Staff].[Description] = @Description,
        [dbo].[ACD_Staff].[Modified] = GETDATE()
    WHERE [dbo].[ACD_Staff].[StaffID] = @StaffID;


CREATE PROCEDURE [dbo].[ACD_Staff_Delete]
    @StaffID INT
AS
    DELETE FROM [dbo].[ACD_Staff]
    WHERE [dbo].[ACD_Staff].[StaffID] = @StaffID;


	-- login
	CREATE OR ALTER PROCEDURE [dbo].[ACD_Staff_Login]
    @Email NVARCHAR(100),
    @Password NVARCHAR(200)
AS
    SELECT 
		[dbo].[ACD_Staff].[StaffID],
        [dbo].[ACD_Staff].[StaffName],
        [dbo].[ACD_Staff].[Email],
		[dbo].[ACD_Staff].[Description]
   FROM [dbo].[ACD_Staff]
    WHERE 
        [dbo].[ACD_Staff].[Email] = @Email
        AND [dbo].[ACD_Staff].[Password] = @Password



INSERT INTO ACD_Staff (StaffName, Email, Password, Description,Phone)
VALUES ('Ishita Khokhar', 'ishita@college.edu', '123','Staff',1234567890);

select * from ACD_Staff
delete from ACD_Staff where StaffID=4

INSERT INTO ACD_Staff (StaffName, Email, Password, Description,Phone)
VALUES ('Ishita', 'ishita@gmail.com', 'Admin@123','Admin',1234567880);

CREATE OR ALTER PROCEDURE [dbo].[ACD_Staff_DropDown]
AS
    SELECT 
        [StaffID],
        [StaffName]
    FROM [dbo].[ACD_Staff]
    ORDER BY [StaffName];


INSERT INTO ACD_Staff (StaffName, Phone, Email, [Password], Description)
VALUES ('Dr. Ishita Khokhar', '9876543210', 'ishita@college.edu', '12345', 'Guide - AI'),
       ('Prof. Rohan Mehta', '8765432109', 'rohan@college.edu', '12345', 'Expert - Cloud');





