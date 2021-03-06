USE [master]
GO
/****** Object:  Database [AddressBook]    Script Date: 14.9.2013 г. 19:04:59 ******/
CREATE DATABASE [AddressBook]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AddressBook', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AddressBook.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AddressBook_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\AddressBook_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AddressBook] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AddressBook].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AddressBook] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AddressBook] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AddressBook] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AddressBook] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AddressBook] SET ARITHABORT OFF 
GO
ALTER DATABASE [AddressBook] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AddressBook] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [AddressBook] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AddressBook] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AddressBook] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AddressBook] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AddressBook] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AddressBook] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AddressBook] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AddressBook] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AddressBook] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AddressBook] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AddressBook] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AddressBook] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AddressBook] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AddressBook] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AddressBook] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AddressBook] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AddressBook] SET RECOVERY FULL 
GO
ALTER DATABASE [AddressBook] SET  MULTI_USER 
GO
ALTER DATABASE [AddressBook] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AddressBook] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AddressBook] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AddressBook] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AddressBook', N'ON'
GO
USE [AddressBook]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 14.9.2013 г. 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [ntext] NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 14.9.2013 г. 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 14.9.2013 г. 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NULL,
	[Language] [nvarchar](50) NULL,
	[Population] [int] NULL,
	[Flag] [image] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 14.9.2013 г. 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 14.9.2013 г. 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Population] [int] NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (1, N'Mofo lane 1', 7)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (2, N'Al.Malinov 21', 2)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (3, N'Cammel Lover boullevard 45', 9)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (2, N'North America')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (3, N'Africa')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (6, N'Asia')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (7, N'South Americas')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (1, N'Bulgaria', 1, N'Bulgarian', 7300000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (3, N'France', 1, N'French', 42000000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (4, N'Poland', 1, N'Polish', 18000000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (5, N'USA', 2, N'English', 230000000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (6, N'Egypt', 3, N'Egyptian', 45000000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (7, N'Canada', 2, N'English', 320000000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (8, N'Nigeria', 3, N'Nigerian', 76000000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (9, N'Greece', 1, N'Greek', 10010000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (10, N'Mexico', 2, N'Spanish', 135000000, NULL)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId], [Language], [Population], [Flag]) VALUES (11, N'Togo', 3, N'Hundi', 139199, NULL)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (1, N'Bai', N'Ivan', 2)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (2, N'Mehmed', N'Zahman', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (3, N'John', N'McClane', 2)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (1, N'Burgas', 1, 200000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (2, N'Sofia', 1, 1200000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (5, N'Paris', 3, 8000000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (6, N'Niece', 3, 1400000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (7, N'San Francisco', 5, 2000000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (8, N'Vancouver', 7, 3000000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (9, N'Cairo', 6, 8000000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (10, N'Abuja', 8, 270000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (11, N'Tsessaloniki', 9, 340000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (12, N'Washington DC', 5, 2600000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (15, N'Athens', 9, 1300000)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (17, N'<em>BafA</em>', 1, 5)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId], [Population]) VALUES (18, N'<strong>Haga</strong>', 1, 31414)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [AddressBook] SET  READ_WRITE 
GO
