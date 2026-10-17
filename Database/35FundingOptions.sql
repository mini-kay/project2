IF COL_LENGTH('dbo.FundingOption', 'RequiredDocuments') IS NULL
    ALTER TABLE dbo.FundingOption ADD RequiredDocuments NVARCHAR(300) NULL;
IF COL_LENGTH('dbo.FundingOption', 'ContactInfo') IS NULL
    ALTER TABLE dbo.FundingOption ADD ContactInfo NVARCHAR(300) NULL;
IF COL_LENGTH('dbo.FundingOption', 'FundingBasis') IS NULL
    ALTER TABLE dbo.FundingOption ADD FundingBasis NVARCHAR(20) NULL;
GO

--Funding records
INSERT INTO dbo.FundingOption
    (FundingName, FundingType, EligibilityDescription, ClosingDate, IsActive, RequiredDocuments, ContactInfo, FundingBasis)
SELECT v.* FROM (VALUES
 ('Faculty Merit Award',        'Scholarship',      'Based on academic merit',                          '2027-09-30', 1, 'ID, results',                       'Faculty office, see university website', 'Merit'),
 ('Commerce Faculty Bursary',   'Bursary',          'Commerce students with proven financial need',     '2027-09-30', 1, 'ID, results, proof of income',      'Faculty office, see university website', 'Need'),
 ('NSFAS Support',              'Financial aid',    'South African citizens with household income below the NSFAS threshold', '2027-11-30', 1, 'ID, proof of income, results', 'www.nsfas.org.za', 'Need'),
 ('Science Excellence Scholarship','Scholarship',   'High-achieving Science applicants',                '2027-08-31', 1, 'ID, results',                       'Faculty office, see university website', 'Merit'),
 ('Science Access Bursary',     'Bursary',          'Science students who cannot afford fees',          '2027-09-15', 1, 'ID, results, proof of income',      'Faculty office, see university website', 'Need'),
 ('Engineering Industry Bursary','External funding','Engineering students; merit and financial need considered','2027-07-31', 1, 'ID, results, proof of income, motivation letter', 'Sponsor careers page', 'Both'),
 ('Engineering Merit Scholarship','Scholarship',    'Top Engineering applicants by academic results',   '2027-08-31', 1, 'ID, results',                       'Faculty office, see university website', 'Merit'),
 ('Health Sciences Merit Award','Scholarship',      'Health Sciences applicants with strong results',   '2027-08-15', 1, 'ID, results',                       'Faculty office, see university website', 'Merit'),
 ('Health Sciences Need Bursary','Bursary',         'Health Sciences students with financial need',     '2027-09-15', 1, 'ID, results, proof of income',      'Faculty office, see university website', 'Need'),
 ('Information Systems Industry Bursary','External funding','BCom Information Systems students',        '2027-10-31', 1, 'ID, results, CV',                   'Sponsor careers page', 'Both')
) AS v(FundingName, FundingType, EligibilityDescription, ClosingDate, IsActive, RequiredDocuments, ContactInfo, FundingBasis)
WHERE NOT EXISTS (SELECT 1 FROM dbo.FundingOption fo WHERE fo.FundingName = v.FundingName);
GO

--Faculty links (NB: NSFAS is linked to every faculty)
INSERT INTO dbo.FundingFaculty (FundingOptionID, FacultyID)
SELECT fo.FundingOptionID, f.FacultyID
FROM (VALUES
 ('Faculty Merit Award','Commerce'),
 ('Commerce Faculty Bursary','Commerce'),
 ('Science Excellence Scholarship','Science'),
 ('Science Access Bursary','Science'),
 ('Engineering Industry Bursary','Engineering and the Built Environment'),
 ('Engineering Merit Scholarship','Engineering and the Built Environment'),
 ('Health Sciences Merit Award','Health Sciences'),
 ('Health Sciences Need Bursary','Health Sciences')
) AS v(FundingName, FacultyName)
JOIN dbo.FundingOption fo ON fo.FundingName = v.FundingName
JOIN dbo.Faculty f        ON f.FacultyName   = v.FacultyName
WHERE NOT EXISTS (SELECT 1 FROM dbo.FundingFaculty x
                  WHERE x.FundingOptionID = fo.FundingOptionID AND x.FacultyID = f.FacultyID);
 
INSERT INTO dbo.FundingFaculty (FundingOptionID, FacultyID)
SELECT fo.FundingOptionID, f.FacultyID
FROM dbo.FundingOption fo CROSS JOIN dbo.Faculty f
WHERE fo.FundingName = 'NSFAS Support'
  AND NOT EXISTS (SELECT 1 FROM dbo.FundingFaculty x
                  WHERE x.FundingOptionID = fo.FundingOptionID AND x.FacultyID = f.FacultyID);

-- Programme link
INSERT INTO dbo.FundingProgramme (FundingOptionID, DegreeProgrammeID)
SELECT fo.FundingOptionID, d.DegreeProgrammeID
FROM dbo.FundingOption fo
JOIN dbo.DegreeProgramme d ON d.ProgrammeName LIKE '%Information Systems%'
WHERE fo.FundingName = 'Information Systems Industry Bursary'
  AND NOT EXISTS (SELECT 1 FROM dbo.FundingProgramme x
                  WHERE x.FundingOptionID = fo.FundingOptionID AND x.DegreeProgrammeID = d.DegreeProgrammeID);
GO