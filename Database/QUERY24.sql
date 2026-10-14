USE FuturePathDB;
GO

-- Check whether the required user roles are supported.
SELECT
    name AS ConstraintName,
    definition AS ConstraintDefinition
FROM sys.check_constraints
WHERE parent_object_id = OBJECT_ID('dbo.UserAccount');

-- Review account records without displaying password hashes.
SELECT
    UserAccountID,
    Username,
    Role,
    IsActive
FROM dbo.UserAccount
ORDER BY Role, Username;

-- Count accounts by role.
SELECT
    Role,
    COUNT(*) AS AccountCount
FROM dbo.UserAccount
GROUP BY Role;
GO