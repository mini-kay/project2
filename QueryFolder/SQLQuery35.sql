USE FuturePathDB;
GO

INSERT INTO dbo.Subject (SubjectName)
SELECT languages.SubjectName
FROM (VALUES
    ('Afrikaans Home Language'),
    ('isiNdebele Home Language'),
    ('isiXhosa Home Language'),
    ('Sepedi Home Language'),
    ('Sesotho Home Language'),
    ('Setswana Home Language'),
    ('SiSwati Home Language'),
    ('Tshivenda Home Language'),
    ('itsonga Home Language'),
    ('Afrikaans First Additional Language'),
    ('isiNdebele First Additional Language'),
    ('isiXhosa First Additional Language'),
    ('isiZulu First Additional Language'),
    ('Sepedi First Additional Language'),
    ('Sesotho First Additional Language'),
    ('Setswana First Additional Language'),
    ('SiSwati First Additional Language'),
    ('Tshivenda First Additional Language'),
    ('itsonga First Additional Language')
) AS languages(SubjectName)
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.Subject s
    WHERE s.SubjectName = languages.SubjectName
);
GO