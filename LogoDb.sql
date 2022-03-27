USE [LogoDB]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 27.03.2022 13:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Region] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Website] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 27.03.2022 13:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Profession] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [Company_Name], [City], [Region], [Country], [Website]) VALUES (1, N'Aselsan', N'Ankara', N'Macunköy', N'Ankara', N'https://www.aselsan.com.tr')
INSERT [dbo].[Company] ([Id], [Company_Name], [City], [Region], [Country], [Website]) VALUES (3, N'Havelsan', N'Ankara', N'Çankaya', N'Ankara', N'https://www.havelsan.com.tr/')
INSERT [dbo].[Company] ([Id], [Company_Name], [City], [Region], [Country], [Website]) VALUES (4, N'Baykar', N'İstanbul', N'Esenyurt', N'İstanbul', N'https://baykartech.com/tr')
INSERT [dbo].[Company] ([Id], [Company_Name], [City], [Region], [Country], [Website]) VALUES (8, N'Logo Yazılım', N'Ankara', N'Macunköy', N'Ankara', N'https://www.logo.com.tr/')
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [Profession], [City], [Age]) VALUES (1, N'Hira', N'Balcı', N'Electric and Electronic Engineer', N'Ankara', 26)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Profession], [City], [Age]) VALUES (3, N'Serdar', N'Balcı', N'Product', N'Ankara', 29)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Profession], [City], [Age]) VALUES (4, N'Elif', N'Kalkan', N'Computer Engineer', N'İstanbul', 28)
INSERT [dbo].[User] ([Id], [Name], [Surname], [Profession], [City], [Age]) VALUES (8, N'Seda', N'Yılmaz', N'Civil Engineer', N'Ankara', 29)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Company] FOREIGN KEY([Id])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Company]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCompany]    Script Date: 27.03.2022 13:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sp_UpdateCompany]
(
  @Id int,
  @Company_Name nvarchar(50),
  @City nvarchar(50),
  @Region nvarchar(50),
  @Country nvarchar(50),
  @Website nvarchar(50)
)
As 
Begin
Update Company
Set Company_Name=@Company_Name,City=@City,Region=@Region,Country=@Country,Website=@Website
Where Id=@Id
End
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 27.03.2022 13:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sp_UpdateUser]
(
  @Id int,
  @Name nvarchar(50),
  @Surname nvarchar(50),
  @Profession nvarchar(50),
  @City nvarchar(50),
  @Age int
)
As 
Begin
Update [User]
Set Name=@Name,Surname=@Surname,Profession=@Profession,City=@City,Age=@Age
Where Id=@Id
End
GO
