USE [master]
GO
/****** Object:  Database [LogoDb]    Script Date: 26.03.2022 02:32:59 ******/
CREATE DATABASE [LogoDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LogoDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LogoDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LogoDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\LogoDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LogoDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LogoDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LogoDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LogoDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LogoDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LogoDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LogoDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LogoDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LogoDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LogoDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LogoDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LogoDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LogoDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LogoDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LogoDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LogoDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LogoDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LogoDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LogoDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LogoDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LogoDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LogoDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LogoDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LogoDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LogoDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LogoDb] SET  MULTI_USER 
GO
ALTER DATABASE [LogoDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LogoDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LogoDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LogoDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LogoDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LogoDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LogoDb] SET QUERY_STORE = OFF
GO
USE [LogoDb]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 26.03.2022 02:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [nvarchar](45) NOT NULL,
	[Region] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Website] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 26.03.2022 02:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Profession] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [Company_Name], [Region], [City], [Country], [Website]) VALUES (1, N'Aselsan', N'Macunköy', N'Ankara', N'Türkiye', N'https://www.aselsan.com.tr')
INSERT [dbo].[Company] ([Id], [Company_Name], [Region], [City], [Country], [Website]) VALUES (2, N'Logo Yazılım', N'Çankaya', N'Ankara', N'Türkiye', N'https://www.logo.com.tr/?campaignid=316932062&adgroupid=104691152557&keyword=logo%20yaz%C4%B1l%C4%B1m&device=c&gclid=Cj0KCQjw0PWRBhDKARIsAPKHFGh0VP9mVL2W-2Dexh3Exwq9lT-noi5tpVfFLs3jv_pe2Bo1UYQUe5EaAoJbEALw_wcB')
INSERT [dbo].[Company] ([Id], [Company_Name], [Region], [City], [Country], [Website]) VALUES (3, N'Havelsan', N'Çankaya', N'Ankara', N'Türkiye', N'https://www.havelsan.com.tr/')
INSERT [dbo].[Company] ([Id], [Company_Name], [Region], [City], [Country], [Website]) VALUES (4, N'Baykar', N'Esenyurt', N'İstanbul', N'Türkiye', N'https://baykartech.com/tr/')
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [Age], [Profession], [CompanyId]) VALUES (10, N'Hira', N'Balcı', 25, N'Electric Electronic Engineer', 1)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Age], [Profession], [CompanyId]) VALUES (14, N'Ayşe', N'Kalkan', 28, N'Test Engineer', 3)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Age], [Profession], [CompanyId]) VALUES (15, N'Nurgül', N'Ay', 32, N'Product Manager', 2)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Age], [Profession], [CompanyId]) VALUES (19, N'Ali', N'Yılmaz', 33, N'Computer Engineer', 4)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Company1] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Company1]
GO
/****** Object:  StoredProcedure [dbo].[sp_Company]    Script Date: 26.03.2022 02:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sp_Company]
(
  @Company_Name nvarchar(45),
  @Region nvarchar(50),
  @City nvarchar(50),
  @Country nvarchar(15),
  @Website nvarchar(max)
)
As 
Begin
Insert Into Company (Company_Name,Region,City,Country,Website)
Values(@Company_Name,@Region,@City,@Country,@Website)
End
GO
/****** Object:  StoredProcedure [dbo].[sp_User]    Script Date: 26.03.2022 02:33:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sp_User]
(
  @Name nvarchar(50),
  @Surname nvarchar(50),
  @Age int,
  @Profession nvarchar(50)
)
As 
Begin
Insert Into [User] (Name,Surname,Age,Profession)
Values(@Name,@Surname,@Age,@Profession)
End
GO
USE [master]
GO
ALTER DATABASE [LogoDb] SET  READ_WRITE 
GO
