
USE FuturePathDB;
GO

-- Add sample faculties
INSERT INTO dbo.Faculty (FacultyName)
VALUES
    ('Commerce'),
    ('Humanities'),
    ('Engineering and the Built Environment'),
    ('Science'),
    ('Health Sciences');

-- Add school subjects
INSERT INTO dbo.Subject (SubjectName)
VALUES
    ('Mathematics'),
    ('Mathematical Literacy'),
    ('English Home Language'),
    ('English First Additional Language'),
    (' isiZulu Home Language'),
    ('Physical Sciences'),
    ('Life Sciences'),
    ('Accounting'),
    ('Business Studies'),
    ('Economics'),
    ('Geography'),
    ('History'),
    ('Computer Applications Technology'),
    ('Information Technology'),
    ('Life Orientation');
GO

SELECT * FROM dbo.Faculty;
SELECT * FROM dbo.Subject;
GO
