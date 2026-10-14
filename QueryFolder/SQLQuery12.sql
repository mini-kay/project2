
USE FuturePathDB;
GO

-- Create one advising session per learner
INSERT INTO dbo.AdvisorySession
    (LearnerID, DegreeProgrammeID)
SELECT l.LearnerID, dp.DegreeProgrammeID
FROM (VALUES
    ('Thando', 'Mokoena', 'Bachelor of Commerce'),
    ('Lerato', 'Dlamini', 'Bachelor of Arts'),
    ('Sipho', 'Ndlovu', 'Bachelor of Science')
) AS v(FirstName, LastName, ProgrammeName)
INNER JOIN dbo.Learner l
    ON l.FirstName = v.FirstName
    AND l.LastName = v.LastName
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName;
GO

-- Add sample marks to each learner's session
INSERT INTO dbo.LearnerSubject
    (LearnerID, SubjectID, AdvisorySessionID, Mark)
SELECT l.LearnerID, s.SubjectID, a.AdvisorySessionID, v.Mark
FROM (VALUES
    ('Thando', 'Mokoena', 'Mathematics', 75),
    ('Thando', 'Mokoena', 'English Home Language', 68),
    ('Thando', 'Mokoena', 'Accounting', 72),
    ('Lerato', 'Dlamini', 'English Home Language', 65),
    ('Lerato', 'Dlamini', 'History', 70),
    ('Lerato', 'Dlamini', 'Life Sciences', 58),
    ('Sipho', 'Ndlovu', 'Mathematics', 55),
    ('Sipho', 'Ndlovu', 'Physical Sciences', 52),
    ('Sipho', 'Ndlovu', 'English Home Language', 60)
) AS v(FirstName, LastName, SubjectName, Mark)
INNER JOIN dbo.Learner l
    ON l.FirstName = v.FirstName
    AND l.LastName = v.LastName
INNER JOIN dbo.AdvisorySession a
    ON a.LearnerID = l.LearnerID
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;
GO

-- Verify sessions and marks
SELECT
    l.FirstName,
    l.LastName,
    dp.ProgrammeName,
    s.SubjectName,
    ls.Mark,
    a.AdvisorySessionID
FROM dbo.AdvisorySession a
INNER JOIN dbo.Learner l
    ON l.LearnerID = a.LearnerID
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
INNER JOIN dbo.LearnerSubject ls
    ON ls.AdvisorySessionID = a.AdvisorySessionID
INNER JOIN dbo.Subject s
    ON s.SubjectID = ls.SubjectID
ORDER BY l.LearnerID, s.SubjectName;
GO
