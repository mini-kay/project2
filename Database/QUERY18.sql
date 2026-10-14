
USE FuturePathDB;
GO

UPDATE a
SET OverallOutcome =
    CASE
        WHEN l.FirstName = 'Thando'
             AND l.LastName = 'Mokoena'
            THEN 'Strong Match'

        WHEN l.FirstName = 'Lerato'
             AND l.LastName = 'Dlamini'
            THEN 'Strong Match'

        WHEN l.FirstName = 'Sipho'
             AND l.LastName = 'Ndlovu'
            THEN 'Possible Match'

        ELSE a.OverallOutcome
    END
FROM dbo.AdvisorySession AS a
INNER JOIN dbo.Learner AS l
    ON a.LearnerID = l.LearnerID
WHERE
    (l.FirstName = 'Thando' AND l.LastName = 'Mokoena')
    OR (l.FirstName = 'Lerato' AND l.LastName = 'Dlamini')
    OR (l.FirstName = 'Sipho' AND l.LastName = 'Ndlovu');
GO
