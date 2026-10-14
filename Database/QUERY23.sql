USE FuturePathDB;
GO

-- 1. Check for duplicate recommendation records
-- for the same programme within one advisory session.
SELECT
    AdvisorySessionID,
    DegreeProgrammeID,
    COUNT(*) AS RecordCount
FROM dbo.RecommendationResult
GROUP BY AdvisorySessionID, DegreeProgrammeID
HAVING COUNT(*) > 1;

-- 2. Check for recommendations linked to missing sessions.
SELECT rr.*
FROM dbo.RecommendationResult rr
LEFT JOIN dbo.AdvisorySession a
    ON a.AdvisorySessionID = rr.AdvisorySessionID
WHERE a.AdvisorySessionID IS NULL;

-- 3. Check for recommendations linked to missing programmes.
SELECT rr.*
FROM dbo.RecommendationResult rr
LEFT JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = rr.DegreeProgrammeID
WHERE dp.DegreeProgrammeID IS NULL;

-- 4. Review primary and alternative recommendations.
SELECT
    a.AdvisorySessionID,
    l.FirstName,
    l.LastName,
    dp.ProgrammeName,
    rr.OverallScore,
    rr.IsAlternative,
    rr.GapExplanation
FROM dbo.RecommendationResult rr
INNER JOIN dbo.AdvisorySession a
    ON a.AdvisorySessionID = rr.AdvisorySessionID
INNER JOIN dbo.Learner l
    ON l.LearnerID = a.LearnerID
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = rr.DegreeProgrammeID
ORDER BY a.AdvisorySessionID, rr.IsAlternative, rr.OverallScore DESC;
GO