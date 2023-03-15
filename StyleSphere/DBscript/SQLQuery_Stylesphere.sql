USE [master]
GO
/****** Object:  Database [StyleSphereDB]    Script Date: 3/14/2023 11:19:51 PM ******/
CREATE DATABASE [StyleSphereDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StyleSphereDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StyleSphereDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StyleSphereDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\StyleSphereDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StyleSphereDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StyleSphereDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StyleSphereDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StyleSphereDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StyleSphereDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StyleSphereDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StyleSphereDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StyleSphereDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StyleSphereDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StyleSphereDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StyleSphereDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StyleSphereDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StyleSphereDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StyleSphereDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StyleSphereDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StyleSphereDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StyleSphereDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StyleSphereDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StyleSphereDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StyleSphereDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StyleSphereDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StyleSphereDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StyleSphereDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StyleSphereDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StyleSphereDB] SET RECOVERY FULL 
GO
ALTER DATABASE [StyleSphereDB] SET  MULTI_USER 
GO
ALTER DATABASE [StyleSphereDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StyleSphereDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StyleSphereDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StyleSphereDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StyleSphereDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StyleSphereDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StyleSphereDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [StyleSphereDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StyleSphereDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](150) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
	[ShowOnTop] [bit] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColorMaster]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColorMaster](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_ColorMaster] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[ZipCode] [varchar](50) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[FavoritesID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[FavoritesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [nvarchar](50) NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[ProductMappingID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Total] [numeric](10, 2) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdersData]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersData](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ShippingAddress] [varchar](250) NOT NULL,
	[BillingAddress] [varchar](250) NOT NULL,
	[TrackingID] [varchar](50) NOT NULL,
	[NetAmount] [numeric](10, 2) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_OrdersData] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMappings]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMappings](
	[ProductMappingID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[SizeID] [int] NOT NULL,
	[ColorID] [int] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_ProductMappings] PRIMARY KEY CLUSTERED 
(
	[ProductMappingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[ProductName] [varchar](150) NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[MfgDate] [date] NOT NULL,
	[ThumbnailImage] [varchar](max) NOT NULL,
	[Image1] [varchar](max) NOT NULL,
	[Image2] [varchar](max) NULL,
	[Image3] [varchar](max) NULL,
	[Description] [varchar](max) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SizesMaster]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SizesMaster](
	[SizeID] [int] IDENTITY(1,1) NOT NULL,
	[EUSize] [nvarchar](50) NOT NULL,
	[USSize] [nvarchar](50) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_SizesMaster] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sub_Categories]    Script Date: 3/14/2023 11:19:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sub_Categories](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[SubCategoryName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[ActiveStatus] [bit] NOT NULL,
 CONSTRAINT [PK_Sub Categories] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [ActiveStatus], [ShowOnTop]) VALUES (1, N'Men', N'Men''s Section', 1, 1)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [ActiveStatus], [ShowOnTop]) VALUES (2, N'Women', N'Women''s Section', 1, 1)
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [ActiveStatus], [ShowOnTop]) VALUES (3, N'Kids', N'Kids'' Section', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[ColorMaster] ON 
GO
INSERT [dbo].[ColorMaster] ([ColorID], [Color], [ActiveStatus]) VALUES (1, N'Black', 1)
GO
INSERT [dbo].[ColorMaster] ([ColorID], [Color], [ActiveStatus]) VALUES (2, N'Red', 1)
GO
INSERT [dbo].[ColorMaster] ([ColorID], [Color], [ActiveStatus]) VALUES (3, N'White', 1)
GO
SET IDENTITY_INSERT [dbo].[ColorMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [Email], [Password], [ContactNo], [Address], [ZipCode], [ActiveStatus]) VALUES (1, N'Kunj', N'kunj@abc.com', N'kunj123', N'9876543210', N'123 abc def', N'54321', 1)
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [Email], [Password], [ContactNo], [Address], [ZipCode], [ActiveStatus]) VALUES (2, N'Tao', N'tao@abc.com', N'Tao123', N'7418529630', N'234 def abc', N'12354', 1)
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [Email], [Password], [ContactNo], [Address], [ZipCode], [ActiveStatus]) VALUES (3, N'Lorgan', N'lorgan@abc.com', N'lorgan123', N'1234567890', N'741 asd qwe', N'74185', 1)
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [Email], [Password], [ContactNo], [Address], [ZipCode], [ActiveStatus]) VALUES (5, N'Vinuthna', N'vinuthna@abc.com', N'vinuthna123', N'8529637410', N'789 zxc edr', N'45632', 1)
GO
INSERT [dbo].[Customers] ([CustomerID], [CustomerName], [Email], [Password], [ContactNo], [Address], [ZipCode], [ActiveStatus]) VALUES (6, N'Jahnvi', N'jahnvi@abc.com', N'jahnvi123', N'8527419630', N'784 unj jns', N'96387', 1)
GO
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Favorites] ON 
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (3, 1, 2, 1)
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (4, 1, 3, 1)
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (5, 2, 6, 1)
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (6, 2, 4, 1)
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (8, 2, 2, 1)
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (9, 3, 6, 1)
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (10, 3, 7, 1)
GO
INSERT [dbo].[Favorites] ([FavoritesID], [CustomerID], [ProductID], [ActiveStatus]) VALUES (15, 5, 2, 1)
GO
SET IDENTITY_INSERT [dbo].[Favorites] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [Quantity], [Price], [ProductMappingID], [OrderID], [Total], [ActiveStatus]) VALUES (2, N'2', CAST(12.50 AS Numeric(10, 2)), 2, 1, CAST(25.00 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [Quantity], [Price], [ProductMappingID], [OrderID], [Total], [ActiveStatus]) VALUES (3, N'1', CAST(12.50 AS Numeric(10, 2)), 4, 2, CAST(12.50 AS Numeric(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[OrdersData] ON 
GO
INSERT [dbo].[OrdersData] ([OrderID], [CustomerID], [OrderDate], [ShippingAddress], [BillingAddress], [TrackingID], [NetAmount], [ActiveStatus]) VALUES (1, 1, CAST(N'2023-03-09' AS Date), N'123 abc def', N'123 abc def', N'74185', CAST(12.50 AS Numeric(10, 2)), 1)
GO
INSERT [dbo].[OrdersData] ([OrderID], [CustomerID], [OrderDate], [ShippingAddress], [BillingAddress], [TrackingID], [NetAmount], [ActiveStatus]) VALUES (2, 1, CAST(N'2022-01-12' AS Date), N'123 abc def', N'123 abc def', N'85296', CAST(12.50 AS Numeric(10, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[OrdersData] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductMappings] ON 
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (2, 2, 1, 1, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (4, 2, 2, 1, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (5, 2, 3, 1, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (6, 2, 4, 1, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (7, 3, 6, 3, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (8, 3, 7, 3, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (9, 3, 8, 3, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (10, 3, 9, 2, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (11, 2, 1, 2, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (12, 2, 2, 2, 1)
GO
INSERT [dbo].[ProductMappings] ([ProductMappingID], [ProductID], [SizeID], [ColorID], [ActiveStatus]) VALUES (13, 2, 3, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[ProductMappings] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (2, 1, 1, N'Men''s Black Shoes', CAST(12.50 AS Numeric(10, 2)), CAST(N'2002-03-12' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'Black Shoes for a Man', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (3, 2, 2, N'Women''s White Shoes', CAST(8.99 AS Numeric(10, 2)), CAST(N'2020-12-21' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'White shoes for a woman', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (4, 3, 3, N'Kids'' Black Shoes', CAST(6.99 AS Numeric(10, 2)), CAST(N'2020-01-25' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'Black Shoes for a Children', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (5, 2, 2, N'Women''s White Shoes', CAST(8.99 AS Numeric(10, 2)), CAST(N'2020-12-21' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'White shoes for a woman', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (6, 1, 1, N'Men''s Black Shoes', CAST(12.50 AS Numeric(10, 2)), CAST(N'2002-03-12' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'Black Shoes for a Man', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (7, 3, 3, N'Kids'' Red Shoes', CAST(7.99 AS Numeric(10, 2)), CAST(N'2020-12-21' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'Red shoes for kids', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (8, 1, 1, N'Men''s Black Shoes', CAST(8.50 AS Numeric(10, 2)), CAST(N'2002-03-12' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'Black Shoes for a Man', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (9, 2, 2, N'Women''s White Shoes', CAST(8.99 AS Numeric(10, 2)), CAST(N'2020-12-21' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'White shoes for a woman', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (10, 1, 1, N'Men''s Black Shoes', CAST(12.50 AS Numeric(10, 2)), CAST(N'2002-03-12' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'Black Shoes for a Man', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (11, 2, 2, N'Women''s White Shoes', CAST(8.99 AS Numeric(10, 2)), CAST(N'2020-12-21' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'White shoes for a woman', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (12, 1, 1, N'Men''s Black Shoes', CAST(10.00 AS Numeric(10, 2)), CAST(N'2002-03-12' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'Black Shoes for a Man', 1)
GO
INSERT [dbo].[Products] ([ProductID], [CategoryID], [SubCategoryID], [ProductName], [Price], [MfgDate], [ThumbnailImage], [Image1], [Image2], [Image3], [Description], [ActiveStatus]) VALUES (13, 2, 2, N'Women''s White Shoes', CAST(8.99 AS Numeric(10, 2)), CAST(N'2020-12-21' AS Date), N'thumbnail_Img_path', N'Img1_path', NULL, NULL, N'White shoes for a woman', 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 
GO
INSERT [dbo].[Ratings] ([RatingID], [ProductID], [CustomerID], [Rating], [ActiveStatus]) VALUES (1, 2, 1, 5, 1)
GO
INSERT [dbo].[Ratings] ([RatingID], [ProductID], [CustomerID], [Rating], [ActiveStatus]) VALUES (2, 2, 2, 3, 1)
GO
INSERT [dbo].[Ratings] ([RatingID], [ProductID], [CustomerID], [Rating], [ActiveStatus]) VALUES (3, 2, 5, 1, 1)
GO
INSERT [dbo].[Ratings] ([RatingID], [ProductID], [CustomerID], [Rating], [ActiveStatus]) VALUES (4, 2, 6, 4, 1)
GO
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[SizesMaster] ON 
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (1, N'40', N'6', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (2, N'41', N'7', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (3, N'42', N'8', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (4, N'43', N'9', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (5, N'44', N'10', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (6, N'36', N'5', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (7, N'37', N'6', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (8, N'38', N'7', 1)
GO
INSERT [dbo].[SizesMaster] ([SizeID], [EUSize], [USSize], [ActiveStatus]) VALUES (9, N'39', N'8', 1)
GO
SET IDENTITY_INSERT [dbo].[SizesMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[Sub_Categories] ON 
GO
INSERT [dbo].[Sub_Categories] ([SubCategoryID], [CategoryID], [SubCategoryName], [Description], [ActiveStatus]) VALUES (1, 1, N'Men''s Shoes', N'Men''s Shoes', 1)
GO
INSERT [dbo].[Sub_Categories] ([SubCategoryID], [CategoryID], [SubCategoryName], [Description], [ActiveStatus]) VALUES (2, 2, N'Women''s Shoes', N'Women''s Shoes', 1)
GO
INSERT [dbo].[Sub_Categories] ([SubCategoryID], [CategoryID], [SubCategoryName], [Description], [ActiveStatus]) VALUES (3, 3, N'Kids'' Shoes', N'Kids'' Shoes', 1)
GO
SET IDENTITY_INSERT [dbo].[Sub_Categories] OFF
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Customers]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_OrdersData] FOREIGN KEY([OrderID])
REFERENCES [dbo].[OrdersData] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_OrdersData]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_ProductMappings] FOREIGN KEY([ProductMappingID])
REFERENCES [dbo].[ProductMappings] ([ProductMappingID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_ProductMappings]
GO
ALTER TABLE [dbo].[OrdersData]  WITH CHECK ADD  CONSTRAINT [FK_OrdersData_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[OrdersData] CHECK CONSTRAINT [FK_OrdersData_Customers]
GO
ALTER TABLE [dbo].[ProductMappings]  WITH CHECK ADD  CONSTRAINT [FK_ProductMappings_ColorMaster] FOREIGN KEY([ColorID])
REFERENCES [dbo].[ColorMaster] ([ColorID])
GO
ALTER TABLE [dbo].[ProductMappings] CHECK CONSTRAINT [FK_ProductMappings_ColorMaster]
GO
ALTER TABLE [dbo].[ProductMappings]  WITH CHECK ADD  CONSTRAINT [FK_ProductMappings_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductMappings] CHECK CONSTRAINT [FK_ProductMappings_Products]
GO
ALTER TABLE [dbo].[ProductMappings]  WITH CHECK ADD  CONSTRAINT [FK_ProductMappings_SizesMaster] FOREIGN KEY([SizeID])
REFERENCES [dbo].[SizesMaster] ([SizeID])
GO
ALTER TABLE [dbo].[ProductMappings] CHECK CONSTRAINT [FK_ProductMappings_SizesMaster]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Sub_Categories] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[Sub_Categories] ([SubCategoryID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Sub_Categories]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Customers]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Products]
GO
ALTER TABLE [dbo].[Sub_Categories]  WITH CHECK ADD  CONSTRAINT [FK_Sub Categories_Categories] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Sub_Categories] CHECK CONSTRAINT [FK_Sub Categories_Categories]
GO
USE [master]
GO
ALTER DATABASE [StyleSphereDB] SET  READ_WRITE 
GO
