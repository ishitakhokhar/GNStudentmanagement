create database GNStudentManagement

-- 1. ACD_PRJ_ProjectType
CREATE TABLE ACD_PRJ_ProjectType (
    ProjectTypeID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectTypeName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);

-- 2. ACD_Staff
CREATE TABLE ACD_Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    StaffName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15) NULL,
    Email NVARCHAR(100) NULL,
    [Password] NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);

-- 3. ACD_Student
CREATE TABLE ACD_Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15) NULL,
    Email NVARCHAR(100) NULL,
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);

-- 4. ACD_PRJ_ProjectGroup
CREATE TABLE ACD_PRJ_ProjectGroup (
    ProjectGroupID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectGroupName NVARCHAR(100) NOT NULL,
    ProjectTypeID INT NOT NULL FOREIGN KEY REFERENCES ACD_PRJ_ProjectType(ProjectTypeID),
    GuideStaffID INT NULL FOREIGN KEY REFERENCES ACD_Staff(StaffID), -- could be replaced with StaffID in future
    ProjectTitle NVARCHAR(200) NOT NULL,
    ProjectArea NVARCHAR(100) NULL,
    ProjectDescription NVARCHAR(MAX) NULL,
    AverageCPI DECIMAL(4,2) NULL,
    ConvenerStaffID INT NULL FOREIGN KEY REFERENCES ACD_Staff(StaffID),
    ExpertStaffID INT NULL FOREIGN KEY REFERENCES ACD_Staff(StaffID),
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);
ALTER TABLE ACD_PRJ_ProjectGroup
DROP COLUMN GuideStaffName;

ALTER TABLE ACD_PRJ_ProjectGroup
ADD GuideStaffID INT NULL;

ALTER TABLE ACD_PRJ_ProjectGroup
ADD CONSTRAINT FK_ProjectGroup_GuideStaff
FOREIGN KEY (GuideStaffID) REFERENCES ACD_Staff(StaffID);





-- 5. ACD_PRJ_ProjectGroupMember
CREATE TABLE ACD_PRJ_ProjectGroupMember (
    ProjectGroupMemberID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectGroupID INT NOT NULL FOREIGN KEY REFERENCES ACD_PRJ_ProjectGroup(ProjectGroupID),
    StudentID INT NOT NULL FOREIGN KEY REFERENCES ACD_Student(StudentID),
    IsGroupLeader BIT NOT NULL DEFAULT 0,
    StudentCGPA DECIMAL(4,2) NULL,
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);

-- 6. ACD_PRJ_ProjectMeeting
CREATE TABLE ACD_PRJ_ProjectMeeting (
    ProjectMeetingID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectGroupID INT NOT NULL FOREIGN KEY REFERENCES ACD_PRJ_ProjectGroup(ProjectGroupID),
    GuideStaffID INT NOT NULL FOREIGN KEY REFERENCES ACD_Staff(StaffID),
    MeetingDateTime DATETIME NOT NULL,
    MeetingPurpose NVARCHAR(200) NOT NULL,
    MeetingLocation NVARCHAR(200) NULL,
    MeetingNotes NVARCHAR(MAX) NULL,
    MeetingStatus NVARCHAR(50) NULL,
    MeetingStatusDescription NVARCHAR(200) NULL,
    MeetingStatusDatetime DATETIME NULL,
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);

-- 7. ACD_PRJ_ProjectMeetingAttendance
CREATE TABLE ACD_PRJ_ProjectMeetingAttendance (
    ProjectMeetingAttendanceID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectMeetingID INT NOT NULL FOREIGN KEY REFERENCES ACD_PRJ_ProjectMeeting(ProjectMeetingID),
    StudentID INT NOT NULL FOREIGN KEY REFERENCES ACD_Student(StudentID),
    IsPresent BIT NOT NULL DEFAULT 0,
    AttendanceRemarks NVARCHAR(200) NULL,
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);

--8. ACD_PRJ_ProjectSubmission
CREATE TABLE ACD_PRJ_ProjectSubmission (
    ProjectSubmissionID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectGroupID INT NOT NULL FOREIGN KEY REFERENCES ACD_PRJ_ProjectGroup(ProjectGroupID),
    StudentID INT NOT NULL FOREIGN KEY REFERENCES ACD_Student(StudentID),
    SubmissionLink NVARCHAR(500) NOT NULL,
    SubmissionRemarks NVARCHAR(500) NULL,
    SubmissionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Description NVARCHAR(500) NULL,
    Created DATETIME NOT NULL DEFAULT GETDATE(),
    Modified DATETIME NULL
);


CREATE TABLE ACD_UserRoles (
    UserRoleID INT IDENTITY(1,1) PRIMARY KEY,
    StaffID INT NULL FOREIGN KEY REFERENCES ACD_Staff(StaffID),
    StudentID INT NULL FOREIGN KEY REFERENCES ACD_Student(StudentID),
    RoleName NVARCHAR(50) NOT NULL
);

