CREATE DATABASE FuturePathDB;
GO

USE FuturePathDB;
GO

-- 1. Learner
CREATE TABLE dbo.Learner (
    LearnerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NULL,
    LastName VARCHAR(50) NULL,
    Grade INT NOT NULL CHECK (Grade IN (11, 12)),
    School VARCHAR(100) NOT NULL,
    Province VARCHAR(50) NOT NULL
);

-- 2. Subject
CREATE TABLE dbo.Subject (
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectName VARCHAR(50) NOT NULL UNIQUE
);

-- 3. Faculty
CREATE TABLE dbo.Faculty (
    FacultyID INT IDENTITY(1,1) PRIMARY KEY,
    FacultyName VARCHAR(50) NOT NULL UNIQUE,
    IsActive BIT NOT NULL DEFAULT 1
);

-- 4. DegreeProgramme
CREATE TABLE dbo.DegreeProgramme (
    DegreeProgrammeID INT IDENTITY(1,1) PRIMARY KEY,
    FacultyID INT NOT NULL,
    ProgrammeName VARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_DegreeProgramme_Faculty
        FOREIGN KEY (FacultyID)
        REFERENCES dbo.Faculty(FacultyID)
);
GO
