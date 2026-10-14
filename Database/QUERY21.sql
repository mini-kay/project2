USE FuturePathDB;
GO

-- 1. Check for marks outside the permitted 0-100 range.
SELECT 'Invalid marks' AS CheckName, COUNT(*) AS IssueCount
FROM dbo.LearnerSubject
WHERE Mark < 0 OR Mark > 100;

-- 2. Check for duplicate subjects within the same session.
SELECT
    AdvisorySessionID,
    SubjectID,
    COUNT(*) AS DuplicateCount
FROM dbo.LearnerSubject
GROUP BY AdvisorySessionID, SubjectID
HAVING COUNT(*) > 1;

-- 3. Check for invalid advisory outcomes.
SELECT
    AdvisorySessionID,
    OverallOutcome
FROM dbo.AdvisorySession
WHERE OverallOutcome IS NOT NULL
  AND OverallOutcome NOT IN (
      'Strong Match',
      'Possible Match',
      'Not Currently Eligible',
      'More Information Needed'
  );

-- 4. Check for recommendation scores outside 0-100.
SELECT *
FROM dbo.RecommendationResult
WHERE SubjectMatchScore NOT BETWEEN 0 AND 100
   OR MarkMatchScore NOT BETWEEN 0 AND 100
   OR InterestMatchScore NOT BETWEEN 0 AND 100
   OR FacultyPreferenceScore NOT BETWEEN 0 AND 100
   OR OverallScore NOT BETWEEN 0 AND 100;

-- 5. Check whether learners have missing required profile data.
SELECT *
FROM dbo.Learner
WHERE FirstName IS NULL OR LTRIM(RTRIM(FirstName)) = ''
   OR LastName IS NULL OR LTRIM(RTRIM(LastName)) = ''
   OR School IS NULL OR LTRIM(RTRIM(School)) = ''
   OR Province IS NULL OR LTRIM(RTRIM(Province)) = '';
GO