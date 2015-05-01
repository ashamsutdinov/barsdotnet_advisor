CREATE TABLE [dbo].[Users]
(
	[Id] int identity(1,1) not null,
	[Login] NVARCHAR(64) NOT NULL,
	[PasswordHash] NVARCHAR(64) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Sirname] NVARCHAR(70) NOT NULL, 
    [Email] NVARCHAR(70) NOT NULL, 
    [Info] NVARCHAR(800) NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id]) 
)
