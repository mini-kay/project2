
USE FuturePathDB;
GO

-- 13. FundingOption
CREATE TABLE dbo.FundingOption (
    FundingOptionID INT IDENTITY(1,1) PRIMARY KEY,
    FundingName VARCHAR(100) NOT NULL,
    FundingType VARCHAR(30) NOT NULL
        CHECK (FundingType IN
        ('Scholarship', 'Bursary', 'Financial Aid', 'External Funding')),
    EligibilityDescription VARCHAR(250) NOT NULL,
    RequiredDocuments VARCHAR(250) NULL,
    ClosingDate VARCHAR(10) NULL,
    ContactInfo VARCHAR(150) NULL,
    IsActive BIT NOT NULL DEFAULT 1
);

-- 14. FundingFaculty
CREATE TABLE dbo.FundingFaculty (
    FundingFacultyID INT IDENTITY(1,1) PRIMARY KEY,
    FundingOptionID INT NOT NULL,
    FacultyID INT NOT NULL,

    CONSTRAINT FK_FundingFaculty_Funding
        FOREIGN KEY (FundingOptionID)
        REFERENCES dbo.FundingOption(FundingOptionID),

    CONSTRAINT FK_FundingFaculty_Faculty
        FOREIGN KEY (FacultyID)
        REFERENCES dbo.Faculty(FacultyID),

    CONSTRAINT UQ_FundingFaculty
        UNIQUE (FundingOptionID, FacultyID)
);

-- 15. FundingProgramme
CREATE TABLE dbo.FundingProgramme (
    FundingProgrammeID INT IDENTITY(1,1) PRIMARY KEY,
    FundingOptionID INT NOT NULL,
    DegreeProgrammeID INT NOT NULL,

    CONSTRAINT FK_FundingProgramme_Funding
        FOREIGN KEY (FundingOptionID)
        REFERENCES dbo.FundingOption(FundingOptionID),

    CONSTRAINT FK_FundingProgramme_Degree
        FOREIGN KEY (DegreeProgrammeID)
        REFERENCES dbo.DegreeProgramme(DegreeProgrammeID),

    CONSTRAINT UQ_FundingProgramme
        UNIQUE (FundingOptionID, DegreeProgrammeID)
);

-- 16. UserAccount
CREATE TABLE dbo.UserAccount (
    UserAccountID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(30) NOT NULL
    CHECK (Role IN ('Learner', 'Career Advisor', 'Administrator')),
    IsActive BIT NOT NULL DEFAULT 1
);

-- 17. ExportReport
CREATE TABLE dbo.ExportReport (
    ExportReportID INT IDENTITY(1,1) PRIMARY KEY,
    AdvisorySessionID INT NOT NULL,
    DateGenerated DATETIME NOT NULL DEFAULT GETDATE(),
    ExportFormat VARCHAR(20) NOT NULL
        CHECK (ExportFormat IN ('Printed', 'Saved', 'On-screen')),

    CONSTRAINT FK_ExportReport_Session
        FOREIGN KEY (AdvisorySessionID)
        REFERENCES dbo.AdvisorySession(AdvisorySessionID)
);
GO
