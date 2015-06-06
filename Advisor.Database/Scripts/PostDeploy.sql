:r .\CreateCategories.sql
go

:r .\CreateProducts.sql
go

insert into [Users] ([Login],[PasswordHash],[Name],[Sirname],[Email],[Info])
values (N'Вася',N'конечно',N'Вася',N'лучший',N'из',N'людей')
go

