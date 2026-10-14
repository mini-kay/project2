USE FuturePathDB;
GO

-- 1. Confirm the required tables exist.
SELECT
    t.name AS TableName
FROM sys.tables t
WHERE t.name IN (
    'Learner',
    'Subject',
    'LearnerSubject',
    'Faculty',
    'DegreeProgramme',
    'ProgrammeRequirement',
    'InterestCategory',
    'InterestQuestion',
    'LearnerInterestResponse',
    'DegreeInterestMapping',
    'AdvisorySession',
    'RecommendationResult',
    'FundingOption',
    'FundingFaculty',
    'FundingProgramme',
    'UserAccount',
    'ExportReport'
)
ORDER BY t.name;

-- 2. Count the main records.
SELECT 'Learner' AS TableName, COUNT(*) AS RecordCount
FROM dbo.Learner
UNION ALL
SELECT 'AdvisorySession', COUNT(*)
FROM dbo.AdvisorySession
UNION ALL
SELECT 'LearnerSubject', COUNT(*)
FROM dbo.LearnerSubject
UNION ALL
SELECT 'LearnerInterestResponse', COUNT(*)
FROM dbo.LearnerInterestResponse
UNION ALL
SELECT 'RecommendationResult', COUNT(*)
FROM dbo.RecommendationResult
UNION ALL
SELECT 'UserAccount', COUNT(*)
FROM dbo.UserAccount
UNION ALL
SELECT 'FundingOption', COUNT(*)
FROM dbo.FundingOption;
GO