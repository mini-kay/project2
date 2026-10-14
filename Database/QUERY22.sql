USE FuturePathDB;
GO

SELECT
    l.LearnerID,
    l.FirstName,
    l.LastName,
    l.Grade,
    l.School,
    a.AdvisorySessionID,
    a.SessionDate,
    a.OverallOutcome,
    dp.ProgrammeName,
    s.SubjectName,
    ls.Mark,
    rr.OverallScore,
    rr.SubjectMatchScore,
    rr.MarkMatchScore,
    rr.InterestMatchScore,
    rr.FacultyPreferenceScore,
    rr.IsAlternative,
    rr.GapExplanation
FROM dbo.Learner l
INNER JOIN dbo.AdvisorySession a
    ON a.LearnerID = l.LearnerID
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
LEFT JOIN dbo.LearnerSubject ls
    ON ls.AdvisorySessionID = a.AdvisorySessionID
LEFT JOIN dbo.Subject s
    ON s.SubjectID = ls.SubjectID
LEFT JOIN dbo.RecommendationResult rr
    ON rr.AdvisorySessionID = a.AdvisorySessionID
ORDER BY a.SessionDate DESC, l.LastName, s.SubjectName;
GO

SELECT
    l.FirstName,
    l.LastName,
    l.Grade,
    a.AdvisorySessionID,
    a.SessionDate,
    dp.ProgrammeName,
    rr.InterestMatchScore,
    rr.MarkMatchScore,
    rr.SubjectMatchScore,
    rr.OverallScore,
    a.OverallOutcome,
    rr.GapExplanation
FROM dbo.Learner l
INNER JOIN dbo.AdvisorySession a
    ON a.LearnerID = l.LearnerID
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
LEFT JOIN dbo.RecommendationResult rr
    ON rr.AdvisorySessionID = a.AdvisorySessionID
ORDER BY l.LastName, rr.OverallScore DESC;
GO

SELECT
    l.FirstName,
    l.LastName,
    l.Grade,
    dp.ProgrammeName,
    f.FacultyName,
    a.SessionDate,
    a.OverallOutcome,
    rr.GapExplanation
FROM dbo.Learner l
INNER JOIN dbo.AdvisorySession a
    ON a.LearnerID = l.LearnerID
INNER JOIN dbo.DegreeProgramme dp
    ON dp.DegreeProgrammeID = a.DegreeProgrammeID
INNER JOIN dbo.Faculty f
    ON f.FacultyID = dp.FacultyID
LEFT JOIN dbo.RecommendationResult rr
    ON rr.AdvisorySessionID = a.AdvisorySessionID
WHERE a.OverallOutcome IN (
    'Not Currently Eligible',
    'More Information Needed'
)
ORDER BY a.SessionDate DESC, l.LastName;
GO