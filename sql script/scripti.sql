use mall
go
create proc postponement_rent
@rent_id int,
@new_date_end date
as 
if exists(select * from rent where @rent_id=rent_id and rent.state_id!=3 and @new_date_end>rent_start)
begin
	update rent 
	set rent_end = @new_date_end
	where rent_id = @rent_id
end
else begin
	print ('Вы ввели некоректные данные')
	end

go


exec dbo.postponement_rent 4, '2021-05-05'


drop function cheak_logpas
go
create function cheak_logpas(@login nvarchar(30), @pas nvarchar(30))
returns table 
as
return 
	select emp.emp_id, emp.role_id from emp where lower(emp.login) = lower(@login) and lower(emp.passwors) = lower(@pas)
go


go

drop view all_malls
go
create view all_malls
as 
SELECT top(1000) dbo.malls.mall_id, dbo.malls.mall_name, dbo.malls.image, dbo.malls.town_id, dbo.town.town_name, dbo.malls.state_id, dbo.mall_state.state_name, dbo.malls.count_pavilions, dbo.malls.price, dbo.malls.coeficent_price, 
                  dbo.malls.count_lvl
FROM     dbo.malls INNER JOIN
                  dbo.mall_state ON dbo.malls.state_id = dbo.mall_state.state_id INNER JOIN
                  dbo.town ON dbo.malls.town_id = dbo.town.town_id
ORDER BY dbo.malls.mall_name, dbo.malls.state_id
go

use mall
drop procedure dbo.update_mall
go
create proc update_mall
@mall_id int,
@name nvarchar(60),
@coef float,
@stat int,
@town int,
@price money,
@lvls int,
@pav int,
@image nvarchar(200)
as 
update malls 
set mall_name = @name, state_id = @stat, count_pavilions = @pav, town_id =@town, price = @price, coeficent_price = @coef, count_lvl = @lvls
	where mall_id = @mall_id

	if (@image != 'err')
	exec load_mall_pic_only_path @mall_id, @image
go


use mall
drop procedure dbo.new_mall
go
create proc new_mall
@name nvarchar(60),
@coef float,
@stat int,
@town int,
@price money,
@lvls int,
@pav int,
@image nvarchar(200)
as 
insert into malls	(mall_name, state_id, count_pavilions,town_id,price,coeficent_price,count_lvl)
	values (@name,@stat,@pav,@town,@price,@coef,@lvls)
declare @i int
select @i = max(mall_id) from malls
if (@image != 'err')
exec load_mall_pic_only_path @i, @image
go


create view All_pavil
as 
SELECT dbo.pavilion.pavilion_name, dbo.pavilion.mall_id, dbo.pavilion.state_id AS pav_state_id, dbo.pavilion.lvl, dbo.pavilion.squares, dbo.pavilion.price_per_one, dbo.pavilion.coeficent_price, dbo.pavilion.pavilion_id, 
                  dbo.pavilion_state.state_name AS pav_stat, dbo.malls.mall_name, dbo.mall_state.state_name AS mall_stat_name, dbo.mall_state.state_id AS mall_stat_id
FROM     dbo.pavilion INNER JOIN
                  dbo.pavilion_state ON dbo.pavilion.state_id = dbo.pavilion_state.state_id INNER JOIN
                  dbo.malls ON dbo.pavilion.mall_id = dbo.malls.mall_id INNER JOIN
                  dbo.mall_state ON dbo.malls.state_id = dbo.mall_state.state_id



				  
use mall
drop procedure dbo.update_pavil
go
create proc update_pavil
@pav_id int,
@name nvarchar(4),
@coef float,
@stat int,
@price money,
@lvl int,
@sqr float
as 
update pavilion
set pavilion_name = @name, state_id = @stat, squares = @sqr, price_per_one = @price, coeficent_price = @coef, lvl = @lvl
	where pavilion_id = @pav_id
go


use mall
drop procedure dbo.new_pavilion
go
create proc new_pavilion
@mall_id int,
@name nvarchar(4),
@coef float,
@stat int,
@price money,
@lvl int,
@sqr float
as 
insert into pavilion	(pavilion_name, state_id, squares,price_per_one,coeficent_price,lvl,mall_id)
	values (@name,@stat,@sqr,@price,@coef,@lvl,@mall_id)
declare @i int
go


go
drop trigger stat_mal
go
create trigger stat_mal
on malls
for update
as
if exists(select inserted.mall_id from inserted where inserted.state_id=4 or inserted.state_id=1)
	if exists(select inserted.mall_id from inserted inner join pavilion on inserted.mall_id = pavilion.mall_id where (inserted.state_id=4 or inserted.state_id=1) and (pavilion.state_id=2 or pavilion.state_id=1))
		rollback

go


drop trigger stat_pav
go

create trigger stat_pav
on pavilion
for update,delete
as
if exists(select inserted.pavilion_id from inserted inner join deleted on inserted.pavilion_id = deleted.pavilion_id  where inserted.state_id=deleted.state_id and( deleted.state_id=2 or deleted.state_id=1))
		rollback

go



use mall
drop procedure dbo.book_pav
go
create proc book_pav
@ten_id int,
@emp_id int,
@dat_start date,
@dat_end date,
@pav_id int
as 
insert into rent
	values (@ten_id,(select max(rent_id) from rent)+1,@emp_id,@dat_start,@dat_end,2,@pav_id)

go

drop trigger stat_rent_pav
go
create trigger stat_rent_pav
on rent
for update, insert
as
update pavilion
set state_id = 2
where pavilion_id in (select pavilion_id from inserted where state_id = 2)
update pavilion
set state_id = 1
where pavilion_id in (select pavilion_id from inserted where state_id = 1)
go

use mall
drop procedure dbo.rent_pav
go
create proc rent_pav
@ten_id int,
@emp_id int,
@dat_end date,
@pav_id int
as 
insert into rent
	values (@ten_id,(select max(rent_id) from rent)+1,@emp_id,GETDATE(),@dat_end,1,@pav_id)

go
enable trigger stat_pav on pavilion

go
exec dbo.rent_pav  1, 1, '2021-05-05' ,3
go


create view all_emp
as
SELECT dbo.emp.sur_name, dbo.emp.name, dbo.emp.login, dbo.emp.pat_name, dbo.emp.passwors, dbo.emp.phone_number, dbo.emp.gender, dbo.emp.emp_id, dbo.emp.role_id, dbo.emp.image, dbo.emp_role.role_name
FROM     dbo.emp INNER JOIN
                  dbo.emp_role ON dbo.emp.role_id = dbo.emp_role.role_id



use mall
drop procedure dbo.update_emp
go
create proc update_emp
@emp_id int,
@name nvarchar(35),
@fam nvarchar(35),
@pat nvarchar(35),
@login nvarchar(15),
@passwors nvarchar(15),
@phone nvarchar(20),
@gender char(1),
@role_id int,
@image nvarchar(200)
as 
update emp 
set emp.name = @name, emp.sur_name = @fam, emp.pat_name = @pat, emp.login =@login, emp.passwors = @passwors, emp.phone_number = @phone, emp.gender = @gender, emp.role_id = @role_id
	where emp.emp_id = @emp_id

	if (@image != 'err')
	exec load_emp_pic_only_path @emp_id, @image
go


use mall
drop procedure dbo.new_emp
go
create proc new_emp
@name nvarchar(35),
@fam nvarchar(35),
@pat nvarchar(35),
@login nvarchar(15),
@passwors nvarchar(15),
@phone nvarchar(20),
@gender char(1),
@role_id int,
@image nvarchar(200)
as 
insert into emp	(sur_name, emp.name, pat_name,emp.login,passwors,phone_number,gender,emp_id,role_id)
	values (@fam,@name,@pat,@login,@passwors,@phone,@gender,(select max(emp_id) from emp)+1,@role_id )
declare @i int
select @i = max(emp_id) from emp
if (@image != 'err')
exec load_emp_pic_only_path @i, @image
go


go 
exec dbo.new_emp 'test','test','test','test','test','test','M',1,'err'
go


				  
use mall
drop procedure dbo.update_tenant
go
create proc update_tenant
@id int,
@name nvarchar(35),
@addres nvarchar(35),
@phone_number nvarchar(35),
@town int

as 
update tenant
set rent_name = @name, phone_number = @phone_number, addres = @addres, town_id = @town
	where id_tenant = @id
go


use mall
drop procedure dbo.new_tenant
go
create proc new_tenant
@name nvarchar(35),
@addres nvarchar(35),
@phone_number nvarchar(35),
@town int
as 
insert into tenant	(rent_name, phone_number, addres,town_id, id_tenant)
	values (@name,@phone_number,@addres,@town,(select max(id_tenant) from tenant)+1)
go


use mall
go
create proc all_rent_tenet
@id int
as

SELECT dbo.malls.mall_name, dbo.town.town_name, dbo.pavilion.pavilion_name, dbo.rent.rent_start, dbo.rent.rent_end, dbo.pavilion.price_per_one * dbo.pavilion.squares * DATEDIFF(mm, dbo.rent.rent_start,dbo.rent.rent_end)  AS price, dbo.rent_state.state_name
FROM     dbo.malls INNER JOIN
                  dbo.town ON dbo.malls.town_id = dbo.town.town_id INNER JOIN
                  dbo.pavilion ON dbo.malls.mall_id = dbo.pavilion.mall_id INNER JOIN
                  dbo.rent INNER JOIN
                  dbo.rent_state ON dbo.rent.state_id = dbo.rent_state.state_id ON dbo.pavilion.pavilion_id = dbo.rent.pavilion_id

				  where tenant_id = @id
go

go 
exec dbo.all_rent_tenet 1




use mall
drop function dbo.mall_effective
go
create function mall_effective(@price_spent_mall money,@profit money)
returns varchar(5)
begin
declare @io float 
set @io = 100 - ((@price_spent_mall-@profit)/@price_spent_mall)*100
declare @o char(10)
return str(@io,3)+'%'
end
go
select dbo.mall_effective(120,100)

use mall
drop proc All_mall_stat
go
create proc All_mall_stat
as
SELECT m.mall_name, dbo.town.town_name, dbo.mall_effective(m.price,
( SELECT  sum(dbo.pavilion.price_per_one * dbo.pavilion.squares * DATEDIFF(mm, dbo.rent.rent_start,dbo.rent.rent_end))  AS price
FROM     dbo.malls INNER JOIN
                  dbo.town ON dbo.malls.town_id = dbo.town.town_id INNER JOIN
                  dbo.pavilion ON dbo.malls.mall_id = dbo.pavilion.mall_id INNER JOIN
                  dbo.rent INNER JOIN
                  dbo.rent_state ON dbo.rent.state_id = dbo.rent_state.state_id ON dbo.pavilion.pavilion_id = dbo.rent.pavilion_id

				  where m.mall_id = malls.mall_id
)) as price
FROM     dbo.malls as m INNER JOIN
                  dbo.town ON m.town_id = dbo.town.town_id 


go
exec  dbo.All_mall_stat
go

use mall
drop proc All_mall_pav_stat
go
create proc All_mall_pav_stat
@id int
as
SELECT m.mall_name, dbo.town.town_name, 
(select count(dbo.pavilion.pavilion_id) from dbo.pavilion where pavilion.mall_id = m.mall_id and pavilion.state_id = 3) as free_pav, 
m.count_pavilions,
(select count(dbo.pavilion.pavilion_id) from dbo.pavilion where pavilion.mall_id = m.mall_id and (pavilion.state_id = 1 or pavilion.state_id = 2)) as arend_pav,
(select sum(dbo.pavilion.squares) from dbo.pavilion where pavilion.mall_id = m.mall_id and pavilion.state_id = 3) as free_sqr,
(select avg(dbo.pavilion.price_per_one) from dbo.pavilion where pavilion.mall_id = m.mall_id and pavilion.state_id!=4) as avg_price_one_sqr
FROM     dbo.malls as m INNER JOIN
                  dbo.town ON m.town_id = dbo.town.town_id left JOIN
                  dbo.pavilion ON m.mall_id = dbo.pavilion.mall_id
				  where  m.mall_id = @id
				  group by  m.mall_name,dbo.town.town_name, m.count_pavilions, m.mall_id
				  
go

exec dbo.All_mall_pav_stat 4