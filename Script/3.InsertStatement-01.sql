USE MusicBrainz
GO 

--insert into artist table

INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab ', 'Metallica ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('650e7db6-b795-4eb5-a702-5ea2fc46c848 ', 'Lady Gaga ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('c44e9c22-ef82-4a77-9bcd-af6c958446d6 ', 'Mumford & Sons ', 'GB');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('435f1441-0f43-479d-92db-a506449a686b ', 'Mott the Hoople ', 'GB');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('a9044915-8be3-4c7e-b11f-9e2d2ea0a91e ', 'Megadeth', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('b625448e-bf4a-41c3-a421-72ad46cdb831 ', 'John Coltrane ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('d700b3f5-45af-4d02-95ed-57d301bda93e ', 'Mogwai ', 'GB');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('144ef525-85e9-40c3-8335-02c32d0861f3 ', 'John Mayer ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f ', 'Johnny Cash', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('6456a893-c1e9-4e3d-86f7-0008b0a3ac8a ', 'Jack Johnson ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('f1571db1-c672-4a54-a2cf-aaa329f26f0b ', 'John Frusciante ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('b83bc61f-8451-4a5d-8b8e-7e9ed295e822 ', 'Elton John ', 'GB');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('24f8d8a5-269b-475c-a1cb-792990b0b2ee ', 'Rancid ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699 ', 'Transplants ', 'US');
INSERT INTO Artist (ArtistId, ArtistName, Country) VALUES ('931e1d1f-6b2f-4ff8-9f70-aa537210cd46 ', 'Operation Ivy ', 'US');
GO

--Insert into Albums
INSERT INTO Albums (ReleaseId,ArtistId,Title,Status,Label,NumberOfTracks)
VALUES ('FDCA9FA4-310F-43B0-831F-6D31701DE524','435f1441-0f43-479d-92db-a506449a686b','TomorrowLand : begium2022','Official','Reddington disc',5);
INSERT INTO Albums (ReleaseId,ArtistId,Title,Status,Label,NumberOfTracks)
VALUES ('514DFCAA-80E8-45FE-B2F6-1584B8CA6345','144ef525-85e9-40c3-8335-02c32d0861f3','TopChart:2023','Official','Reddington disc',5);
INSERT INTO Albums (ReleaseId,ArtistId,Title,Status,Label,NumberOfTracks)
VALUES ('6B2D94B6-C4BC-4B49-ACEB-C7693B9D2869','c44e9c22-ef82-4a77-9bcd-af6c958446d6','EDM: begium2023','Official','Ivy studio',10);
INSERT INTO Albums (ReleaseId,ArtistId,Title,Status,Label,NumberOfTracks)
VALUES ('332CD21B-F2C3-4A5E-A2AD-7538E8E8D1CF','931e1d1f-6b2f-4ff8-9f70-aa537210cd46','Get busy : euro tour','Official','red series records',8);
INSERT INTO Albums (ReleaseId,ArtistId,Title,Status,Label,NumberOfTracks)
VALUES ('E0D87E47-96D6-449C-BFDD-B94964E580D5','c44e9c22-ef82-4a77-9bcd-af6c958446d6','Top Fan : fan club','Official','Charlton studio',7);
GO

--insert into Aliases
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('6FC91204-C6BD-4038-8F82-BF4D8CBFDE50','65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab ','Metalica,메탈리카');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('5E706F7E-0B9F-4E70-8740-DF8D1D9D2AEB','650e7db6-b795-4eb5-a702-5ea2fc46c848 ','Lady Ga Ga,Stefani Joanne Angelina Germanotta');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('DFD3EAC7-7084-43D5-B25A-6EA479B007EC','c44e9c22-ef82-4a77-9bcd-af6c958446d6 ','');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('9EDB6644-C086-4393-B944-CF0785C556E0','435f1441-0f43-479d-92db-a506449a686b ','Mott The Hoppie,Mott The Hopple');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('23C715CC-8308-4AF2-BDF8-CEE752CDA435','a9044915-8be3-4c7e-b11f-9e2d2ea0a91e ','Megadeath ');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('6E0C133A-CEA2-4B15-B3C1-0CFCC0770233','b625448e-bf4a-41c3-a421-72ad46cdb831 ','John Coltraine,John William Coltrane');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('2ACC2836-B631-493A-820C-BC12BD95FD3C','d700b3f5-45af-4d02-95ed-57d301bda93e ','Mogwa ');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('74B0B94F-338C-4FC9-B201-C2FF0777F556','144ef525-85e9-40c3-8335-02c32d0861f3 ','');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('0ABC6F5B-7148-4883-BFC1-919513FC1DD3','18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f ','Johhny Cash,Jonny Cash');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('4F1AA4A4-9ED7-434A-B3E6-D67E9D840C30','6456a893-c1e9-4e3d-86f7-0008b0a3ac8a ','Jack Hody Johnson ');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('CC49E36D-307C-438A-942B-C6A377732154','f1571db1-c672-4a54-a2cf-aaa329f26f0b ','John Anthony Frusciante ');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('C7F3673B-20A5-4BA5-91FE-1BDC5FB0F563','b83bc61f-8451-4a5d-8b8e-7e9ed295e822 ', 'E. John, Elthon John,Elton Jphn,John Elton, Reginald Kenneth Dwight');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('850A5F4D-04D3-4E8B-9AAE-D9FA0296A6F0','24f8d8a5-269b-475c-a1cb-792990b0b2ee ', 'ランシド ');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('7E722011-F80A-4932-B927-9D3B339C4110','29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699 ', 'The Transplants ');
INSERT INTO Aliases (AliasesId, ArtistId, Alias) VALUES ('0B60C57A-97C9-4FA5-AD22-578C98910E3D','931e1d1f-6b2f-4ff8-9f70-aa537210cd46 ', 'Op Ivy ');
go

--insert ino Featuring Artist
INSERT INTO FeaturingArtist(FeaturingArtistId,ReleaseId,ArtistId)VALUES ('5B88238C-1D10-4CBE-8D1B-99CF8766B555','FDCA9FA4-310F-43B0-831F-6D31701DE524','c44e9c22-ef82-4a77-9bcd-af6c958446d6');
INSERT INTO FeaturingArtist(FeaturingArtistId,ReleaseId,ArtistId)VALUES ('24CAF5C7-2295-4E79-8B98-EF9D49DC004F','6B2D94B6-C4BC-4B49-ACEB-C7693B9D2869','b625448e-bf4a-41c3-a421-72ad46cdb831');
INSERT INTO FeaturingArtist(FeaturingArtistId,ReleaseId,ArtistId)VALUES ('9C9BF5D0-C96F-4BBF-A470-6674D42BFAA0','FDCA9FA4-310F-43B0-831F-6D31701DE524','c44e9c22-ef82-4a77-9bcd-af6c958446d6');
INSERT INTO FeaturingArtist(FeaturingArtistId,ReleaseId,ArtistId)VALUES ('1E46EDC2-44E5-4F79-BF8D-532A63AFB1BA','FDCA9FA4-310F-43B0-831F-6D31701DE524','c44e9c22-ef82-4a77-9bcd-af6c958446d6');
INSERT INTO FeaturingArtist(FeaturingArtistId,ReleaseId,ArtistId)VALUES ('3D921EDC-D30E-43B0-B877-247CF97DEC0E','E0D87E47-96D6-449C-BFDD-B94964E580D5','b625448e-bf4a-41c3-a421-72ad46cdb831');
GO

