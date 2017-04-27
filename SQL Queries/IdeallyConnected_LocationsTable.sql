Create Database LocationsDb
Go

Use LocationsDb
Go

Create Table Locations(
	ZipCode varchar(5),
	State varchar(100),
	StateAbbreviation varchar(100),
	City varchar(200),
	County varchar(200),
	Population int,
	Latitude decimal(14,6),
	Longitude decimal(14,6),
	primary key(ZipCode, City)
	)
Go

/*
Create Procedure LocationReader
@ZipCode varchar(50),
@State varchar(50),
@StateAbbreviation varchar(5),
@City varchar(50),
@County varchar(50),
@Population int,
@Latitude decimal(14,6),
@Longitude decimal(14,6)
as
Insert Into Locations (ZipCode, State, StateAbbreviation, City, County, Population, Latitude, Longitude)
Values(@Zipcode, @State, @StateAbbreviation, @City, @County, @Population, @Latitude, @Longitude)
Go

*/
