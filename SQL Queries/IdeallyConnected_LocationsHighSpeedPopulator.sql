Use LocationsDb
Go

Create Type LocationType As Table(
	ZipCode varchar(5),
	State varchar(100),
	StateAbbreviation varchar(100),
	City varchar(200),
	County varchar(200),
	Population int,
	Latitude decimal(14,6),
	Longitude decimal(14,6),
	primary key(ZipCode, City))
Go

Create Procedure AddLocations
@LocationData LocationType READONLY
as
Insert Into Locations (ZipCode, State, StateAbbreviation, City, County, Population, Latitude, Longitude)
Select ZipCode, State, StateAbbreviation, City, County, Population, Latitude, Longitude
From @LocationData
Go
