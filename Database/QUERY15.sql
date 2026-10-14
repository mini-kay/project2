
USE FuturePathDB;
GO

IF COL_LENGTH('dbo.AdvisorySession', 'OverallOutcome') IS NULL
BEGIN
    ALTER TABLE dbo.AdvisorySession
    ADD OverallOutcome VARCHAR(40) NULL;
END;
GO
