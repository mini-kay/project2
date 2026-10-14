
USE FuturePathDB;
GO

-- Add sample funding opportunities
INSERT INTO dbo.FundingOption
    (FundingName, FundingType, EligibilityDescription,
     RequiredDocuments, ClosingDate, ContactInfo, IsActive)
VALUES
    ('Future Path Merit Award', 'Scholarship',
     'Sample award for testing academic merit eligibility.',
     'Academic results, proof of identity',
     '2027-03-31', 'sample@example.com', 1),

    ('Student Opportunity Bursary', 'Bursary',
     'Sample bursary for testing financial-support guidance.',
     'Academic results, financial documents',
     '2027-04-30', 'sample@example.com', 1),

    ('Access to Education Support', 'Financial Aid',
     'Sample funding option for testing financial-aid recommendations.',
     'Proof of identity, supporting documents',
     '2027-05-31', 'sample@example.com', 1);

-- Link funding to faculties
INSERT INTO dbo.FundingFaculty (FundingOptionID, FacultyID)
SELECT fo.FundingOptionID, f.FacultyID
FROM (VALUES
    ('Future Path Merit Award', 'Commerce'),
    ('Future Path Merit Award', 'Science'),
    ('Student Opportunity Bursary', 'Humanities'),
    ('Student Opportunity Bursary', 'Health Sciences'),
    ('Access to Education Support', 'Commerce'),
    ('Access to Education Support', 'Engineering and the Built Environment')
) AS v(FundingName, FacultyName)
INNER JOIN dbo.FundingOption fo
    ON fo.FundingName = v.FundingName
INNER JOIN dbo.Faculty f
    ON f.FacultyName = v.FacultyName;

-- Link funding to selected degree programmes
INSERT INTO dbo.FundingProgramme
    (FundingOptionID, DegreeProgrammeID)
SELECT fo.FundingOptionID, dp.DegreeProgrammeID
FROM (VALUES
    ('Future Path Merit Award', 'Bachelor of Commerce'),
    ('Student Opportunity Bursary', 'Bachelor of Social Science'),
    ('Access to Education Support', 'Bachelor of Science in Engineering')
) AS v(FundingName, ProgrammeName)
INNER JOIN dbo.FundingOption fo
    ON fo.FundingName = v.FundingName
INNER JOIN dbo.DegreeProgramme dp
    ON dp.ProgrammeName = v.ProgrammeName;
GO

-- Verify the funding records
SELECT FundingOptionID, FundingName, FundingType, IsActive
FROM dbo.FundingOption;

SELECT
    fo.FundingName,
    f.FacultyName
FROM dbo.FundingFaculty ff
INNER JOIN dbo.FundingOption fo
    ON fo.FundingOptionID = ff.FundingOptionID
INNER JOIN dbo.Faculty f
    ON f.FacultyID = ff.FacultyID;
GO
