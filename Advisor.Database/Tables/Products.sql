CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [UserId] INT NOT NULL, 
    [Info] NVARCHAR(800) NOT NULL, 
    [MinValue] INT NULL, 
	[MaxValue] INT NULL,
    [DateOfCreate] DATETIME2 NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [CategoryId] INT NOT NULL,
	[Rating] NUMERIC(5, 5) NOT NULL, 
    constraint fk_categories_products foreign key (CategoryId) 
	references Categories(Id) on delete cascade on update cascade,
	constraint fk_users_products foreign key (UserId)
	references Users(Id) on delete cascade on update cascade
)
