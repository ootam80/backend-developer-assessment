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

CREATE NONCLUSTERED INDEX IX_Artist_ArtistId ON Artist(ArtistId)

GO

--Create Table Albums
CREATE TABLE Albums(
ReleaseId uniqueidentifier default newid() NOT NULL PRIMARY KEY,
ArtistId Varchar(32) NOT NULL,
Title Varchar(255), 
Status Varchar(30),
Label Varchar(50), 
NumberOfTracks Varchar(2),
OtherArtist nvarchar(MAX),
CONSTRAINT FK_ArtistAlbums FOREIGN KEY (ArtistId)
    REFERENCES Artist(ArtistId)
)
GO

CREATE NONCLUSTERED INDEX IX_Albums_ReleaseId ON ALBUMS(ReleaseId)

GO