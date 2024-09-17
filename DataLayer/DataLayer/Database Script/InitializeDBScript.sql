CREATE DATABASE MusicBrainz
GO

USE MusicBrainz
GO

--Create Table Artist
CREATE TABLE Artist(
ArtistId bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
ArtistName varchar(max) NOT NULL,
Country varchar(max) NOT NULL,
UniqueIdentifier varchar(max) NOT NULL
)
GO

--Create Table Alias
CREATE TABLE Alias(
AliasId bigint NOT NULL IDENTITY(1,1) PRIMARY KEY,
ArtistId bigint NOT NULL FOREIGN KEY REFERENCES Artist(ArtistId),
AliasDescription varchar(max)
)
GO

--Insert into artist table
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Metallica', 'US', '65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Lady Gaga', 'US', '650e7db6-b795-4eb5-a702-5ea2fc46c848');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Mumford & Sons', 'GB', 'c44e9c22-ef82-4a77-9bcd-af6c958446d6');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Mott the Hoople', 'GB', '435f1441-0f43-479d-92db-a506449a686b');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Megadeth', 'US', 'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('John Coltrane', 'US', 'b625448e-bf4a-41c3-a421-72ad46cdb831');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Mogwai', 'GB', 'd700b3f5-45af-4d02-95ed-57d301bda93e');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('John Mayer', 'US', '144ef525-85e9-40c3-8335-02c32d0861f3');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Johnny Cash', 'US', '18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Jack Johnson', 'US', '6456a893-c1e9-4e3d-86f7-0008b0a3ac8a');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('John Frusciante', 'US', 'f1571db1-c672-4a54-a2cf-aaa329f26f0b');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Elton John', 'GB', 'b83bc61f-8451-4a5d-8b8e-7e9ed295e822');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Rancid', 'US', '24f8d8a5-269b-475c-a1cb-792990b0b2ee');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Transplants', 'US', '29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699');
INSERT INTO Artist (ArtistName, Country, UniqueIdentifier) VALUES ('Operation Ivy', 'US', '931e1d1f-6b2f-4ff8-9f70-aa537210cd46');
GO

--Insert into alias table
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (1, 'Metalica');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (1, '메탈리카');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (2, 'Lady Ga Ga');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (2, 'Stefani Joanne Angelina Germanotta');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (4, 'Mott The Hoppie');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (4, 'Mott The Hopple');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (5, 'Megadeath');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (6, 'John Coltraine');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (6, 'John William Coltrane');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (7, 'Mogwa');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (8, 'John Clayton Mayer');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (9, 'Johhny Cash');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (9, 'Jonny Cash');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (10, 'Jack Hody Johnson');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (11, 'John Anthony Frusciante');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (12, 'E. John');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (12, 'Elthon John');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (12, 'Elton Jphn');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (12, 'John Elton');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (12, 'Reginald Kenneth Dwight');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (13, 'ランシド');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (14, 'The Transplants');
INSERT INTO Alias (ArtistId, AliasDescription) VALUES (15, 'Op Ivy');
