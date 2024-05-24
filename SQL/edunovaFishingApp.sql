use master;
go
drop database if exists fishingApp;
go
create database fishingApp;
go

use fishingApp;

create table "user"(
	id int not null primary key identity(1,1),
	email varchar(255) not null,
	password char(255) not null,
	first_name varchar(255) not null,
	last_name varchar(255) not null,
	role varchar(255) not null,
	oib char(11),
	license_number char(6)
);

create table fish(
	id int not null primary key identity(1,1),
	name varchar(255) not null,
	hunt_start date not null,
	hunt_end date not null,
	description text
);

create table river(
	id int not null primary key identity(1,1),
	name varchar(255) not null,
	length varchar(255) not null
);

create table fishing(
	id int not null primary key identity(1,1),
	date date not null,
	"user" int not null,
	fish int not null,
	quantity int,
	weight decimal(18,3),
	river int not null
);

alter table fishing add foreign key (river) references river(id);
alter table fishing add foreign key ("user") references "user"(id);
alter table fishing add foreign key (fish) references fish(id);