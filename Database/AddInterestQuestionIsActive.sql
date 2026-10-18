ALTER TABLE dbo.InterestQuestion
ADD IsActive BIT NOT NULL
    CONSTRAINT DF_InterestQuestion_IsActive
    DEFAULT (1);
