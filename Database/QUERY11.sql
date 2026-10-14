
USE FuturePathDB;
GO

INSERT INTO dbo.Learner
    (FirstName, LastName, Grade, School, Province)
VALUES
    ('Thando', 'Mokoena', 12, 'Sample Secondary School',
     'Western Cape'),
    ('Lerato', 'Dlamini', 11, 'Example High School',
     'KwaZulu-Natal'),
    ('Sipho', 'Ndlovu', 12, 'Demo High School',
     'Gauteng');
GO

-- Verify the learner records
SELECT
    LearnerID,
    FirstName,
    LastName,
    Grade,
    School,
    Province
FROM dbo.Learner
ORDER BY LearnerID;
GO
