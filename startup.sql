----###############################
/*
 $$$$$$$$$    WARNING    $$$$$$$$$

 NEVER commit credentials!

 This is example script, don't do that in real application!

 DO NOT use it on production environment!
*/

/*
	Serever contains database AdventureWorks
	1 - add 2 databases: HardkorowyKodsu01, HardkorowyKodsu02
	2 - add 3 logins: HardkorowyKodsuUser01, HardkorowyKodsuUser02, HardkorowyKodsuUser03
	3 - create users, map them to the logins and give them db_datareader role
	(database)		(users)
	AdventureWorks		HardkorowyKodsuUser01, HardkorowyKodsuUser02, HardkorowyKodsuUser03
	HardkorowyKodsu01	HardkorowyKodsuUser01, HardkorowyKodsuUser03
	HardkorowyKodsu02	HardkorowyKodsuUser02, HardkorowyKodsuUser03

	ie:
		HardkorowyKodsuUser01 has access to AdventureWorks and HardkorowyKodsuUser01
		HardkorowyKodsuUser02 has access to AdventureWorks and HardkorowyKodsuUser02
		HardkorowyKodsuUser03 has access to all above databases
	4 - create some objects (tables, views) in databases: HardkorowyKodsu01, HardkorowyKodsu02
*/

use master
go

create database [HardkorowyKodsu01]
go

create database [HardkorowyKodsu02]
go

create login [HardkorowyKodsuUser01] with password = 'Sd8tgowki9clengfustyzma' 
go

create login [HardkorowyKodsuUser02] with password = 'Hq3jstymp0nitrazys6rtobcij' 
go

create login [HardkorowyKodsuUser03] with password = 'jus7hrypbind0strYvaxcka4ryn' 
go

use [AdventureWorks]
go

create user [HardkorowyKodsuUser01] for login [HardkorowyKodsuUser01];
create user [HardkorowyKodsuUser02] for login [HardkorowyKodsuUser02];
create user [HardkorowyKodsuUser03] for login [HardkorowyKodsuUser03];

alter role db_datareader add member [HardkorowyKodsuUser01];
alter role db_datareader add member [HardkorowyKodsuUser02];
alter role db_datareader add member [HardkorowyKodsuUser03];
go

use [HardkorowyKodsu01]
go

create user [HardkorowyKodsuUser01] for login [HardkorowyKodsuUser01];
create user [HardkorowyKodsuUser03] for login [HardkorowyKodsuUser03];

alter role db_datareader add member [HardkorowyKodsuUser01];
alter role db_datareader add member [HardkorowyKodsuUser03];
go

use [HardkorowyKodsu02]
go

create user [HardkorowyKodsuUser02] for login [HardkorowyKodsuUser02];
create user [HardkorowyKodsuUser03] for login [HardkorowyKodsuUser03];

alter role db_datareader add member [HardkorowyKodsuUser02];
alter role db_datareader add member [HardkorowyKodsuUser03];
go

use [HardkorowyKodsu01]
go

create schema request
go
create schema client
go
create schema backoffice
go

create table request.tenant
(
id int not null identity(1,1)
,[name] varchar(80) not null
, constraint pk_tenant primary key (id)
, constraint uq_tenant unique ([name])
);
go

create table request.shop
(
id int not null identity(1,1)
, id_tenant int not null
,[name] varchar(80) not null
, constraint pk_shop primary key (id)
, constraint fk_shop_tenant foreign key (id_tenant) references request.tenant(id)
, constraint uq_shop unique ([name])
);
go

create table client.well_known_client
(
id int not null identity(1,1)
, id_tenant int not null
,fname varchar(80) not null
,lname varchar(80) not null
, constraint pk_well_known_client primary key (id)
, constraint fk_well_known_client_tenant foreign key (id_tenant) references request.tenant(id)
, constraint uq_well_known_client unique (fname,lname)
);
go

create view backoffice.tenant_shops
as
	select
		t.[name] as tname
		, s.[name] as sname
		from
			request.tenant t
			inner join request.shop s on t.id = s.id_tenant
go

use [HardkorowyKodsu02]
go

create table dbo.[configuration]
(
id int not null identity(1,1)
, [name] varchar(80) not null
, [value] varchar(max) null
, constraint pk_configuration primary key (id)
, constraint uq_configuration unique ([name])
);
go
