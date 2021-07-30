use [Gym ]
Go
create proc Player_Add
@Name nvarchar(50) ,
  @gender nvarchar(20)
  ,@age nvarchar(50)
as

begin
insert into Players([Name],Gender,Age) values (@Name,@gender,@age)
end

Go
create proc trainer_Add
@Name nvarchar(50) ,
  @phone nvarchar(50)
  ,@gender nvarchar(50)
as

begin
insert into Trainers([Name],Phone,Gender) values (@Name,@phone,@gender)
end



Go
create proc prices_add
@type nvarchar(50) ,
  @price decimal(9,2)
  
as

begin
insert into Prices([type],price) values (@type,@price)
end
Go
create proc Registration_Add
@PlayerId int 
,@RegiterDate date ,@RegiterPriod int ,@TrainerId int ,@price decimal(9,2)
as

begin
insert into Registration(PlayerId,RegiterDate,RegiterPriod,TrainerId,EndDate,price)
values(@PlayerId,@RegiterDate,@RegiterPriod,@TrainerId,cast( DATEADD(day,@RegiterPriod,@RegiterDate) as date),@price)
end
go

create proc Attendance_Add
@PlayerId int 
,@DayDate date 
as

begin
insert into Attendance(PlayerId,DayDate)
values(@PlayerId,@DayDate)
end
go
----------------------------------------------------------------
create proc Registration_Delete
@PlayerId int ,
@RegisterDate date
as

begin
delete from Registration where   PlayerId = @PlayerId and RegiterDate = @RegisterDate
end
go
create proc players_Delete
@Id int 
as

begin
delete from Players where id = @Id 
end
go 
create proc attendance_Delete
@PlayerId int ,
@dayDate date
as

begin
delete from Attendance where   PlayerId = @PlayerId and DayDate = @dayDate 
end


go
create proc Trainers_Delete
@PlayerId int 

as

begin
delete from Trainers where  id = @PlayerId 
end
go
create proc Prices_Delete
@Id int 
as

begin
delete from Prices where   Id =@Id
end
go

----------------------------------------------------


create proc Player_Update
@id int ,
@Name nvarchar(50) ,
  @gender nvarchar(20)
  ,@age nvarchar(50)
as

begin 
update   Players 
set Age=@age,[Name]=@Name,Gender=@gender
where id=@id
end
go
create proc trainer_Update
@id int ,
@Name nvarchar(50) ,
@phone nvarchar(50) , 
  @gender nvarchar(50)
  
as

begin 
update Trainers 
set [Name]=@Name,Phone = @phone  ,Gender=@gender
where id=@id
end
go 


go
create proc prices_Update
@id int ,
@type nvarchar(50) ,
@price decimal(9,2)
  
as

begin 
update Prices
set [Type] = @type , Price=@price
where id=@id
end
go
create proc Registeration_Update

@PlayerId int ,
@RegisterDate date,

@regiterPriod int ,
@TrainerID int,
@price decimal(9,2)
  
as

begin 
update Registration 
set  price =@price ,TrainerID=@TrainerID,EndDate=cast( DATEADD(day,@RegiterPriod,@RegisterDate) as date)
where PlayerId=@PlayerId and RegiterDate=@RegisterDate 
end

-------------------------------------------------------------
go
create proc Player_GetAll
as

begin
select * from Players
end
-----------------------------------------------

go
create proc Player_GetByID
@id int
as

begin
select * from Players where id =@id
end
go
create proc Player_GetByName
@Name nvarchar(50)
as

begin
select * from Players where [Name] like  @Name
end
-----------------------------------------------



go
create proc attendance_GetAll
as

begin
select * from Attendance
end
-----------------------------------------------

go
create proc attendance_GetByPlyerID
@plyerid int

as

begin
select * from Attendance where  PlayerId= @plyerid
end
go

create proc Attendance_GetByDayDate
@DayDate date
as

begin
select * from Attendance where DayDate=  @DayDate
end
go
create proc Attendance_GetByDayDate_Id
@DayDate date,
@PlayerId int
as

begin
select * from Attendance where DayDate=  @DayDate  and PlayerId=@PlayerId
end
----------------------------------------------------
go
create proc price_GetAll
as

begin
select * from Prices
end
-----------------------------------------------

go
create proc price_GetByID
@id int

as

begin
select * from Prices where  id= @id
end
go

create proc price_GetByType
@type nvarchar(50)
as

begin
select * from Prices where  [Type]=@type
end
------------------------------------
go
create proc registriton_GetByall
as

begin
select * from Prices 
end

 go
create proc registertion_GetByplayerID
@playerid int

as

begin
select * from Registration where PlayerId = @playerid
end
go

create proc regetration_GetByregesterdate
@regesterdate date
as

begin
select * from Registration where RegiterDate = @regesterdate
end
go

create proc regetration_GetByregesterdate_id
@regesterdate date , 
@playerid int
as

begin
select * from Registration where RegiterDate = @regesterdate   and PlayerId = @playerid
end


go

create proc regetration_GetByEndDate
@enddate date 

as

begin
select * from Registration where EndDate = @enddate
end


go

create proc regetration_GetByTrainerId
@trainerid int

as

begin
select * from Registration where TrainerId = @trainerid
end
--------------------------------------
go
create proc		Trainers_GetAll

as

begin
select * from Trainers
end
go

create proc		Trainers_GetAllById
@id int

as

begin
select * from Trainers where id=@id
end
go 


create proc		Trainers_GetAllByName
@Name nvarchar(50)

as

begin
select * from Trainers where [Name]=@Name
end
go 





