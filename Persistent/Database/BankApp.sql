create database BankApp

use BankApp


create table dbo.[User]
(
	Id int primary key identity(1,1),
	FullName varchar(255) not null,
	DateOfBirth date not null,
	Gender varchar(255) not null 
);

/*
	This table should only accept a type of Admin and Client
	and nothing else.
*/
create table [Role]
(
	Id int primary key identity(1,1),
	[Type] varchar(100) not null check([Type] = 'Admin' or Type = 'Client'), 
);