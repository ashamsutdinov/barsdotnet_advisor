CREATE TABLE [dbo].[Categories]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Name] NVARCHAR(200) NOT NULL, 
    [Info] NVARCHAR(500) NOT NULL
)
