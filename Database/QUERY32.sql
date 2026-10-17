USE FuturePathDB;
GO

SELECT TABLE_SCHEMA, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

USE FuturePathDB;
GO

EXEC sp_help 'dbo.LearnerSubject';
EXEC sp_help 'dbo.ProgrammeRequirement';
EXEC sp_help 'dbo.DegreeProgramme';