USE MusicBrainz
GO

--Create Table Artist
CREATE TABLE Artist(
ArtistId Varchar(32) NOT NULL PRIMARY KEY,
ArtistName Varchar(50) NOT NULL,
Country Varchar(2) NOT NULL,
Aliases Varchar(255) NULL
)
GO

CREATE CLUSTERED INDEX IX_Artist_ArtistId ON Artist(ArtistId)

GO

--Create Table Albums
CREATE TABLE ALBUMS(

)
GO