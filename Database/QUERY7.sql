
USE FuturePathDB;
GO

-- Bachelor of Commerce: sample requirements
INSERT INTO dbo.ProgrammeRequirement
    (DegreeProgrammeID, SubjectID, MinimumMark)
SELECT dp.DegreeProgrammeID, s.SubjectID, v.MinimumMark
FROM (VALUES
    ('Bachelor of Commerce', 'Mathematics', 60),
    ('Bachelor of Commerce', 'English Home Language', 50)
) AS v(ProgrammeName, SubjectName, MinimumMark)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;

-- Bachelor of Business Science
INSERT INTO dbo.ProgrammeRequirement
    (DegreeProgrammeID, SubjectID, MinimumMark)
SELECT dp.DegreeProgrammeID, s.SubjectID, v.MinimumMark
FROM (VALUES
    ('Bachelor of Business Science', 'Mathematics', 70),
    ('Bachelor of Business Science', 'English Home Language', 60)
) AS v(ProgrammeName, SubjectName, MinimumMark)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;

-- Bachelor of Arts
INSERT INTO dbo.ProgrammeRequirement
    (DegreeProgrammeID, SubjectID, MinimumMark)
SELECT dp.DegreeProgrammeID, s.SubjectID, v.MinimumMark
FROM (VALUES
    ('Bachelor of Arts', 'English Home Language', 50),
    ('Bachelor of Arts', 'History', 50)
) AS v(ProgrammeName, SubjectName, MinimumMark)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;

-- Bachelor of Social Science
INSERT INTO dbo.ProgrammeRequirement
    (DegreeProgrammeID, SubjectID, MinimumMark)
SELECT dp.DegreeProgrammeID, s.SubjectID, v.MinimumMark
FROM (VALUES
    ('Bachelor of Social Science', 'English Home Language', 50),
    ('Bachelor of Social Science', 'Life Sciences', 50)
) AS v(ProgrammeName, SubjectName, MinimumMark)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;

-- Bachelor of Science in Engineering
INSERT INTO dbo.ProgrammeRequirement
    (DegreeProgrammeID, SubjectID, MinimumMark)
SELECT dp.DegreeProgrammeID, s.SubjectID, v.MinimumMark
FROM (VALUES
    ('Bachelor of Science in Engineering', 'Mathematics', 70),
    ('Bachelor of Science in Engineering', 'Physical Sciences', 70),
    ('Bachelor of Science in Engineering', 'English Home Language', 60)
) AS v(ProgrammeName, SubjectName, MinimumMark)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;

-- Bachelor of Science
INSERT INTO dbo.ProgrammeRequirement
    (DegreeProgrammeID, SubjectID, MinimumMark)
SELECT dp.DegreeProgrammeID, s.SubjectID, v.MinimumMark
FROM (VALUES
    ('Bachelor of Science', 'Mathematics', 60),
    ('Bachelor of Science', 'Physical Sciences', 60),
    ('Bachelor of Science', 'English Home Language', 50)
) AS v(ProgrammeName, SubjectName, MinimumMark)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;

-- Bachelor of Health Sciences
INSERT INTO dbo.ProgrammeRequirement
    (DegreeProgrammeID, SubjectID, MinimumMark)
SELECT dp.DegreeProgrammeID, s.SubjectID, v.MinimumMark
FROM (VALUES
    ('Bachelor of Health Sciences', 'Mathematics', 60),
    ('Bachelor of Health Sciences', 'Life Sciences', 60),
    ('Bachelor of Health Sciences', 'English Home Language', 50)
) AS v(ProgrammeName, SubjectName, MinimumMark)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.Subject s
    ON s.SubjectName = v.SubjectName;
GO

-- Verify the requirements
SELECT
    dp.ProgrammeName,
    s.SubjectName,
    pr.MinimumMark
FROM dbo.ProgrammeRequirement pr
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = pr.DegreeProgrammeID
INNER JOIN dbo.Subject s
    ON s.SubjectID = pr.SubjectID
ORDER BY dp.ProgrammeName, s.SubjectName;
GO
