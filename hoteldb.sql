USE [master]
GO
/****** Object:  Database [hoteldb]    Script Date: 01.07.2022 03:22:58 ******/
CREATE DATABASE [hoteldb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hoteldb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\hoteldb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hoteldb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\hoteldb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [hoteldb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hoteldb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hoteldb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hoteldb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hoteldb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hoteldb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hoteldb] SET ARITHABORT OFF 
GO
ALTER DATABASE [hoteldb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hoteldb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hoteldb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hoteldb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hoteldb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hoteldb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hoteldb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hoteldb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hoteldb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hoteldb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hoteldb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hoteldb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hoteldb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hoteldb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hoteldb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hoteldb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hoteldb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hoteldb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [hoteldb] SET  MULTI_USER 
GO
ALTER DATABASE [hoteldb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hoteldb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hoteldb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hoteldb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hoteldb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hoteldb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [hoteldb] SET QUERY_STORE = OFF
GO
USE [hoteldb]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 01.07.2022 03:22:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[DocumentID] [varchar](50) NOT NULL,
	[Telephone] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 01.07.2022 03:22:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[FVID] [int] NOT NULL,
	[Cost] [int] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[FVID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 01.07.2022 03:22:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [smallint] NOT NULL,
	[ClientID] [int] NOT NULL,
	[ReservationStatus] [char](50) NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 01.07.2022 03:22:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [smallint] NOT NULL,
	[Standard] [varchar](50) NOT NULL,
	[MinPerson] [tinyint] NOT NULL,
	[MaxPerson] [tinyint] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ID], [Name], [LastName], [DocumentID], [Telephone], [Email]) VALUES (1, N'Anastazja', N'Horeszko', N'ABG103012', N'123456789', N'test@gmail.com')
INSERT [dbo].[Clients] ([ID], [Name], [LastName], [DocumentID], [Telephone], [Email]) VALUES (2, N'Andrzej', N'Sawicki', N'ABG44423', N'3652325652', N'a.Sawicki@gmail.com')
INSERT [dbo].[Clients] ([ID], [Name], [LastName], [DocumentID], [Telephone], [Email]) VALUES (3, N'Filip', N'Fortecki', N'BGC21370', N'555222333', N'')
INSERT [dbo].[Clients] ([ID], [Name], [LastName], [DocumentID], [Telephone], [Email]) VALUES (4, N'Paulina', N'Mazak', N'KRE545142', N'666333222', N'')
INSERT [dbo].[Clients] ([ID], [Name], [LastName], [DocumentID], [Telephone], [Email]) VALUES (5, N'Wiktoria', N'Piątek', N'LUU5156', N'', N'WPiatek@piatek.pl')
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (1, 101, 1, N'Paid                                              ', CAST(N'2022-07-01' AS Date), CAST(N'2022-07-19' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (2, 404, 1, N'Paid                                              ', CAST(N'2022-06-21' AS Date), CAST(N'2022-06-28' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (3, 401, 2, N'Paid                                              ', CAST(N'2022-07-03' AS Date), CAST(N'2022-07-10' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (4, 301, 1, N'Paid                                              ', CAST(N'2022-07-03' AS Date), CAST(N'2022-07-10' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (5, 108, 4, N'Confirmed                                         ', CAST(N'2022-07-03' AS Date), CAST(N'2022-07-10' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (6, 201, 5, N'Confirmed                                         ', CAST(N'2022-07-03' AS Date), CAST(N'2022-07-10' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (7, 102, 2, N'Canceled                                          ', CAST(N'2022-07-03' AS Date), CAST(N'2022-07-10' AS Date))
INSERT [dbo].[Reservations] ([ReservationID], [RoomID], [ClientID], [ReservationStatus], [DateFrom], [DateTo]) VALUES (8, 103, 1, N'Paid                                              ', CAST(N'2022-07-03' AS Date), CAST(N'2022-07-10' AS Date))
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (101, N'Economy', 1, 2)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (102, N'Economy', 1, 2)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (103, N'Economy', 1, 3)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (104, N'Economy', 1, 3)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (105, N'Comfort', 2, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (106, N'Comfort', 2, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (107, N'Comfort', 2, 5)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (108, N'Premium', 3, 6)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (109, N'Premium', 3, 6)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (110, N'Deluxe', 6, 10)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (201, N'Economy', 1, 2)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (202, N'Economy', 1, 2)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (203, N'Economy', 1, 3)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (204, N'Economy', 1, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (205, N'Comfort', 2, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (206, N'Comfort', 2, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (207, N'Comfort', 2, 5)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (208, N'Premium', 3, 6)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (209, N'Premium', 3, 6)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (210, N'Deluxe', 6, 10)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (301, N'Economy', 1, 2)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (302, N'Economy', 1, 3)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (303, N'Economy', 1, 3)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (304, N'Comfort', 1, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (305, N'Comfort', 1, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (306, N'Comfort', 1, 4)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (307, N'Comfort', 1, 5)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (308, N'Premium', 3, 6)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (309, N'Premium', 3, 6)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (310, N'Premium', 3, 6)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (401, N'Deluxe', 4, 10)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (402, N'Deluxe', 4, 10)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (403, N'Deluxe', 6, 12)
INSERT [dbo].[Rooms] ([RoomID], [Standard], [MinPerson], [MaxPerson]) VALUES (404, N'Deluxe', 6, 12)
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Clients]
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Rooms] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Rooms] ([RoomID])
GO
ALTER TABLE [dbo].[Reservations] CHECK CONSTRAINT [FK_Reservations_Rooms]
GO
USE [master]
GO
ALTER DATABASE [hoteldb] SET  READ_WRITE 
GO
