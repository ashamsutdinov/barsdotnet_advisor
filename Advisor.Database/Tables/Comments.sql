CREATE TABLE [dbo].[Comments]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [DateOfCreate] DATETIME2 NOT NULL, 
    [UserId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Text] NVARCHAR(800) NOT NULL,
	constraint fk_users_comments foreign key (UserId) 
	references Users(Id),
	--тут нужно подумать, как делать удаление и обновление
	constraint fk_products_comments foreign key (ProductId)
	references Products(Id)
	--и тут
)
