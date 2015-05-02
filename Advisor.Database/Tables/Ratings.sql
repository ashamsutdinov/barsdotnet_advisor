CREATE TABLE [dbo].[Ratings]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Value] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [ProductId] INT NOT NULL,
	constraint fk_users_ratings foreign key (UserId)
	references Users(Id),
	--тут нужно подумать, как делать удаление и обновление
	constraint fk_products_ratings foreign key (ProductId)
	references Products(Id),
	--и тут ^^
)
