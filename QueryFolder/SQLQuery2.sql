
USE FuturePathDB;
GO

-- 5. ProgrammeRequirement
CREATE TABLE dbo.ProgrammeRequirement (
    ProgrammeRequirementID INT IDENTITY(1,1) PRIMARY KEY,
    DegreeProgrammeID INT NOT NULL,
    SubjectID INT NOT NULL,
    MinimumMark INT NOT NULL
        CHECK (MinimumMark BETWEEN 0 AND 100),

    CONSTRAINT FK_ProgrammeRequirement_Degree
        FOREIGN KEY (DegreeProgrammeID)
        REFERENCES dbo.DegreeProgramme(DegreeProgrammeID),

    CONSTRAINT FK_ProgrammeRequirement_Subject
        FOREIGN KEY (SubjectID)
        REFERENCES dbo.Subject(SubjectID),

    CONSTRAINT UQ_ProgrammeRequirement
        UNIQUE (DegreeProgrammeID, SubjectID)
);

-- 6. AdvisorySession
CREATE TABLE dbo.AdvisorySession (
    AdvisorySessionID INT IDENTITY(1,1) PRIMARY KEY,
    LearnerID INT NOT NULL,
    DegreeProgrammeID INT NOT NULL,
    SessionDate DATETIME NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_AdvisorySession_Learner
        FOREIGN KEY (LearnerID)
        REFERENCES dbo.Learner(LearnerID),

    CONSTRAINT FK_AdvisorySession_Degree
        FOREIGN KEY (DegreeProgrammeID)
        REFERENCES dbo.DegreeProgramme(DegreeProgrammeID)
);

-- 7. LearnerSubject
CREATE TABLE dbo.LearnerSubject (
    LearnerSubjectID INT IDENTITY(1,1) PRIMARY KEY,
    LearnerID INT NOT NULL,
    SubjectID INT NOT NULL,
    AdvisorySessionID INT NOT NULL,
    Mark INT NOT NULL CHECK (Mark BETWEEN 0 AND 100),

    CONSTRAINT FK_LearnerSubject_Learner
        FOREIGN KEY (LearnerID)
        REFERENCES dbo.Learner(LearnerID),

    CONSTRAINT FK_LearnerSubject_Subject
        FOREIGN KEY (SubjectID)
        REFERENCES dbo.Subject(SubjectID),

    CONSTRAINT FK_LearnerSubject_Session
        FOREIGN KEY (AdvisorySessionID)
        REFERENCES dbo.AdvisorySession(AdvisorySessionID),

    CONSTRAINT UQ_LearnerSubject_Session
        UNIQUE (AdvisorySessionID, SubjectID)
);

-- 8. InterestCategory
CREATE TABLE dbo.InterestCategory (
    InterestCategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(50) NOT NULL UNIQUE
);
GO
