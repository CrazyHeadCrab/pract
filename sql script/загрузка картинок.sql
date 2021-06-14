drop proc load_mall_pic

create proc load_emp_pic
@id int,
@path nvarchar(100),
@file_name nvarchar(100)
as 
declare @path_name nvarchar(200)
set @path_name = @path +'\' + @file_name
EXECUTE(
'Update emp
set image = (SELECT BulkColumn FROM Openrowset( Bulk N''' + @path_name + ''', Single_Blob) as image)
where emp_id = '+@id)
go

go
create proc load_mall_pic
@id int,
@path nvarchar(100),
@file_name nvarchar(100)
as 
declare @path_name nvarchar(200)
set @path_name = @path +'\' + @file_name
EXECUTE(
'Update malls
set image = (SELECT BulkColumn FROM Openrowset( Bulk N''' + @path_name + ''', Single_Blob) as image)
where mall_id = '+@id)
go

go
create proc load_mall_pic_only_path
@id int,
@path nvarchar(200)
as 
declare @path_name nvarchar(200)
set @path_name = @path 
EXECUTE(
'Update malls
set image = (SELECT BulkColumn FROM Openrowset( Bulk N''' + @path_name + ''', Single_Blob) as image)
where mall_id = '+@id)
go

go
use mall
declare @x int
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Зарубин Мирон Мечиславович')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Зарубин Мирон Мечиславович.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Беломестина Василиса Тимофеевна')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Беломестина Василиса Тимофеевна.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Веточкина Всеслава Андрияновна')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Веточкина Всеслава Андрияновна.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Ломовцев Адам Владимирович')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Ломовцев Адам Владимирович.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Панькива Галина Якововна')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Панькива Галина Якововна.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Рюриков Юлий Глебович')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Рюриков Юлий Глебович.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Рябова Виктория Елизаровна')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Рябова Виктория Елизаровна.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Тепляков Кир Федосиевич')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Тепляков Кир Федосиевич.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Федотов Леон Фёдорович')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Федотов Леон Фёдорович.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Филенкова Владлена Олеговна')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Филенкова Владлена Олеговна.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Чашин Елизар Михеевич')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Чашин Елизар Михеевич.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = 'Шарапов Феофан Кириллович')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image Сотрудники', 'Шарапов Феофан Кириллович.jpg'
go




use mall
declare @x int
select @x =malls.mall_id from malls where mall_name =  'Авиапарк'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Авиапарк.jpg'
select @x =malls.mall_id from malls where mall_name =  'Армада'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Армада.jpg'
select @x =malls.mall_id from malls where mall_name =  'Атриум'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Атриум.jpg'
select @x =malls.mall_id from malls where mall_name =  'АфиМолл Сити'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'АфиМолл Сити.jpg'
select @x =malls.mall_id from malls where mall_name =  'Ашан Сити Капитолий'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Ашан Сити Капитолий.jpg'
select @x =malls.mall_id from malls where mall_name =  'Бутово Молл'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Бутово Молл.jpg'
select @x =malls.mall_id from malls where mall_name =  'Вегас Кунцево'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Вегас Кунцево.jpg'
select @x =malls.mall_id from malls where mall_name =  'Вегас'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Вегас.jpg'
select @x =malls.mall_id from malls where mall_name =  'Весна'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Весна.jpg'
select @x =malls.mall_id from malls where mall_name =  'Времена Года'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Времена Года.jpg'
select @x =malls.mall_id from malls where mall_name =  'Гагаринский'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Гагаринский.jpg'
select @x =malls.mall_id from malls where mall_name =  'Город Лефортово'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Город Лефортово.jpg'
select @x =malls.mall_id from malls where mall_name =  'Гранд'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Гранд.jpg'
select @x =malls.mall_id from malls where mall_name =  'Гудзон'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Гудзон.jpg'
select @x =malls.mall_id from malls where mall_name =  'ГУМ'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'ГУМ.jpg'
select @x =malls.mall_id from malls where mall_name =  'ЕвроПарк'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'ЕвроПарк.jpg'
select @x =malls.mall_id from malls where mall_name =  'Европейский'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Европейский.jpg'
select @x =malls.mall_id from malls where mall_name =  'Золотой Вавилон Ростокино'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Золотой Вавилон Ростокино.jpg'
select @x =malls.mall_id from malls where mall_name =  'Калейдоскоп'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Калейдоскоп.jpg'
select @x =malls.mall_id from malls where mall_name =  'Красный Кит'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Красный Кит.jpg'
select @x =malls.mall_id from malls where mall_name =  'Кунцево Плаза'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Кунцево Плаза.jpg'
select @x =malls.mall_id from malls where mall_name =  'Лужайка'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Лужайка.jpg'
select @x =malls.mall_id from malls where mall_name =  'Мега Белая Дача'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Мега Белая Дача.jpg'
select @x =malls.mall_id from malls where mall_name =  'Мега Химки'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Мега Химки.jpg'
select @x =malls.mall_id from malls where mall_name =  'Мегаполис'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Мегаполис.jpg'
select @x =malls.mall_id from malls where mall_name =  'Метрополис'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Метрополис.jpg'
select @x =malls.mall_id from malls where mall_name =  'Мозаика'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Мозаика.jpg'
select @x =malls.mall_id from malls where mall_name =  'Москва'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Москва.jpg'
select @x =malls.mall_id from malls where mall_name =  'Наш Гипермаркет'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Наш Гипермаркет.jpg'
select @x =malls.mall_id from malls where mall_name =  'Новинский пассаж'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Новинский пассаж.jpg'
select @x =malls.mall_id from malls where mall_name =  'Авиапарк'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Авиапарк.jpg'
select @x =malls.mall_id from malls where mall_name =  'Новомосковский'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Новомосковский.jpg'
select @x =malls.mall_id from malls where mall_name =  'Облака'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Облака.jpg'
select @x =malls.mall_id from malls where mall_name =  'Океания'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Океания.jpg'
select @x =malls.mall_id from malls where mall_name =  'Отрада'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Отрада.jpg'
select @x =malls.mall_id from malls where mall_name =  'Принц Плаза'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Принц Плаза.jpg'
select @x =malls.mall_id from malls where mall_name =  'Райкин Плаза'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Райкин Плаза.jpg'
select @x =malls.mall_id from malls where mall_name =  'Реутов Парк'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Реутов Парк.jpg'
select @x =malls.mall_id from malls where mall_name =  'Ривьера'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Ривьера.jpg'
select @x =malls.mall_id from malls where mall_name =  'Рига Молл'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Рига Молл.jpg'
select @x =malls.mall_id from malls where mall_name =  'Рио'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Рио.jpg'
select @x =malls.mall_id from malls where mall_name =  'Твой дом'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Твой дом.jpg'
select @x =malls.mall_id from malls where mall_name =  'Три Кита'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Три Кита.jpg'
select @x =malls.mall_id from malls where mall_name =  'Фестиваль'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Фестиваль.jpg'
select @x =malls.mall_id from malls where mall_name =  'Филион'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Филион.jpg'
select @x =malls.mall_id from malls where mall_name =  'Ханой-Москва'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Ханой-Москва.jpg'
select @x =malls.mall_id from malls where mall_name =  'Хорошо'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Хорошо.jpg'
select @x =malls.mall_id from malls where mall_name =  'Черемушки'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Черемушки.jpg'
select @x =malls.mall_id from malls where mall_name =  'Шереметьевский'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Шереметьевский.jpg'
select @x =malls.mall_id from malls where mall_name =  'Шоколад'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Шоколад.jpg'
select @x =malls.mall_id from malls where mall_name =  'Щука'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Щука.jpg'
select @x =malls.mall_id from malls where mall_name =  'Рио'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ТЦ', 'Рио.jpg'