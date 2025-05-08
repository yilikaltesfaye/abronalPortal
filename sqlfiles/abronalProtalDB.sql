-- Database fore Abronal Internship Application Portal
-- CREATE DATABASE abronalPortalDB

-- use abronalPortalDB

-- CREATE TABLE UserTypes(
--     UserTypesId INT PRIMARY KEY IDENTITY(1,1),
--     TypeName NVARCHAR(50) NOT NULL UNIQUE
-- );

-- INSERT INTO UserTypes (TypeName) VALUES ('user'), ('admin');

-- EXEC sp_rename 'UserTypes.UserTypesId', 'UserTypeId', 'COLUMN';

-- CREATE TABLE Users (
--     UserId INT PRIMARY KEY IDENTITY(1,1),
--     Email NVARCHAR(100) NOT NULL UNIQUE,
--     PasswordHash NVARCHAR(255) NOT NULL,
--     ProfilePicturePath NVARCHAR(255),
--     GivenName NVARCHAR(50) NOT NULL UNIQUE,
--     FatherName NVARCHAR(50) NOT NULL UNIQUE,
--     GrandFatherName NVARCHAR(50) NOT NULL UNIQUE,
--     AccountCreatedAt DATETIME DEFAULT GETDATE(),
--     UserTypeID INT FOREIGN KEY REFERENCES UserTypes(UserTypeId) DEFAULT 1,
--     IsActive BIT DEFAULT 1,
--     LastLogin DATETIME,
-- )
-- CREATE TABLE ApplicationStatus (
--     StatusId INT PRIMARY KEY IDENTITY(1,1),
--     StatusName NVARCHAR(20) NOT NULL UNIQUE
-- );

-- INSERT INTO ApplicationStatus (StatusName) VALUES
-- ('NotSubmitted'),
-- ('Submitted'),
-- ('UnderReview'),
-- ('Approved'),
-- ('Rejected');

-- CREATE TABLE Applications (
--     ApplicationId INT PRIMARY KEY IDENTITY(1,1),
--     UserId INT FOREIGN KEY REFERENCES Users(UserId),
--     CurrentStatusId INT FOREIGN KEY REFERENCES ApplicationStatus(StatusId) DEFAULT 1,
--     Designation NVARCHAR(100),
--     Bio NVARCHAR(500),
--     PhoneNumber NVARCHAR(20),
--     Address NVARCHAR(100),
--     WillingToRelocate BIT DEFAULT 1, 
--     University NVARCHAR(100),
--     CurrentYear NVARCHAR(20),
--     CGPA FLOAT,
--     Major NVARCHAR(100),
--     Skills NVARCHAR(500),
--     ResumePath NVARCHAR(255),
--     GitHubProfileLink NVARCHAR(200),
--     LinkedInProfileLink NVARCHAR(200),
--     LeetCodeProfileLink NVARCHAR(200),
--     PortfolioSiteLink NVARCHAR(200),
--     PastProjects NVARCHAR(MAX), -- json of past project
--     CoverLetter NVARCHAR(1000),
--     CreatedDate DATETIME DEFAULT GETDATE(),
--     LastUpdated DATETIME DEFAULT GETDATE()
-- );

-- ALTER TABLE Applications
-- ALTER COLUMN CGPA DECIMAL(3,2)

-- CREATE TABLE TestProjectTemplates (
--     TemplateId INT PRIMARY KEY IDENTITY(1,1),
--     Title NVARCHAR(200) NOT NULL,
--     Description NVARCHAR(1000) NOT NULL,
--     Features NVARCHAR(MAX),  -- json
--     TechnologiesToUse NVARCHAR(MAX),  -- json
--     OptionalLibraries NVARCHAR(MAX),  -- json
--     CreatedByAdminId INT FOREIGN KEY REFERENCES Users(UserId),
--     CreatedAt DATETIME DEFAULT GETDATE()
-- );

-- CREATE TABLE ApplicantTestProjects (
--     ApplicantTestProjectId INT PRIMARY KEY IDENTITY(1,1),
--     ApplicationId INT UNIQUE FOREIGN KEY REFERENCES Applications(ApplicationId),
--     TemplateId INT FOREIGN KEY REFERENCES TestProjectTemplates(TemplateId),  
--     Title NVARCHAR(200) NOT NULL,
--     Description NVARCHAR(1000) NOT NULL,
--     CustomFeatures NVARCHAR(MAX), 
--     OptionalLibraries NVARCHAR(MAX), 
--     AssignedDate DATETIME DEFAULT GETDATE(),
--     Deadline DATETIME,
--     GitHubRepoUrl NVARCHAR(200),  -- The applicant's GitHub submission link
--     LiveSiteUrl NVARCHAR(200),  -- The applicant's GitHub submission link
--     SubmittedDate DATETIME,  -- When they submit the project
--     CurrentStatusId INT FOREIGN KEY REFERENCES ApplicationStatus(StatusId) DEFAULT 1  
-- );


-- CREATE TABLE Decisions (
--     DecisionId INT PRIMARY KEY IDENTITY(1,1),  -- Unique decision identifier
--     ApplicationId INT FOREIGN KEY REFERENCES Applications(ApplicationId),  
--     AdminId INT FOREIGN KEY REFERENCES Users(UserId),  
--     DecisionDate DATETIME DEFAULT GETDATE(),  
--     NewStatusId INT FOREIGN KEY REFERENCES ApplicationStatus(StatusId),  
--     Description NVARCHAR(1000) NOT NULL, 
--     IsTestProjectAssigned BIT DEFAULT 0,  
--     TestProjectRequirements NVARCHAR(1000)  
-- );

-- GO
-- CREATE TRIGGER UpdateApplicationStatusAfterDecision
-- ON Decisions
-- AFTER INSERT
-- AS
-- BEGIN
--     DECLARE @NewStatusId INT;
--     DECLARE @ApplicationId INT;

--     -- Get the inserted NewStatusId and ApplicationId from the 'inserted' pseudo table
--     SELECT @NewStatusId = NewStatusId, @ApplicationId = ApplicationId FROM inserted;

--     -- Update the application's status to the new one
--     UPDATE Applications
--     SET CurrentStatusId = @NewStatusId
--     WHERE ApplicationId = @ApplicationId;
-- END;
-- GO