create database HR
go
use HR

create table Employee
(
IdEmployee char(10) primary key, 
Name nvarchar(255), 
DateBirth datetime, 
Gender bit, 
PlaceBirth nvarchar(255), 
IdDepartment char(5)
)

go 
create table Departmen(
IdDepartment char(5) primary key,
Name nvarchar(255)
)

go
ALTER TABLE Employee
ADD FOREIGN KEY (IdDepartment) REFERENCES dbo.Departmen(IdDepartment);

go
insert into Employee values('C53418',N'Trần Tiến', 11/10/2000,1,N'Hà Nội', 'KT')
go
insert into Employee values('X53416', N'Nguyễn Cường', 21/07/1999, 0, N'Đắk Lắk', 'KD')
go
insert into Employee values('M53417', N'Nguyễn Hào', 25/12/2001, 1, N'TP.Hồ Chí Minh', 'NS')

go
insert into Departmen values('NS', N'Nhân sự')
insert into Departmen values('KT', N'Kế toán')
insert into Departmen values('KD', N'Kinh doanh')

select*from Employee
select*from Departmen

