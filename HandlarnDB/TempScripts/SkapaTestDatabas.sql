-- Create a new database called 'DatabaseName'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'TestDB'
)
CREATE DATABASE TestDB
GO

-- Create a new table called '[TestTabellen]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[TestTabellen]', 'U') IS NOT NULL
DROP TABLE [dbo].[TestTabellen]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[TestTabellen]
(
    [Id] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [ColumnName2] NVARCHAR(50) NOT NULL,
    [ColumnName3] NVARCHAR(50) NOT NULL
    -- Specify more columns here
);
GO

-- Insert rows into table 'TableName' in schema '[dbo]'
INSERT INTO [dbo].[TestTabellen] (
    Id, ColumnName2, ColumnName3
)
VALUES
( 
    1, 'hej', 'då'
)

GO