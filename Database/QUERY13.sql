
USE FuturePathDB;
GO

INSERT INTO dbo.LearnerInterestResponse
    (LearnerID, InterestQuestionID, AdvisorySessionID, ResponseValue)
SELECT
    l.LearnerID,
    iq.InterestQuestionID,
    a.AdvisorySessionID,
    v.ResponseValue
FROM (VALUES
    ('Thando', 'Mokoena',
     'I am interested in how organisations make decisions.', 5),
    ('Thando', 'Mokoena',
     'I am interested in how information systems work.', 4),
    ('Lerato', 'Dlamini',
     'I enjoy helping communities address social challenges.', 5),
    ('Lerato', 'Dlamini',
     'I am interested in understanding social problems.', 4),
    ('Sipho', 'Ndlovu',
     'I enjoy investigating questions using evidence.', 4),
    ('Sipho', 'Ndlovu',
     'I am interested in scientific research and experiments.', 3)
) AS v(FirstName, LastName, QuestionText, ResponseValue)
INNER JOIN dbo.Learner l
    ON l.FirstName = v.FirstName
    AND l.LastName = v.LastName
INNER JOIN dbo.AdvisorySession a
    ON a.LearnerID = l.LearnerID
INNER JOIN dbo.InterestQuestion iq
    ON iq.QuestionText = v.QuestionText;
GO

-- Verify the responses
SELECT
    l.FirstName,
    l.LastName,
    iq.QuestionText,
    lir.ResponseValue
FROM dbo.LearnerInterestResponse lir
INNER JOIN dbo.Learner l
    ON l.LearnerID = lir.LearnerID
INNER JOIN dbo.InterestQuestion iq
    ON iq.InterestQuestionID = lir.InterestQuestionID
ORDER BY l.LearnerID, iq.InterestQuestionID;
GO
