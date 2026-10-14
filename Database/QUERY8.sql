
USE FuturePathDB;
GO

-- Add five interest categories
INSERT INTO dbo.InterestCategory (CategoryName)
VALUES
    ('Business and Management'),
    ('Technology and Computing'),
    ('Social Development'),
    ('Science and Research'),
    ('Health and Wellbeing');

-- Add questionnaire questions
INSERT INTO dbo.InterestQuestion
    (InterestCategoryID, QuestionText)
SELECT ic.InterestCategoryID, q.QuestionText
FROM (VALUES
    ('Business and Management',
     'I enjoy planning projects and organising resources.'),
    ('Business and Management',
     'I am interested in how organisations make decisions.'),
    ('Technology and Computing',
     'I enjoy solving problems using computers and technology.'),
    ('Technology and Computing',
     'I am interested in how information systems work.'),
    ('Social Development',
     'I enjoy helping communities address social challenges.'),
    ('Social Development',
     'I am interested in understanding social problems.'),
    ('Science and Research',
     'I enjoy investigating questions using evidence.'),
    ('Science and Research',
     'I am interested in scientific research and experiments.'),
    ('Health and Wellbeing',
     'I am interested in improving peoples health and wellbeing.'),
    ('Health and Wellbeing',
     'I enjoy learning about health and human development.')
) AS q(CategoryName, QuestionText)
INNER JOIN dbo.InterestCategory ic
    ON ic.CategoryName = q.CategoryName;
GO

-- Verify the categories and their questions
SELECT
    ic.CategoryName,
    iq.InterestQuestionID,
    iq.QuestionText
FROM dbo.InterestCategory ic
INNER JOIN dbo.InterestQuestion iq
    ON iq.InterestCategoryID = ic.InterestCategoryID
ORDER BY ic.CategoryName, iq.InterestQuestionID;
GO
