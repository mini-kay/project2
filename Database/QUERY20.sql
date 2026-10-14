USE FuturePathDB;
GO

-- Add seven additional test learners only if they do not exist.
INSERT INTO dbo.Learner
    (FirstName, LastName, Grade, School, Province)
SELECT v.FirstName, v.LastName, v.Grade, v.School, v.Province
FROM (VALUES
    ('Ayanda', 'Zulu', 12, 'Coastal High School', 'KwaZulu-Natal'),
    ('Naledi', 'Molefe', 11, 'Mountain View School', 'Free State'),
    ('Liam', 'Jacobs', 12, 'Bayview Secondary School', 'Western Cape'),
    ('Zanele', 'Khumalo', 11, 'Central High School', 'Gauteng'),
    ('Kabelo', 'Mokoena', 12, 'Riverside School', 'Limpopo'),
    ('Amahle', 'Cele', 11, 'Greenfields High School', 'Eastern Cape'),
    ('David', 'Naidoo', 12, 'Northside Secondary School', 'Mpumalanga')
) AS v(FirstName, LastName, Grade, School, Province)
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.Learner l
    WHERE l.FirstName = v.FirstName
      AND l.LastName = v.LastName
);
GO

-- Verify the total number of learners.
SELECT COUNT(*) AS TotalLearners
FROM dbo.Learner;
GO

-- Create one advising session for each new test learner.
INSERT INTO dbo.AdvisorySession
    (LearnerID, DegreeProgrammeID, OverallOutcome)
SELECT
    l.LearnerID,
    dp.DegreeProgrammeID,
    'More Information Needed'
FROM dbo.Learner l
CROSS JOIN dbo.DegreeProgramme dp
WHERE
    l.FirstName IN (
        'Ayanda', 'Naledi', 'Liam', 'Zanele',
        'Kabelo', 'Amahle', 'David'
    )
    AND dp.ProgrammeName = 'Bachelor of Arts'
    AND NOT EXISTS (
        SELECT 1
        FROM dbo.AdvisorySession a
        WHERE a.LearnerID = l.LearnerID
          AND a.DegreeProgrammeID = dp.DegreeProgrammeID
    );
GO

-- Add sample subject marks for the seven new learners.
INSERT INTO dbo.LearnerSubject
    (LearnerID, SubjectID, AdvisorySessionID, Mark)
SELECT
    l.LearnerID,
    s.SubjectID,
    a.AdvisorySessionID,
    v.Mark
FROM (VALUES
    ('Ayanda', 'Zulu', 'Mathematics', 72),
    ('Ayanda', 'Zulu', 'English Home Language', 68),
    ('Ayanda', 'Zulu', 'Accounting', 75),

    ('Naledi', 'Molefe', 'Mathematics', 55),
    ('Naledi', 'Molefe', 'English Home Language', 64),
    ('Naledi', 'Molefe', 'History', 70),

    ('Liam', 'Jacobs', 'Mathematics', 65),
    ('Liam', 'Jacobs', 'English Home Language', 73),
    ('Liam', 'Jacobs', 'Physical Sciences', 62),

    ('Zanele', 'Khumalo', 'Mathematical Literacy', 78),
    ('Zanele', 'Khumalo', 'English First Additional Language', 70),
    ('Zanele', 'Khumalo', 'Business Studies', 76),

    ('Kabelo', 'Mokoena', 'Mathematics', 48),
    ('Kabelo', 'Mokoena', 'English Home Language', 58),
    ('Kabelo', 'Mokoena', 'Life Sciences', 52),

    ('Amahle', 'Cele', 'Mathematical Literacy', 67),
    ('Amahle', 'Cele', 'English Home Language', 72),
    ('Amahle', 'Cele', 'Geography', 69),

    ('David', 'Naidoo', 'Mathematics', 82),
    ('David', 'Naidoo', 'English Home Language', 75),
    ('David', 'Naidoo', 'Information Technology', 88)
) AS v(FirstName, LastName, SubjectName, Mark)
INNER JOIN dbo.Learner l
    ON l.FirstName = v.FirstName
   AND l.LastName = v.LastName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName
INNER JOIN dbo.AdvisorySession a
    ON a.LearnerID = l.LearnerID
   AND a.DegreeProgrammeID = (
       SELECT DegreeProgrammeID
       FROM dbo.DegreeProgramme
       WHERE ProgrammeName = 'Bachelor of Arts'
   )
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.LearnerSubject ls
    WHERE ls.AdvisorySessionID = a.AdvisorySessionID
      AND ls.SubjectID = s.SubjectID
);
GO

-- Add two sample interest responses for each new learner.
INSERT INTO dbo.LearnerInterestResponse
    (LearnerID, InterestQuestionID, AdvisorySessionID, ResponseValue)
SELECT
    l.LearnerID,
    q.InterestQuestionID,
    a.AdvisorySessionID,
    v.ResponseValue
FROM (VALUES
    ('Ayanda', 'Zulu',
     'I am interested in how organisations make decisions.', 5),
    ('Ayanda', 'Zulu',
     'I am interested in how information systems work.', 4),

    ('Naledi', 'Molefe',
     'I enjoy helping communities address social challenges.', 5),
    ('Naledi', 'Molefe',
     'I am interested in understanding social problems.', 4),

    ('Liam', 'Jacobs',
     'I enjoy investigating questions using evidence.', 4),
    ('Liam', 'Jacobs',
     'I am interested in scientific research and experiments.', 5),

    ('Zanele', 'Khumalo',
     'I am interested in how organisations make decisions.', 4),
    ('Zanele', 'Khumalo',
     'I enjoy helping communities address social challenges.', 3),

    ('Kabelo', 'Mokoena',
     'I enjoy investigating questions using evidence.', 3),
    ('Kabelo', 'Mokoena',
     'I am interested in scientific research and experiments.', 4),

    ('Amahle', 'Cele',
     'I enjoy helping communities address social challenges.', 4),
    ('Amahle', 'Cele',
     'I am interested in understanding social problems.', 5),

    ('David', 'Naidoo',
     'I am interested in how information systems work.', 5),
    ('David', 'Naidoo',
     'I am interested in how organisations make decisions.', 4)
) AS v(FirstName, LastName, QuestionText, ResponseValue)
INNER JOIN dbo.Learner l
    ON l.FirstName = v.FirstName
   AND l.LastName = v.LastName
INNER JOIN dbo.InterestQuestion q
    ON q.QuestionText = v.QuestionText
INNER JOIN dbo.AdvisorySession a
    ON a.LearnerID = l.LearnerID
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
   AND dp.ProgrammeName = 'Bachelor of Arts'
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.LearnerInterestResponse r
    WHERE r.AdvisorySessionID = a.AdvisorySessionID
      AND r.InterestQuestionID = q.InterestQuestionID
);
GO