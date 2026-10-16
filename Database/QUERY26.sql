SELECT
    dp.DegreeProgrammeID,
    dp.ProgrammeName,
    s.SubjectName,
    pr.MinimumMark
FROM dbo.ProgrammeRequirement pr
JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = pr.DegreeProgrammeID
JOIN dbo.Subject s
    ON s.SubjectID = pr.SubjectID
ORDER BY dp.DegreeProgrammeID, s.SubjectName;

SELECT
    ls.LearnerID,
    ls.AdvisorySessionID,
    s.SubjectName,
    ls.Mark
FROM dbo.LearnerSubject ls
JOIN dbo.Subject s
    ON s.SubjectID = ls.SubjectID
ORDER BY ls.AdvisorySessionID, ls.LearnerID;