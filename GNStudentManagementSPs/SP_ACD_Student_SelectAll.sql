CREATE PROCEDURE [dbo].[ACD_Student_SelectAll]
AS
    SELECT 
        [dbo].[ACD_Student].[StudentID],
        [dbo].[ACD_Student].[StudentName],
        [dbo].[ACD_Student].[Phone],
        [dbo].[ACD_Student].[Email],
        [dbo].[ACD_Student].[Description],
        [dbo].[ACD_Student].[Created],
        [dbo].[ACD_Student].[Modified]
    FROM [dbo].[ACD_Student]

CREATE PROCEDURE [dbo].[ACD_Student_SelectByID]
    @StudentID INT
AS
    SELECT 
        [dbo].[ACD_Student].[StudentID],
        [dbo].[ACD_Student].[StudentName],
        [dbo].[ACD_Student].[Phone],
        [dbo].[ACD_Student].[Email],
        [dbo].[ACD_Student].[Description],
        [dbo].[ACD_Student].[Created],
        [dbo].[ACD_Student].[Modified]
    FROM [dbo].[ACD_Student]
    WHERE [dbo].[ACD_Student].[StudentID] = @StudentID

ALTER PROCEDURE [dbo].[ACD_Student_Insert]
    @StudentName NVARCHAR(100),
    @Phone NVARCHAR(15) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Description NVARCHAR(500) = NULL,
	@Password NVARCHAR(100) = NULL
AS

    INSERT INTO [dbo].[ACD_Student] (
        [dbo].[ACD_Student].[StudentName],
        [dbo].[ACD_Student].[Phone],
        [dbo].[ACD_Student].[Email],
        [dbo].[ACD_Student].[Description],
		[dbo].[ACD_Student].[Password],
		[dbo].[ACD_Student].[Created]
    )
    VALUES (
        @StudentName,
        @Phone,
        @Email,
        @Description,
		@Password,
		GETDATE()
    )


CREATE PROCEDURE [dbo].[ACD_Student_Update]
    @StudentID INT,
    @StudentName NVARCHAR(100),
    @Phone NVARCHAR(15) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Description NVARCHAR(500) = NULL
AS
    UPDATE [dbo].[ACD_Student]
    SET 
        [dbo].[ACD_Student].[StudentName] = @StudentName,
        [dbo].[ACD_Student].[Phone] = @Phone,
        [dbo].[ACD_Student].[Email] = @Email,
        [dbo].[ACD_Student].[Description] = @Description,
        [dbo].[ACD_Student].[Modified] = GETDATE()
    WHERE [dbo].[ACD_Student].[StudentID] = @StudentID

CREATE PROCEDURE [dbo].[ACD_Student_Delete]
    @StudentID INT
AS
    DELETE FROM [dbo].[ACD_Student]
    WHERE [dbo].[ACD_Student].[StudentID] = @StudentID

	-- login
	ALTER PROCEDURE [dbo].[ACD_Student_Login]
    @Email NVARCHAR(100),
    @Password NVARCHAR(200)
AS
    SELECT 
		[dbo].[ACD_Student].[StudentID],
        [dbo].[ACD_Student].[StudentName],
        [dbo].[ACD_Student].[Email]
   FROM [dbo].[ACD_Student]
    WHERE 
        [dbo].[ACD_Student].[Email] = @Email
        AND [dbo].[ACD_Student].[Password] = @Password
SELECT * FROM ACD_Student;
DELETE FROM ACD_Student WHERE StudentID in (4,5,6,7,8);

INSERT INTO ACD_Student (StudentName, Phone, Email, Description)
VALUES ('Aarav Sharma', '9998887771', 'aarav@student.edu', 'Team Leader'),
       ('Diya Patel', '9998887772', 'diya@student.edu', 'Team Member'),
       ('Karan Verma', '9998887773', 'karan@student.edu', 'Team Member');
