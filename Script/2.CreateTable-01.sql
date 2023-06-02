USE MusicBrainz
GO

--Create Table Artist
CREATE TABLE Artist(
ArtistId Varchar(40) NOT NULL PRIMARY KEY,
ArtistName Varchar(50) NOT NULL,
Country Varchar(2) NOT NULL,
)
GO

CREATE NONCLUSTERED INDEX IX_Artist_ArtistId ON Artist(ArtistId)

GO

--Create Table Albums
CREATE TABLE Albums(
ReleaseId Varchar(40) NOT NULL PRIMARY KEY,
ArtistId Varchar(40) NOT NULL FOREIGN KEY REFERENCES Artist(ArtistId),
Title Varchar(255), 
Status Varchar(30),
Label Varchar(50), 
NumberOfTracks int
)
GO
CREATE NONCLUSTERED INDEX IX_Albums_ReleaseId ON ALBUMS(ReleaseId)
GO

--Create FeaturingArtist
CREATE TABLE FeaturingArtist(
FeaturingArtistId Varchar(40) NOT NULL PRIMARY KEY,
ReleaseId Varchar(40) NOT NULL FOREIGN KEY REFERENCES Albums(ReleaseId),
ArtistId Varchar(40) NOT NULL FOREIGN KEY REFERENCES Artist(ArtistId)
)

GO 
CREATE NONCLUSTERED INDEX IX_FeaturingArtist_ReleaseId ON FeaturingArtist(ReleaseId)
GO
CREATE NONCLUSTERED INDEX IX_FeaturingArtist_ArtistId ON FeaturingArtist(ArtistId)
GO

--Create Table Aliases
CREATE TABLE Aliases(
AliasesId Varchar(40) NOT NULL PRIMARY KEY,
ArtistId Varchar(40) NOT NULL FOREIGN KEY REFERENCES Artist(ArtistId),
Alias Varchar(255)
)
GO
CREATE NONCLUSTERED INDEX IX_Aliases_ArtistId ON Aliases(ArtistId)
GO