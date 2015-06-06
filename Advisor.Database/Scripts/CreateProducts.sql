delete from Products;

insert into [Products] ([UserId],[Info],[MinValue],[MaxValue],[DateOfCreate],[Name],[CategoryId])
values (N'1',N'Строю закрытые и открытые беседки из дерева',N'10000',N'30000',N'06.06.2015',N'Строительство беседки',N'1')
go
insert into [Products] ([UserId],[Info],[MinValue],[MaxValue],[DateOfCreate],[Name],[CategoryId])
values (N'1',N'Ремонт утюгов любой сложности',N'1000',N'5000',N'05.06.2015',N'Ремонт утюгов',N'2')
go
insert into [Products] ([UserId],[Info],[MinValue],[MaxValue],[DateOfCreate],[Name],[CategoryId])
values (N'1',N'Доставка воды по Казани',N'50',N'200',N'1.06.2015',N'Доставка воды',N'3')
go
insert into [Products] ([UserId],[Info],[MinValue],[MaxValue],[DateOfCreate],[Name],[CategoryId])
values (N'2',N'Готовлю к ЕГЭ по русскому и литературе',N'1000',N'3500',N'1.06.2015',N'Репетитор старших классов',N'4')
go