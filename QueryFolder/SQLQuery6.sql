
USE FuturePathDB;
GO

-- Commerce programmes
INSERT INTO dbo.DegreeProgramme (FacultyID, ProgrammeName)
SELECT FacultyID, 'Bachelor of Commerce'
FROM dbo.Faculty
WHERE FacultyName = 'Commerce';

INSERT INTO dbo.DegreeProgramme (FacultyID, ProgrammeName)
SELECT FacultyID, 'Bachelor of Business Science'
FROM dbo.Faculty
WHERE FacultyName = 'Commerce';

-- Humanities programmes
INSERT INTO dbo.DegreeProgramme (FacultyID, ProgrammeName)
SELECT FacultyID, 'Bachelor of Arts'
FROM dbo.Faculty
WHERE FacultyName = 'Humanities';

INSERT INTO dbo.DegreeProgramme (FacultyID, ProgrammeName)
SELECT FacultyID, 'Bachelor of Social Science'
FROM dbo.Faculty
WHERE FacultyName = 'Humanities';

-- Engineering programmes
INSERT INTO dbo.DegreeProgramme (FacultyID, ProgrammeName)
SELECT FacultyID, 'Bachelor of Science in Engineering'
FROM dbo.Faculty
WHERE FacultyName = 'Engineering and the Built Environment';

-- Science programmes
INSERT INTO dbo.DegreeProgramme (FacultyID, ProgrammeName)
SELECT FacultyID, 'Bachelor of Science'
FROM dbo.Faculty
WHERE FacultyName = 'Science';

-- Health Sciences programmes
INSERT INTO dbo.DegreeProgramme (FacultyID, ProgrammeName)
SELECT FacultyID, 'Bachelor of Health Sciences'
FROM dbo.Faculty
WHERE FacultyName = 'Health Sciences';
GO

-- Verify the programmes and their faculties
SELECT
    dp.DegreeProgrammeID,
    dp.ProgrammeName,
    f.FacultyName
FROM dbo.DegreeProgramme AS dp
INNER JOIN dbo.Faculty AS f
    ON dp.FacultyID = f.FacultyID
ORDER BY f.FacultyName, dp.ProgrammeName;
GO
