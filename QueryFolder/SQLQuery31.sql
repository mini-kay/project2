SELECT TOP 20 *
FROM dbo.RecommendationResult
ORDER BY AdvisorySessionID DESC;

EXEC sp_help 'dbo.RecommendationResult';