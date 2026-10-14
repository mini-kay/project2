
USE FuturePathDB;
GO

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'AdvisorySession'
ORDER BY ORDINAL_POSITION;
GO

SELECT
    RecommendationResultID,
    AdvisorySessionID,
    OverallScore,
    IsAlternative
FROM dbo.RecommendationResult;
GO
