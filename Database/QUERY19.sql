
SELECT
    l.FirstName,
    l.LastName,
    a.OverallOutcome
FROM dbo.AdvisorySession AS a
INNER JOIN dbo.Learner AS l
    ON a.LearnerID = l.LearnerID;
GO
