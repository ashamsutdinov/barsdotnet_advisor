CREATE TABLE [dbo].[ProductPhotos]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Photo] VARBINARY(MAX) NULL, 
	[MimeTypePhoto] VARCHAR(50) NULL,
    [ProductId] INT NOT NULL,
	constraint fk_product_productphotos foreign key (ProductId) references
	Products(Id) on delete cascade on update cascade
)
