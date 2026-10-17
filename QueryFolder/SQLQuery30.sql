USE FuturePathDB;
GO

SELECT TOP 5
    AdvisorySessionID,
    LearnerID,
    DegreeProgrammeID,
    SessionDate
FROM dbo.AdvisorySession
ORDER BY AdvisorySessionID DESC;

SELECT TOP 20
    LearnerID,
    InterestQuestionID,
    AdvisorySessionID,
    ResponseValue
FROM dbo.LearnerInterestResponse
ORDER BY LearnerID DESC;