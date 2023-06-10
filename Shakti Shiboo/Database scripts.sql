USE [master]
GO
/****** Object:  Database [MusicArtist]    Script Date: 10/06/2023 12:16:15 ******/
CREATE DATABASE [MusicArtist]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MusicArtist', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MusicArtist.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MusicArtist_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MusicArtist_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MusicArtist] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicArtist].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicArtist] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicArtist] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicArtist] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicArtist] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicArtist] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicArtist] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MusicArtist] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicArtist] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicArtist] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicArtist] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicArtist] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicArtist] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicArtist] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicArtist] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicArtist] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MusicArtist] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicArtist] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicArtist] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicArtist] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicArtist] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicArtist] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicArtist] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicArtist] SET RECOVERY FULL 
GO
ALTER DATABASE [MusicArtist] SET  MULTI_USER 
GO
ALTER DATABASE [MusicArtist] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicArtist] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicArtist] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicArtist] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MusicArtist] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MusicArtist] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MusicArtist', N'ON'
GO
ALTER DATABASE [MusicArtist] SET QUERY_STORE = ON
GO
ALTER DATABASE [MusicArtist] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MusicArtist]
GO
/****** Object:  User [IIS APPPOOL\MusicArtist]    Script Date: 10/06/2023 12:16:16 ******/
CREATE USER [IIS APPPOOL\MusicArtist] FOR LOGIN [IIS APPPOOL\MusicArtist] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ArtistUser]    Script Date: 10/06/2023 12:16:16 ******/
CREATE USER [ArtistUser] FOR LOGIN [ArtistUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Alias]    Script Date: 10/06/2023 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alias](
	[AliasId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ArtistId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Alias] PRIMARY KEY CLUSTERED 
(
	[AliasId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 10/06/2023 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CountryId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Artist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 10/06/2023 12:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](2) NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'b6d21599-9206-4f00-a9d9-143949ba5b57', N'Reginald Kenneth Dwight', N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'0de8c834-a0cf-4927-83eb-14a69e158d50', N'Megadeath', N'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'c642f559-9997-40ed-928b-151f5c1aaaee', N'John Elton', N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'a17b7c67-adb5-421f-9e27-158ee2f6302b', N'Elthon John', N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'5b82878b-252a-431b-8c04-2f0c70127ee5', N'Elton Jphn', N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'743581e9-d878-43db-a7d8-30ef67fc9b37', N'메탈리카', N'65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'b8cb20b6-0be4-4568-80a2-49df1d0f5c1a', N'Stefani Joanne Angelina Germanotta', N'650e7db6-b795-4eb5-a702-5ea2fc46c848')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'79216a76-ea2c-4c42-9326-82959cf38125', N'Jack Hody Johnson', N'6456a893-c1e9-4e3d-86f7-0008b0a3ac8a')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'2f92b9ba-0bf9-4c16-8eb4-888e1877628b', N'Metalica', N'65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'0a47c46e-74df-41e9-8fdd-900a01d67081', N'Mogwa', N'd700b3f5-45af-4d02-95ed-57d301bda93e')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'9cd9707a-08eb-49e4-86aa-a7712950eea9', N'E. John', N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'4884c4d6-ca34-4373-9f8c-abddf6790608', N'The Transplants', N'29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'bc20fc27-407d-4183-8d78-b68cb2fe52e7', N'John Coltraine', N'b625448e-bf4a-41c3-a421-72ad46cdb831')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'9cd0e1c6-9cf6-40ef-90d4-cd5e7e7218c0', N'ランシド', N'24f8d8a5-269b-475c-a1cb-792990b0b2ee')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'47180f14-44d2-4407-8747-d289ee9192ac', N'John William Coltrane', N'b625448e-bf4a-41c3-a421-72ad46cdb831')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'30bdcd3c-8183-4b3f-9691-d63dc8609776', N'Jonny Cash', N'18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'77925c52-2aae-4895-90bd-e058fa9293b9', N'Op Ivy', N'931e1d1f-6b2f-4ff8-9f70-aa537210cd46')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'f22deb06-8bc6-439b-b68b-eaba2e627833', N'Mott The Hoppie', N'435f1441-0f43-479d-92db-a506449a686b')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'97f7b1af-baed-4892-b478-ed77e02e983b', N'John Anthony Frusciante', N'f1571db1-c672-4a54-a2cf-aaa329f26f0b')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'c2b01a4d-77a4-4866-96fa-f1e40498ed98', N'Johhny Cash', N'18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'ae2f587c-5a62-415c-9714-f2633a468dca', N'Mott The Hopple', N'435f1441-0f43-479d-92db-a506449a686b')
GO
INSERT [dbo].[Alias] ([AliasId], [Name], [ArtistId]) VALUES (N'd411ea9a-df23-4761-8717-f2d6c5311d7f', N'Lady Ga Ga', N'650e7db6-b795-4eb5-a702-5ea2fc46c848')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'6456a893-c1e9-4e3d-86f7-0008b0a3ac8a', N'Jack Johnson', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'144ef525-85e9-40c3-8335-02c32d0861f3', N'John Mayer', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'29f3e1bf-aec1-4d0a-9ef3-0cb95e8a3699', N'Transplants', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'd700b3f5-45af-4d02-95ed-57d301bda93e', N'Mogwai', N'4062d608-ea35-4f0d-b406-d5e280d1342e')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'650e7db6-b795-4eb5-a702-5ea2fc46c848', N'Lady Gaga', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'18fa2fd5-3ef2-4496-ba9f-6dae655b2a4f', N'Johnny Cash', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'b625448e-bf4a-41c3-a421-72ad46cdb831', N'John Coltrane', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'24f8d8a5-269b-475c-a1cb-792990b0b2ee', N'Rancid', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'b83bc61f-8451-4a5d-8b8e-7e9ed295e822', N'Elton John', N'4062d608-ea35-4f0d-b406-d5e280d1342e')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab', N'Metallica', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'a9044915-8be3-4c7e-b11f-9e2d2ea0a91e', N'Megadeth', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'435f1441-0f43-479d-92db-a506449a686b', N'Mott the Hoople', N'4062d608-ea35-4f0d-b406-d5e280d1342e')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'931e1d1f-6b2f-4ff8-9f70-aa537210cd46', N'Operation Ivy', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'f1571db1-c672-4a54-a2cf-aaa329f26f0b', N'John Frusciante', N'7a8f669e-20e3-4404-94ea-82117c39a7bb')
GO
INSERT [dbo].[Artist] ([ArtistId], [Name], [CountryId]) VALUES (N'c44e9c22-ef82-4a77-9bcd-af6c958446d6', N'Mumford & Sons', N'4062d608-ea35-4f0d-b406-d5e280d1342e')
GO
INSERT [dbo].[Country] ([CountryId], [Name], [Code]) VALUES (N'7a8f669e-20e3-4404-94ea-82117c39a7bb', N'United States', N'US')
GO
INSERT [dbo].[Country] ([CountryId], [Name], [Code]) VALUES (N'4062d608-ea35-4f0d-b406-d5e280d1342e', N'Great Britain', N'GB')
GO
ALTER TABLE [dbo].[Alias]  WITH CHECK ADD  CONSTRAINT [FK_Alias_Artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])
GO
ALTER TABLE [dbo].[Alias] CHECK CONSTRAINT [FK_Alias_Artist]
GO
ALTER TABLE [dbo].[Artist]  WITH CHECK ADD  CONSTRAINT [FK_Artist_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Artist] CHECK CONSTRAINT [FK_Artist_Country]
GO
USE [master]
GO
ALTER DATABASE [MusicArtist] SET  READ_WRITE 
GO
