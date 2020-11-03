USE [master]
GO
/****** Object:  Database [technostar-test-maa]    Script Date: 03.11.2020 7:28:26 ******/
CREATE DATABASE [technostar-test-maa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'technostar-test-maa', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\technostar-test-maa.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'technostar-test-maa_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\technostar-test-maa_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [technostar-test-maa] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [technostar-test-maa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [technostar-test-maa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [technostar-test-maa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [technostar-test-maa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [technostar-test-maa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [technostar-test-maa] SET ARITHABORT OFF 
GO
ALTER DATABASE [technostar-test-maa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [technostar-test-maa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [technostar-test-maa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [technostar-test-maa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [technostar-test-maa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [technostar-test-maa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [technostar-test-maa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [technostar-test-maa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [technostar-test-maa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [technostar-test-maa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [technostar-test-maa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [technostar-test-maa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [technostar-test-maa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [technostar-test-maa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [technostar-test-maa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [technostar-test-maa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [technostar-test-maa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [technostar-test-maa] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [technostar-test-maa] SET  MULTI_USER 
GO
ALTER DATABASE [technostar-test-maa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [technostar-test-maa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [technostar-test-maa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [technostar-test-maa] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [technostar-test-maa] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [technostar-test-maa] SET QUERY_STORE = OFF
GO
USE [technostar-test-maa]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 03.11.2020 7:28:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Birthday] [datetime] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 03.11.2020 7:28:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [int] NOT NULL,
	[Type] [nvarchar](32) NOT NULL,
	[Model] [nvarchar](32) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 03.11.2020 7:28:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BuyerId] [int] NOT NULL,
	[SellerId] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[UsdAmount] [decimal](19, 4) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (1, N'Rebecca', CAST(N'1992-07-07T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (2, N'Alex', CAST(N'2000-11-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (3, N'Seth', CAST(N'2001-02-17T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (4, N'Zoe', CAST(N'2007-11-16T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (5, N'Juan', CAST(N'1975-04-19T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (6, N'Daisy', CAST(N'2015-03-10T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (7, N'Elizabeth', CAST(N'1992-01-11T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Persons] ([Id], [Name], [Birthday]) VALUES (8, N'Peter', CAST(N'1991-12-04T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (1, 12, N'Drawing', NULL)
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (2, 5, N'Flowers', N'White')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (3, 11, N'Stocks', N'Toblerone')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (4, 10, N'Camera', N'Sony SLT-A77')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (5, 9, N'Dog', N'Shiba Inu')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (6, 8, N'Cell phone', N'Samsung S20')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (7, 7, N'Car', N'Ford Mustang')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (8, 6, N'Doing the dishes', NULL)
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (9, 11, N'Factory', N'Toblerone')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (10, 5, N'Chocolate', N'Hershey''s')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (11, 3, N'Cat', N'White')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (12, 2, N'Set of paint brushes', N'Princetone')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (13, 1, N'Flowers', N'Roses')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (14, 1, N'Chocolate', N'Toblerone')
GO
INSERT [dbo].[Products] ([Id], [TransactionId], [Type], [Model]) VALUES (15, 4, N'Cell phone', N'iPhone X')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (1, 5, 3, CAST(N'2015-11-07T08:00:00.000' AS DateTime), CAST(10.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (2, 3, 8, CAST(N'2017-11-06T00:41:34.000' AS DateTime), CAST(100.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (3, 6, 7, CAST(N'2018-10-22T11:49:49.000' AS DateTime), CAST(300.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (4, 4, 3, CAST(N'2019-06-01T18:46:05.000' AS DateTime), CAST(13.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (5, 6, 4, CAST(N'2019-06-26T05:28:15.000' AS DateTime), CAST(1.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (6, 2, 7, CAST(N'2019-12-16T09:12:54.000' AS DateTime), CAST(275.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (7, 1, 2, CAST(N'2020-01-14T01:56:02.000' AS DateTime), CAST(120.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (8, 3, 2, CAST(N'2020-06-22T18:48:00.000' AS DateTime), CAST(50.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (9, 7, 4, CAST(N'2020-08-12T00:29:20.000' AS DateTime), CAST(220000.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (10, 1, 7, CAST(N'2020-10-31T21:24:44.000' AS DateTime), CAST(3.5000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (11, 8, 7, CAST(N'2019-11-04T08:43:27.000' AS DateTime), CAST(1300.0000 AS Decimal(19, 4)))
GO
INSERT [dbo].[Transactions] ([Id], [BuyerId], [SellerId], [DateTime], [UsdAmount]) VALUES (12, 4, 3, CAST(N'2015-02-20T07:10:00.000' AS DateTime), CAST(15.0000 AS Decimal(19, 4)))
GO
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
USE [master]
GO
ALTER DATABASE [technostar-test-maa] SET  READ_WRITE 
GO
