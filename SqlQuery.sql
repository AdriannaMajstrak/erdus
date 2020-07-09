USE [erdus]
GO
/****** Object:  User [erdus]    Script Date: 15.03.2020 10:04:46 ******/
CREATE USER [erdus] FOR LOGIN [erdus] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [erdususer]    Script Date: 15.03.2020 10:04:46 ******/
CREATE USER [erdususer] FOR LOGIN [erdususer] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [erdus]
GO
ALTER ROLE [db_datareader] ADD MEMBER [erdus]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [erdus]
GO
ALTER ROLE [db_owner] ADD MEMBER [erdususer]
GO
ALTER ROLE [db_datareader] ADD MEMBER [erdususer]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [erdususer]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RequesterId] [nvarchar](450) NOT NULL,
	[ResponsiblePersonId] [nvarchar](450) NULL,
	[Topic] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Photo] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[RequestStatusId] [int] NOT NULL,
	[RequestCategoryId] [int] NOT NULL,
	[Answer] [nvarchar](max) NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestsDeleted]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestsDeleted](
	[Id] [int] NOT NULL,
	[RequesterId] [nvarchar](450) NOT NULL,
	[ResponsiblePersonId] [nvarchar](450) NULL,
	[Topic] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Photo] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[RequestStatusId] [int] NOT NULL,
	[RequestCategoryId] [int] NOT NULL,
	[Answer] [nvarchar](max) NULL,
 CONSTRAINT [PK_RequestsDeleted] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 15.03.2020 10:04:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190501141257_Init', N'2.2.4-servicing-10062')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190501141347_AddRequestTable', N'2.2.4-servicing-10062')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190504122907_addCreationDate', N'2.2.4-servicing-10062')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190504130100_addCreationDateDefault', N'2.2.4-servicing-10062')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190506180015_AddTableStatus', N'2.2.4-servicing-10062')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190506190147_AddTableStatus_2', N'2.2.4-servicing-10062')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20191229130818_AddTableRequestDeleted', N'3.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200103153840_AddCategores', N'3.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200103160403_AddCategoresRequired', N'3.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200126094829_AddAnswerColumn', N'3.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200126121416_AddAnswerColumnRequestDeleted', N'3.0.0')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c', N'User', N'USER', N'7667da24-8d6b-4eab-b17d-0f8bbcba628f')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9276e62a-3981-4980-a157-bcea524e91a2', N'Moderator', N'MODERATOR', N'1f71e8a5-f699-4227-a322-0c95a891fd71')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9692c4a0-2597-413e-be98-638c7ad2f9a6', N'Admin', N'ADMIN', N'a16ae064-8baf-4fbc-8f71-37e3bd3465dd')
GO
INSERT [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [ProviderDisplayName], [UserId]) VALUES (N'', N'', N'a.m@gmail.com', N'dba66bf8-6766-4caf-9282-ddeee751869a')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0261f65e-0516-435c-a18e-7b9f06f3671e', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02b9ea27-7841-4d56-a0e6-465ab008b616', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10a73ae0-8a71-4ae6-a6ae-67aba7cad9a8', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'53efeb76-ec5b-4c2a-92b8-23374e49fc6e', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d87bf43-611b-4166-89e5-45b63de38122', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b272cf89-b70d-4f1c-bd00-88ba49f99b09', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7dd030f-e14b-4ca9-a1b1-1a842b38af06', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bb96be88-be81-4232-adca-fb85e942361f', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd678e0e1-9d0e-4e3e-9ef2-13d7dbeedd50', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dda9e4f1-3e2b-4935-816e-49251903d101', N'3aebc879-a614-40ab-b1ea-4c43e9e9ea2c')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0261f65e-0516-435c-a18e-7b9f06f3671e', N'9276e62a-3981-4980-a157-bcea524e91a2')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02e43851-35c5-4570-a8d4-4ddbf6bb6a7d', N'9276e62a-3981-4980-a157-bcea524e91a2')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d87bf43-611b-4166-89e5-45b63de38122', N'9276e62a-3981-4980-a157-bcea524e91a2')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dba66bf8-6766-4caf-9282-ddeee751869a', N'9276e62a-3981-4980-a157-bcea524e91a2')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd70d11a1-cc2d-46f0-aa58-9fbcef57f960', N'9692c4a0-2597-413e-be98-638c7ad2f9a6')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dba66bf8-6766-4caf-9282-ddeee751869a', N'9692c4a0-2597-413e-be98-638c7ad2f9a6')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'01f33ea1-ad78-4f60-8ac1-37b16c4b01fc', N'e@op.pl', N'E@OP.PL', N'e@op.pl', N'E@OP.PL', 0, N'AQAAAAEAACcQAAAAEDZmm4Mpw3WvptF5UR1aopEE8dYTCJJbDMn+IHUxJxaM+8W0y3NZVnaly296tNHCDQ==', N'BZHK5OBQLQ4SX7BTS3HKABIMSDNBGGGO', N'bbfc9420-18e9-49dd-bc86-65b0875fc04d', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (0, N'Inne')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Drogi i chodniki')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Oświetlenie')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Parki')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Śmietniki i odpady')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Kanalizacja')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Infrastruktura teletechniczna')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Infrastruktura komunikacji miejskiej')
GO
SET IDENTITY_INSERT [dbo].[Requests] ON 
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (63, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Zniszczony przystanek', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', N'18.999652862548828,50.11573500084128', N'ul. Wolnosci', CAST(N'2019-06-08T14:32:54.6466667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (64, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Dziura', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', N'18.99484634399414,50.14104577762248', N'ul. Polska', CAST(N'2019-06-08T14:38:47.0633333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (65, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Usterla', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', N'18.978023529052734,50.12079822709748', N'Adrs 76', CAST(N'2019-06-08T14:39:14.9700000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (66, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Nowe zgłoszenie', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', NULL, N'Zerberka', CAST(N'2019-06-08T14:39:43.3500000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (67, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Temty', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', NULL, N'Glogera', CAST(N'2019-06-08T14:40:11.3600000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (68, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'KOlejne', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', NULL, N'ul. Parkingowa', CAST(N'2019-06-08T14:40:36.1233333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (69, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Przystanek', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', NULL, N'adres 98', CAST(N'2019-06-08T14:40:57.3866667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (70, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Temat rur', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', N'19.00754928588867,50.1368649201994', N'Zwiezyniec', CAST(N'2019-06-08T14:41:23.0833333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (71, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Temat 9', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', N'19.014759063720703,50.118156610641336', N'ilena', CAST(N'2019-06-08T14:41:55.0566667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (72, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Temat 10', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer at tellus dictum justo finibus euismod non quis mauris. In at ipsum et mi mattis tempus. Duis massa nisl, rutrum sit amet nibh id, faucibus viverra velit. Maecenas tincidunt mauris vel odio pretium cursus. Morbi vitae leo tortor. Sed scelerisque congue tincidunt. Sed aliquam, libero imperdiet varius sodales, tellus neque placerat turpis, et iaculis nisi turpis nec nisi. Nam quis viverra felis. Cras egestas mi a efficitur pulvinar. ', N'http://erdusserver.westeurope.cloudapp.azure.com/gl161202mk_009.1200.jpg', N'19.047374725341797,50.11551484842229', N'Dziurawa', CAST(N'2019-06-08T14:42:17.5200000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (73, N'99e26b00-9818-42e9-900d-92fd16684aae', NULL, N'test lipiec', N'weftearg', N'http://localhost/036ab4cc-1f98-4e33-b815-7f1f269df84e.bmp', N'19.01900051627308,50.12233909823874', N'ul. Ogólna', CAST(N'2019-07-22T20:23:56.3933333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (74, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'sdf', N'sdf', N'http://localhost/48973c99-c9c7-4104-881a-adfc36121eda.bmp', N'18.973045, 50.115185', N'sdf', CAST(N'2019-12-02T21:44:35.5266667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (75, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'sdf', N'sdf', N'http://localhost/8fc851be-f86c-4f91-b76a-fa95d94e9a3a.bmp', N'18.946438, 50.135655', N'sdf', CAST(N'2019-12-02T21:47:01.6966667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (76, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/45636d34-5a98-4082-9c0e-3bb5e9c85101.bmp', N'18.973045, 50.109901', N's', CAST(N'2019-12-02T21:55:17.8900000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (77, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'g', N'g', N'http://localhost/ecdb5d4e-600e-48b6-a135-ffef0612afc7.bmp', N'19.007721, 50.108800', N'g', CAST(N'2019-12-02T21:56:35.7000000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (78, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'bgd', N'gr', N'http://localhost/7cdf32be-766e-415c-90ad-1449dcc4dcb5.bmp', N'18.931160, 50.099771', N'vds', CAST(N'2019-12-02T22:01:14.4633333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (79, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'hj', N'ty', N'http://localhost/2bd11970-8471-4111-b40b-57309dad1fc1.bmp', N'18.963745, 50.111335', N'ty', CAST(N'2019-12-02T22:02:44.4900000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (80, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'hfg', N'fg', N'http://localhost/647fed65-b931-447c-957d-255e05831723.bmp', N'19.016476, 50.124650', N'fgh', CAST(N'2019-12-02T22:05:29.1566667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (81, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'f', N'f', N'http://localhost/d52eb2d9-75ef-410e-8fb5-0d34bc546e30.bmp', N'19.014072, 50.120028', N'f', CAST(N'2019-12-02T22:09:07.2033333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (82, N'dba66bf8-6766-4caf-9282-ddeee751869a', N'9d87bf43-611b-4166-89e5-45b63de38122', N'e', N'e', N'http://localhost/dbcbd27c-5a48-4ff2-b5d9-c3cbd98bfcb8.bmp', N'18.943863, 50.124430', N'e', CAST(N'2019-12-02T22:19:55.2400000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (83, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'8', N'8', N'http://localhost/bad0bfed-20e3-4481-8014-38ff8514e316.bmp', N'18.924809, 50.137635', N'8', CAST(N'2019-12-03T20:32:04.4000000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (84, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'h', N'h', N'http://localhost/587c3d03-cb22-47cb-b647-e50e5022f7aa.bmp', N'18.936653, 50.134334', N'h', CAST(N'2019-12-03T20:47:39.7000000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (85, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'd', N'd', N'http://localhost/2ad69693-4948-4eeb-a400-1621e9fa96ae.bmp', N'18.987465, 50.114084', N'd', CAST(N'2019-12-03T20:57:29.1633333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (86, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/ae8508b5-4fea-450e-9d9b-748daff3ee15.bmp', N'18.953819, 50.104176', N's', CAST(N'2019-12-03T20:57:49.3833333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (87, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/dd3cb207-eea8-4630-94c7-96403b0df542.bmp', N'19.039307, 50.117606', N's', CAST(N'2019-12-03T21:00:07.3100000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (88, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/2bb3a159-8af4-452c-aa41-5bc2e6e215ba.bmp', N'19.039307, 50.117606', N's', CAST(N'2019-12-03T21:00:46.8600000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (89, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/c4943735-7e47-4bf8-8d60-1f2cc77f112b.bmp', N'19.087372, 50.128392', N's', CAST(N'2019-12-03T21:01:00.5366667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (90, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/5c952f51-0e95-46d5-a12d-10eff89a4948.bmp', N'19.087372, 50.128392', N's', CAST(N'2019-12-03T21:08:35.5100000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (91, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'a', N'a', N'http://localhost/2f2b492f-9057-4ea2-bd9c-342bb66e3f32.bmp', N'19.030037, 50.114524', N'a', CAST(N'2019-12-03T21:09:06.8566667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (92, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/2a95b62e-d924-442b-9ccb-23c5fb414f84.bmp', N'19.022484, 50.120248', N's', CAST(N'2019-12-03T21:14:38.1000000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (93, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'd', N'd', N'http://localhost/a974894a-9c59-4b33-a18c-9db4e4f43e9d.bmp', N'19.027290, 50.109240', N'd', CAST(N'2019-12-03T21:16:43.8033333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (94, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/69164554-f3ea-40d1-8576-939a6128abc1.bmp', N'18.960342, 50.112323', N's', CAST(N'2019-12-03T21:18:06.7300000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (95, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/09a3d164-05dc-4ab8-8ef4-4f6d589bcaf5.bmp', N'18.953476, 50.112763', N's', CAST(N'2019-12-03T21:20:02.3233333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (96, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/d67c3863-247d-464e-8744-ac4bbdca5589.bmp', N'18.934250, 50.109020', N's', CAST(N'2019-12-03T21:27:57.3833333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (97, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'df', N'd', N'http://localhost/997e28fb-c9b3-4d9e-ba4e-9f128e901076.bmp', N'19.026260, 50.127512', N'df', CAST(N'2019-12-03T21:31:24.4933333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (98, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'dfg', N'dsf', N'http://localhost/4bd04341-9edc-47e2-9aa1-b5ebe259892b.bmp', N'19.048748, 50.132134', N'sdf', CAST(N'2019-12-03T21:31:57.9900000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (99, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/3628eacf-f5b1-46ee-a6e4-4a46db116ea2.bmp', N'18.902493, 50.118487', N's', CAST(N'2019-12-03T21:50:02.4166667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (100, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/8c459a89-dd30-4977-a791-23725dc2acc5.bmp', N'18.968239, 50.116946', N's', CAST(N'2019-12-03T22:15:59.8366667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (101, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/4d98d82a-45b2-40dd-8082-5b8479e5c1c3.bmp', N'18.902493, 50.100212', N's', CAST(N'2019-12-03T22:18:44.1100000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (121, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'tesrt', N'gsrt', N'http://localhost/f4549a84-80db-41b9-99a9-72d9a4619949.bmp', N'18.991070, 50.113644', N'gstg', CAST(N'2020-01-03T19:26:08.4400000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (122, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'2', N'ww', N'http://localhost/145a614f-487a-4f9a-9830-fde75bb42501.bmp', N'18.925838, 50.112763', N'ww', CAST(N'2020-01-03T19:27:56.2466667' AS DateTime2), 1, 5, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (123, N'0261f65e-0516-435c-a18e-7b9f06f3671e', NULL, N'tr', N'gg', N'http://localhost/13a595f4-3156-455b-8880-1f9a98749888.bmp', N'19.007721, 50.117166', N'gg', CAST(N'2020-01-09T23:25:50.0600000' AS DateTime2), 2, 1, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (124, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'Zepsuta lampa', N'przepalona żarówka', N'http://localhost/249dfc31-bc65-421c-8233-c45c25773d30.bmp', N'18.995705, 50.112102', N'ul.Bałtycka', CAST(N'2020-01-25T16:24:24.0966667' AS DateTime2), 2, 2, N'wymieniono zarowke')
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (125, N'b7dd030f-e14b-4ca9-a1b1-1a842b38af06', NULL, N'Test', N'Test test', N'http://localhost/9f3dbe18-d59f-4917-b4cb-f6ddb9247c1b.bmp', N'19.000683, 50.114304', N'ul.Test', CAST(N'2020-02-03T20:32:52.5033333' AS DateTime2), 1, 2, NULL)
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (127, N'dba66bf8-6766-4caf-9282-ddeee751869a', N'02e43851-35c5-4570-a8d4-4ddbf6bb6a7d', N'111', N'111', N'http://localhost/064e4f3d-9d92-4900-8b3d-da4d7c4078ed.bmp', N'18.958626, 50.098230', N'111', CAST(N'2020-02-23T16:02:07.2700000' AS DateTime2), 2, 1, N'spadaj')
GO
INSERT [dbo].[Requests] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (131, N'02b9ea27-7841-4d56-a0e6-465ab008b616', NULL, N'df', N'sdf', N'http://localhost/cfd42e96-a2e8-4296-ad36-527d365a158c.bmp', N'19.024544, 50.106818', N'sdf', CAST(N'2020-03-13T23:17:01.3233333' AS DateTime2), 1, 2, N'k')
GO
SET IDENTITY_INSERT [dbo].[Requests] OFF
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (102, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'k', N'k', N'http://localhost/c8a8043a-aed9-45b4-9915-93188b6e1cf9.bmp', N'18.946266, 50.120028', N'k', CAST(N'2019-12-04T18:31:12.8933333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (103, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/db40482a-54c5-4aaf-9e3a-629b89a75b93.bmp', N'18.919144, 50.118267', N's', CAST(N'2019-12-04T18:41:45.9466667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (104, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'f', N'f', N'http://localhost/2af48d6e-71bd-4a7e-8629-a11fd1816071.bmp', N'18.958282, 50.116065', N'f', CAST(N'2019-12-04T18:47:40.5333333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (105, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/327c9005-fbf6-438c-96a7-8ae86c010525.bmp', N'18.946609, 50.118707', N's', CAST(N'2019-12-04T19:21:02.1866667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (106, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'd', N'd', N'http://localhost/0a63aa4a-8caf-4971-b861-b8d6135f0638.bmp', N'19.025574, 50.113423', N'd', CAST(N'2019-12-04T19:23:24.1066667' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (107, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/e4e0f77f-9365-4963-ae6b-e6b7cb73793c.bmp', N'18.972359, 50.122009', N's', CAST(N'2019-12-04T19:24:28.3100000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (108, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'sdf', N'sdf', N'http://localhost/0f072de4-04c3-47a8-953f-3d31cb7942a1.bmp', N'19.045143, 50.116726', N'sdf', CAST(N'2019-12-04T21:36:19.0200000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (109, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N's', N's', N'http://localhost/c3c0234c-1fcf-446f-b099-9616c9902b5a.bmp', N'19.047890, 50.109680', N's', CAST(N'2019-12-04T21:41:12.3033333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (110, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'dsf', N'sdf', N'http://localhost/802ef0a9-c377-4a42-a4cc-cd64323a284c.bmp', N'19.011326, 50.137195', N'sdf', CAST(N'2019-12-04T21:42:06.2133333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (111, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'sdf', N'sdf', N'http://localhost/02293e80-895b-4c41-bfb2-4252f3581dc9.bmp', N'19.064198, 50.126631', N'sdf', CAST(N'2019-12-04T21:43:28.6533333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (112, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'sdf', N'sdfsd', N'http://localhost/ead0b56e-1a75-4352-9d44-8a7395fd0e44.bmp', N'18.967724, 50.140056', N'sdf', CAST(N'2019-12-04T21:45:10.1800000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (113, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'sdf', N'sdf', N'http://localhost/b3c118f7-33fa-4f1f-baf0-9bd5b61911af.bmp', N'19.035015, 50.135435', N'sdf', CAST(N'2019-12-04T21:45:31.3000000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (114, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'nie ydt', N'edytowane', N'http://localhost/e4022b38-b11a-4ae1-87d5-093e50a7fb8c.bmp', N'19.088058, 50.103955', N'edytowane', CAST(N'2019-12-19T18:05:15.3533333' AS DateTime2), 4, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (115, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'ewrt', N'dsf', N'http://localhost/8882cd2f-f631-4f34-9ab1-2c1ce6b016f6.bmp', N'18.968925, 50.127512', N'sdf', CAST(N'2019-12-27T21:09:02.4800000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (116, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'www', N'jjj', N'http://localhost/7b74ed3e-668c-47ba-bd92-74c3cae8b9f0.bmp', N'18.984890, 50.130593', N'jjj', CAST(N'2019-12-27T21:09:49.7266667' AS DateTime2), 4, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (117, N'dba66bf8-6766-4caf-9282-ddeee751869a', N'02e43851-35c5-4570-a8d4-4ddbf6bb6a7d', N'ty', N'yt', N'http://localhost/baa2339e-8349-456f-ba60-9de582cbf8f7.bmp', N'18.973732, 50.121349', N'yt', CAST(N'2019-12-27T22:03:44.9000000' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (118, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'efr', N'dsf', N'http://localhost/8f2bc1f3-b391-4978-bdbb-bc6c5f82f95e.bmp', N'18.998223, 50.122618', N'sdf', CAST(N'2019-12-29T17:07:35.4433333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (119, N'0261f65e-0516-435c-a18e-7b9f06f3671e', NULL, N'test abcd', N'afcE', N'http://localhost/d965ad50-78fa-44c3-b55c-44cc4895d310.bmp', N'18.981972, 50.114524', N'frfrf', CAST(N'2019-12-29T17:30:04.2733333' AS DateTime2), 1, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (120, N'dba66bf8-6766-4caf-9282-ddeee751869a', N'9d87bf43-611b-4166-89e5-45b63de38122', N'k', N'k', N'http://localhost/6502414f-15c9-4bbb-8536-b34d99be6b12.bmp', N'18.990555, 50.120468', N'kk', CAST(N'2020-01-02T15:06:41.5400000' AS DateTime2), 2, 0, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (126, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'hh', N'h', N'http://localhost/a883672d-3589-41c0-9b69-5a0a239017c1.bmp', N'19.030724, 50.104396', N'h', CAST(N'2020-02-10T18:43:35.9133333' AS DateTime2), 1, 3, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (128, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'4r', N'<script>window.alert('''')</script>', N'http://localhost/c2f5b3ae-e208-4e87-a1da-4e862ffb3ef6.bmp', N'18.977852, 50.117881', N'r3', CAST(N'2020-03-02T21:15:48.9833333' AS DateTime2), 1, 3, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (129, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'3', N'<script>window.alert('''')</script>', N'http://localhost/af840090-46a8-44cb-87fa-cf0cbd6aef96.bmp', N'18.941975, 50.094486', N'e', CAST(N'2020-03-02T21:26:25.3733333' AS DateTime2), 1, 2, NULL)
GO
INSERT [dbo].[RequestsDeleted] ([Id], [RequesterId], [ResponsiblePersonId], [Topic], [Content], [Photo], [Location], [Address], [CreationDate], [RequestStatusId], [RequestCategoryId], [Answer]) VALUES (130, N'dba66bf8-6766-4caf-9282-ddeee751869a', NULL, N'as', N'asd', N'http://localhost/ec4c9833-6324-43b2-bb64-156a916b459e.bmp', N'18.953819, 50.100872', N'asd', CAST(N'2020-03-13T21:39:03.9400000' AS DateTime2), 1, 1, NULL)
GO
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (1, N'zgłoszony')
GO
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (2, N'odrzucony')
GO
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (3, N'przyjęty do realizacji')
GO
INSERT [dbo].[Statuses] ([Id], [Name]) VALUES (4, N'zakończony')
GO
ALTER TABLE [dbo].[Requests] ADD  DEFAULT (getdate()) FOR [CreationDate]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_AspNetUsers_RequesterId] FOREIGN KEY([RequesterId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_AspNetUsers_RequesterId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_AspNetUsers_ResponsiblePersonId] FOREIGN KEY([ResponsiblePersonId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_AspNetUsers_ResponsiblePersonId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Categories_RequestCategoryId] FOREIGN KEY([RequestCategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Categories_RequestCategoryId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Statuses_RequestStatusId] FOREIGN KEY([RequestStatusId])
REFERENCES [dbo].[Statuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Statuses_RequestStatusId]
GO
ALTER TABLE [dbo].[RequestsDeleted]  WITH CHECK ADD  CONSTRAINT [FK_RequestsDeleted_AspNetUsers_RequesterId] FOREIGN KEY([RequesterId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestsDeleted] CHECK CONSTRAINT [FK_RequestsDeleted_AspNetUsers_RequesterId]
GO
ALTER TABLE [dbo].[RequestsDeleted]  WITH CHECK ADD  CONSTRAINT [FK_RequestsDeleted_AspNetUsers_ResponsiblePersonId] FOREIGN KEY([ResponsiblePersonId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[RequestsDeleted] CHECK CONSTRAINT [FK_RequestsDeleted_AspNetUsers_ResponsiblePersonId]
GO
ALTER TABLE [dbo].[RequestsDeleted]  WITH CHECK ADD  CONSTRAINT [FK_RequestsDeleted_Categories_RequestCategoryId] FOREIGN KEY([RequestCategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestsDeleted] CHECK CONSTRAINT [FK_RequestsDeleted_Categories_RequestCategoryId]
GO
ALTER TABLE [dbo].[RequestsDeleted]  WITH CHECK ADD  CONSTRAINT [FK_RequestsDeleted_Statuses_RequestStatusId] FOREIGN KEY([RequestStatusId])
REFERENCES [dbo].[Statuses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestsDeleted] CHECK CONSTRAINT [FK_RequestsDeleted_Statuses_RequestStatusId]
GO
