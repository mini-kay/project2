
USE FuturePathDB;
GO

-- 9. InterestQuestion
CREATE TABLE dbo.InterestQuestion (
    InterestQuestionID INT IDENTITY(1,1) PRIMARY KEY,
    InterestCategoryID INT NOT NULL,
    QuestionText VARCHAR(250) NOT NULL,

    CONSTRAINT FK_InterestQuestion_Category
        FOREIGN KEY (InterestCategoryID)
        REFERENCES dbo.InterestCategory(InterestCategoryID)
);

-- 10. LearnerInterestResponse
CREATE TABLE dbo.LearnerInterestResponse (
    LearnerInterestResponseID INT IDENTITY(1,1) PRIMARY KEY,
    LearnerID INT NOT NULL,
    InterestQuestionID INT NOT NULL,
    AdvisorySessionID INT NOT NULL,
    ResponseValue INT NOT NULL
        CHECK (ResponseValue BETWEEN 1 AND 5),

    CONSTRAINT FK_InterestResponse_Learner
        FOREIGN KEY (LearnerID)
        REFERENCES dbo.Learner(LearnerID),

    CONSTRAINT FK_InterestResponse_Question
        FOREIGN KEY (InterestQuestionID)
        REFERENCES dbo.InterestQuestion(InterestQuestionID),

    CONSTRAINT FK_InterestResponse_Session
        FOREIGN KEY (AdvisorySessionID)
        REFERENCES dbo.AdvisorySession(AdvisorySessionID),

    CONSTRAINT UQ_InterestResponse_SessionQuestion
        UNIQUE (AdvisorySessionID, InterestQuestionID)
);

-- 11. DegreeInterestMapping
CREATE TABLE dbo.DegreeInterestMapping (
    DegreeInterestMappingID INT IDENTITY(1,1) PRIMARY KEY,
    DegreeProgrammeID INT NOT NULL,
    InterestCategoryID INT NOT NULL,
    Weight INT NOT NULL DEFAULT 1
        CHECK (Weight BETWEEN 1 AND 10),

    CONSTRAINT FK_DegreeInterest_Degree
        FOREIGN KEY (DegreeProgrammeID)
        REFERENCES dbo.DegreeProgramme(DegreeProgrammeID),

    CONSTRAINT FK_DegreeInterest_Category
        FOREIGN KEY (InterestCategoryID)
        REFERENCES dbo.InterestCategory(InterestCategoryID),

    CONSTRAINT UQ_DegreeInterest_Mapping
        UNIQUE (DegreeProgrammeID, InterestCategoryID)
);

-- 12. RecommendationResult
CREATE TABLE dbo.RecommendationResult (
    RecommendationResultID INT IDENTITY(1,1) PRIMARY KEY,
    AdvisorySessionID INT NOT NULL,
    DegreeProgrammeID INT NOT NULL,
    SubjectMatchScore INT NOT NULL
        CHECK (SubjectMatchScore BETWEEN 0 AND 100),
    MarkMatchScore INT NOT NULL
        CHECK (MarkMatchScore BETWEEN 0 AND 100),
    InterestMatchScore INT NOT NULL
        CHECK (InterestMatchScore BETWEEN 0 AND 100),
    FacultyPreferenceScore INT NOT NULL
        CHECK (FacultyPreferenceScore BETWEEN 0 AND 100),
    OverallScore INT NOT NULL
        CHECK (OverallScore BETWEEN 0 AND 100),
    IsAlternative BIT NOT NULL DEFAULT 0,
    GapExplanation VARCHAR(250) NULL,

    CONSTRAINT FK_Recommendation_Session
        FOREIGN KEY (AdvisorySessionID)
        REFERENCES dbo.AdvisorySession(AdvisorySessionID),

    CONSTRAINT FK_Recommendation_Degree
        FOREIGN KEY (DegreeProgrammeID)
        REFERENCES dbo.DegreeProgramme(DegreeProgrammeID)
);
GO
