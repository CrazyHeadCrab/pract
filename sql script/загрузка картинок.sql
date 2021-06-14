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
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '������� ����� ������������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '������� ����� ������������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '����������� �������� ����������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '����������� �������� ����������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '��������� �������� �����������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '��������� �������� �����������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '�������� ���� ������������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '�������� ���� ������������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '�������� ������ ��������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '�������� ������ ��������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '������� ���� ��������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '������� ���� ��������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '������ �������� ����������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '������ �������� ����������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '�������� ��� ����������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '�������� ��� ����������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '������� ���� Ը�������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '������� ���� Ը�������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '��������� �������� ��������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '��������� �������� ��������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '����� ������ ��������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '����� ������ ��������.jpg'
select @x =emp_id from emp where (emp.sur_name + ' ' + emp.name + ' ' + emp.pat_name = '������� ������ ����������')
exec dbo.load_emp_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ����������', '������� ������ ����������.jpg'
go




use mall
declare @x int
select @x =malls.mall_id from malls where mall_name =  '��������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������� ����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������� ����.jpg'
select @x =malls.mall_id from malls where mall_name =  '���� ���� ���������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���� ���� ���������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������ ����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������ ����.jpg'
select @x =malls.mall_id from malls where mall_name =  '����� �������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '����� �������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�����.jpg'
select @x =malls.mall_id from malls where mall_name =  '�����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�����.jpg'
select @x =malls.mall_id from malls where mall_name =  '������� ����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������� ����.jpg'
select @x =malls.mall_id from malls where mall_name =  '�����������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�����������.jpg'
select @x =malls.mall_id from malls where mall_name =  '����� ���������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '����� ���������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�����.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '���'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���.jpg'
select @x =malls.mall_id from malls where mall_name =  '��������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�����������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�����������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������� ������� ���������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������� ������� ���������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�����������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�����������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������� ���'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������� ���.jpg'
select @x =malls.mall_id from malls where mall_name =  '������� �����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������� �����.jpg'
select @x =malls.mall_id from malls where mall_name =  '�������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�������.jpg'
select @x =malls.mall_id from malls where mall_name =  '���� ����� ����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���� ����� ����.jpg'
select @x =malls.mall_id from malls where mall_name =  '���� �����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���� �����.jpg'
select @x =malls.mall_id from malls where mall_name =  '���������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���������.jpg'
select @x =malls.mall_id from malls where mall_name =  '����������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '����������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '��� �����������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��� �����������.jpg'
select @x =malls.mall_id from malls where mall_name =  '��������� ������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��������� ������.jpg'
select @x =malls.mall_id from malls where mall_name =  '��������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��������.jpg'
select @x =malls.mall_id from malls where mall_name =  '��������������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��������������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '����� �����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '����� �����.jpg'
select @x =malls.mall_id from malls where mall_name =  '������ �����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������ �����.jpg'
select @x =malls.mall_id from malls where mall_name =  '������ ����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������ ����.jpg'
select @x =malls.mall_id from malls where mall_name =  '�������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�������.jpg'
select @x =malls.mall_id from malls where mall_name =  '���� ����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���� ����.jpg'
select @x =malls.mall_id from malls where mall_name =  '���'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���.jpg'
select @x =malls.mall_id from malls where mall_name =  '���� ���'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���� ���.jpg'
select @x =malls.mall_id from malls where mall_name =  '��� ����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��� ����.jpg'
select @x =malls.mall_id from malls where mall_name =  '���������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�����-������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�����-������.jpg'
select @x =malls.mall_id from malls where mall_name =  '������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '������.jpg'
select @x =malls.mall_id from malls where mall_name =  '���������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���������.jpg'
select @x =malls.mall_id from malls where mall_name =  '��������������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '��������������.jpg'
select @x =malls.mall_id from malls where mall_name =  '�������'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '�������.jpg'
select @x =malls.mall_id from malls where mall_name =  '����'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '����.jpg'
select @x =malls.mall_id from malls where mall_name =  '���'
exec dbo.load_mall_pic @x, 'C:\Users\user\Downloads\drive-download-20210601T055143Z-001\Image ��', '���.jpg'