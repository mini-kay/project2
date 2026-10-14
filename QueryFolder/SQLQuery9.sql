
USE FuturePathDB;
GO

INSERT INTO dbo.DegreeInterestMapping
    (DegreeProgrammeID, InterestCategoryID, Weight)
SELECT dp.DegreeProgrammeID, ic.InterestCategoryID, v.Weight
FROM (VALUES
    ('Bachelor of Commerce', 'Business and Management', 3),
    ('Bachelor of Commerce', 'Technology and Computing', 2),
    ('Bachelor of Business Science', 'Business and Management', 3),
    ('Bachelor of Business Science', 'Technology and Computing', 3),
    ('Bachelor of Arts', 'Social Development', 3),
    ('Bachelor of Arts', 'Science and Research', 1),
    ('Bachelor of Social Science', 'Social Development', 3),
    ('Bachelor of Social Science', 'Health and Wellbeing', 1),
    ('Bachelor of Science in Engineering', 'Technology and Computing', 3),
    ('Bachelor of Science in Engineering', 'Science and Research', 3),
    ('Bachelor of Science', 'Science and Research', 3),
    ('Bachelor of Science', 'Technology and Computing', 2),
    ('Bachelor of Health Sciences', 'Health and Wellbeing', 3),
    ('Bachelor of Health Sciences', 'Science and Research', 2)
) AS v(ProgrammeName, CategoryName, Weight)
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName
INNER JOIN dbo.InterestCategory ic
    ON ic.CategoryName = v.CategoryName;
GO

-- Verify the mappings
SELECT
    dp.ProgrammeName,
    ic.CategoryName,
    dim.Weight
FROM dbo.DegreeInterestMapping dim
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = dim.DegreeProgrammeID
INNER JOIN dbo.InterestCategory ic
    ON ic.InterestCategoryID = dim.InterestCategoryID
ORDER BY dp.ProgrammeName, ic.CategoryName;
GO
