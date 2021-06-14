SELECT dbo.arendodat1.[ID Аренды] AS rent_id, dbo.arendodat1.[Название ] AS rent_name, dbo.arendodat1.Номер AS phone_number, dbo.arendodat1.Адрес AS addres, dbo.arendodat1.[ID Арендатора] AS id_tenant, dbo.town.town_id into tenant
FROM     dbo.arendodat1 INNER JOIN
                  dbo.town ON dbo.arendodat1.Город = dbo.town.town_name



SELECT DISTINCT Статус AS state_name into mall_state
FROM     dbo.mals

SELECT distinct Город AS town_name into town
FROM     dbo.mals

SELECT DISTINCT 
                  dbo.mals.Название AS mall_name, dbo.mall_state.state_id, dbo.mals.[Кол# Повильонов] AS count_pavilions, dbo.town.town_id, dbo.mals.Стоимость AS price, dbo.mals.[Кооф Добавочной Стоимости] AS coeficent_price, 
                  dbo.mals.Этажность AS count_lvl, dbo.mals.Изображение 
FROM     dbo.mals INNER JOIN
                  dbo.mall_state ON dbo.mals.Статус = dbo.mall_state.state_name INNER JOIN
                  dbo.town ON dbo.mals.Город = dbo.town.town_name

SELECT DISTINCT Статус as state_name into pavilion_state
FROM     dbo.pavil

SELECT DISTINCT 
                  dbo.pavil.[№ Павильона] AS pavilion_id, dbo.malls.mall_id, dbo.pavilion_state.state_id, dbo.pavil.Этаж AS lvl, dbo.pavil.Площадь AS squares, dbo.pavil.[Стоимость за квм] AS price_per_one, 
                  dbo.pavil.[Кооф Добавочной стоимости] AS coeficent_price into pavilion
FROM     dbo.pavil INNER JOIN
                  dbo.pavilion_state ON dbo.pavil.Статус = dbo.pavilion_state.state_name INNER JOIN
                  dbo.malls ON dbo.pavil.[Название ТЦ] = dbo.malls.mall_name


SELECT DISTINCT Роль AS role_name into emp_role
FROM     dbo.sot


SELECT DISTINCT 
                  dbo.sot.ФИО AS sur_name, dbo.sot.Имя AS name, dbo.sot.Отчество AS pat_name, dbo.sot.Логин AS login, dbo.sot.Пароль AS passwors, dbo.sot.[Номер телефона] AS phone_number, dbo.sot.Пол AS gender, dbo.sot.ID AS emp_id, 
                  dbo.sot.Фото AS image, dbo.emp_role.role_id into emp
FROM     dbo.sot INNER JOIN
                  dbo.emp_role ON dbo.sot.Роль = dbo.emp_role.role_name



SELECT DISTINCT Статус AS state_name into rent_state
FROM     dbo.Лист1$


SELECT DISTINCT 
                  dbo.Лист1$.[ID Арендатора] AS tenant_id, dbo.Лист1$.[ID Аренды] AS rent_id, dbo.Лист1$.[ID Сотрудник] AS emp_id, dbo.Лист1$.[Начало Аренды] AS rent_start, dbo.Лист1$.[Окончание Аренды] AS rent_end, 
                  dbo.rent_state.state_id, dbo.pavilion.pavilion_id into rent
FROM     dbo.Лист1$ INNER JOIN
                  dbo.rent_state ON dbo.Лист1$.Статус = dbo.rent_state.state_name INNER JOIN
                  dbo.malls ON dbo.Лист1$.[Название ТЦ] = dbo.malls.mall_name INNER JOIN
                  dbo.pavilion ON dbo.malls.mall_id = dbo.pavilion.mall_id AND dbo.Лист1$.[№ Павильона] = dbo.pavilion.pavilion_name


