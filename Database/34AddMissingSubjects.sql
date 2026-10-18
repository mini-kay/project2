USE FuturePathDB;
GO
WITH Languages(Name) AS (
	SELECT Name FROM (VALUES
		('Afrikaans'),('English'),('isiNdebele'),('isiXhosa'),('isiZulu'),
		('Sepedi'),('Sesotho'),('Setswana'),('SiSwati'),('Tshivenda'),('Xitsonga')
	) v(Name)
),
Wanted(SubjectName) AS (
	SELECT NAME + ' Home Language' FROM Languages
	UNION ALL
	SELECT Name + ' First Additional Language' FROM Languages
	UNION ALL
	SELECT SubjectName FROM (VALUES
		('Accounting'),('Agricultural Management Practices'),('Agricultural Sciences'),
		('Agricultural Technology'),('Business Studies'),('Civil Technology'),
		('Computer Applications Technology (CAT)'),('Consumer Studies'),('Dance Studies'),
		('Design'),('Dramatic Arts'),('Economics'),('Electrical Technology'),
		('Engineering Graphics and Design'), ('Geography'),('History'),('Hospitality Studies'),
		('Information Technology (IT)'),('Life Sciences'),('Marine Sciences'),('Maritime Economics'),
		('Mechanical Technology'), ('Music'),('Nautical Sciences'),('Physical Sciences'),
		('Religion Studies'),('Technical Sciences'),('Tourism'),('Visual Arts')
	) v(SubjectName)
)
INSERT INTO dbo.Subject(SubjectName)
SELECT w.SubjectName
FROM Wanted w
WHERE NOT EXISTS (SELECT 1 FROM dbo.Subject s WHERE s.SubjectName = w.SubjectName);
GO