USE FuturePathDB;
GO

ALTER TABLE dbo.AdvisorySession
ALTER COLUMN DegreeProgrammeID INT NULL;
GO

ALTER TABLE dbo.LearnerInterestResponse
ALTER COLUMN AdvisorySessionID INT NULL;
GO

SELECT
    TABLE_NAME,
    COLUMN_NAME,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('AdvisorySession', 'LearnerInterestResponse')
  AND COLUMN_NAME IN ('DegreeProgrammeID', 'AdvisorySessionID')
ORDER BY TABLE_NAME, COLUMN_NAME;