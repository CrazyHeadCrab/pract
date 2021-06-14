SELECT dbo.arendodat1.[ID ������] AS rent_id, dbo.arendodat1.[�������� ] AS rent_name, dbo.arendodat1.����� AS phone_number, dbo.arendodat1.����� AS addres, dbo.arendodat1.[ID ����������] AS id_tenant, dbo.town.town_id into tenant
FROM     dbo.arendodat1 INNER JOIN
                  dbo.town ON dbo.arendodat1.����� = dbo.town.town_name



SELECT DISTINCT ������ AS state_name into mall_state
FROM     dbo.mals

SELECT distinct ����� AS town_name into town
FROM     dbo.mals

SELECT DISTINCT 
                  dbo.mals.�������� AS mall_name, dbo.mall_state.state_id, dbo.mals.[���# ����������] AS count_pavilions, dbo.town.town_id, dbo.mals.��������� AS price, dbo.mals.[���� ���������� ���������] AS coeficent_price, 
                  dbo.mals.��������� AS count_lvl, dbo.mals.����������� 
FROM     dbo.mals INNER JOIN
                  dbo.mall_state ON dbo.mals.������ = dbo.mall_state.state_name INNER JOIN
                  dbo.town ON dbo.mals.����� = dbo.town.town_name

SELECT DISTINCT ������ as state_name into pavilion_state
FROM     dbo.pavil

SELECT DISTINCT 
                  dbo.pavil.[� ���������] AS pavilion_id, dbo.malls.mall_id, dbo.pavilion_state.state_id, dbo.pavil.���� AS lvl, dbo.pavil.������� AS squares, dbo.pavil.[��������� �� ���] AS price_per_one, 
                  dbo.pavil.[���� ���������� ���������] AS coeficent_price into pavilion
FROM     dbo.pavil INNER JOIN
                  dbo.pavilion_state ON dbo.pavil.������ = dbo.pavilion_state.state_name INNER JOIN
                  dbo.malls ON dbo.pavil.[�������� ��] = dbo.malls.mall_name


SELECT DISTINCT ���� AS role_name into emp_role
FROM     dbo.sot


SELECT DISTINCT 
                  dbo.sot.��� AS sur_name, dbo.sot.��� AS name, dbo.sot.�������� AS pat_name, dbo.sot.����� AS login, dbo.sot.������ AS passwors, dbo.sot.[����� ��������] AS phone_number, dbo.sot.��� AS gender, dbo.sot.ID AS emp_id, 
                  dbo.sot.���� AS image, dbo.emp_role.role_id into emp
FROM     dbo.sot INNER JOIN
                  dbo.emp_role ON dbo.sot.���� = dbo.emp_role.role_name



SELECT DISTINCT ������ AS state_name into rent_state
FROM     dbo.����1$


SELECT DISTINCT 
                  dbo.����1$.[ID ����������] AS tenant_id, dbo.����1$.[ID ������] AS rent_id, dbo.����1$.[ID ���������] AS emp_id, dbo.����1$.[������ ������] AS rent_start, dbo.����1$.[��������� ������] AS rent_end, 
                  dbo.rent_state.state_id, dbo.pavilion.pavilion_id into rent
FROM     dbo.����1$ INNER JOIN
                  dbo.rent_state ON dbo.����1$.������ = dbo.rent_state.state_name INNER JOIN
                  dbo.malls ON dbo.����1$.[�������� ��] = dbo.malls.mall_name INNER JOIN
                  dbo.pavilion ON dbo.malls.mall_id = dbo.pavilion.mall_id AND dbo.����1$.[� ���������] = dbo.pavilion.pavilion_name


