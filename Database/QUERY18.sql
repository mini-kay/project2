
USE FuturePathDB;
GO

UPDATE a
SET OverallOutcome =
    CASE
        WHEN l.FirstName = 'Thando' THEN 'Strong Match'
        WHEN l.FirstName = 'Lerato' THEN 'Strong Match'
        WHEN l.FirstName = 'Sipho' THEN 'Possible Match'
    END
FROM dbo.AdvisorySession AS a
INNER JOIN dbo.Learner AS l
    ON a.LearnerID = l.LearnerID;
GO
