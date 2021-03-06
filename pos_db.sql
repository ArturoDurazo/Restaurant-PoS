USE [master]
GO
/****** Object:  Database [pos_db]    Script Date: 04-Dec-20 7:03:01 PM ******/
CREATE DATABASE [pos_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pos_db', FILENAME = N'F:\SQL Server 3\MSSQL15.SQLEXPRESS01\MSSQL\DATA\pos_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pos_db_log', FILENAME = N'F:\SQL Server 3\MSSQL15.SQLEXPRESS01\MSSQL\DATA\pos_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [pos_db] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pos_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pos_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pos_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pos_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pos_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pos_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [pos_db] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [pos_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pos_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pos_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pos_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pos_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pos_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pos_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pos_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pos_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [pos_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pos_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pos_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pos_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pos_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pos_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [pos_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pos_db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [pos_db] SET  MULTI_USER 
GO
ALTER DATABASE [pos_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pos_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pos_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pos_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pos_db] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pos_db] SET QUERY_STORE = OFF
GO
USE [pos_db]
GO
/****** Object:  Table [dbo].[items]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[items](
	[category] [int] NULL,
	[item_id] [int] NOT NULL,
	[item_name] [varchar](50) NULL,
	[food_image] [varchar](50) NULL,
	[price] [int] NULL,
	[description] [varchar](50) NULL,
	[available] [bit] NULL,
	[toggled] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[toggled_and_available]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[toggled_and_available] (@ITEM_ID int)
RETURNS TABLE
AS 
RETURN(SELECT available, toggled FROM items WHERE item_id = @ITEM_ID)
GO
/****** Object:  Table [dbo].[ingredients_packs]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ingredients_packs](
	[ingredient_id] [int] NOT NULL,
	[ingredient_name] [varchar](50) NULL,
	[quantity] [int] NULL,
	[supplier_id] [int] NULL,
 CONSTRAINT [PK_ingredients_packs] PRIMARY KEY CLUSTERED 
(
	[ingredient_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[ingredient_name_and_quantity]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ingredient_name_and_quantity] ()
RETURNS TABLE
AS 
RETURN(SELECT ingredient_name, quantity FROM ingredients_packs)
GO
/****** Object:  Table [dbo].[ordered_items]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordered_items](
	[item_id] [int] NULL,
	[transaction_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[stats]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[stats] AS
SELECT I.item_name, COUNT(*) AS 'Total Ordered' FROM ordered_items OI
INNER JOIN items I ON I.item_id = OI.item_id GROUP BY I.item_name
GO
/****** Object:  Table [dbo].[categories]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[category_id] [int] NOT NULL,
	[category_name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recipe]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recipe](
	[recipe_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
 CONSTRAINT [PK_recipe_1] PRIMARY KEY CLUSTERED 
(
	[recipe_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[recipe_ingredients_bridge]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[recipe_ingredients_bridge](
	[recipe_id] [int] NOT NULL,
	[ingredients_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[suppliers]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[suppliers](
	[supplier_id] [int] NOT NULL,
	[supplier_name] [varchar](50) NULL,
 CONSTRAINT [PK_suppliers] PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transactions]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transactions](
	[transaction_id] [int] IDENTITY(1,1) NOT NULL,
	[total] [int] NULL,
	[status] [int] NULL,
	[created_at] [datetime] NULL,
 CONSTRAINT [Transaction_pkey] PRIMARY KEY CLUSTERED 
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (1, N'Drinks')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (2, N'Meals')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (3, N'Desserts')
GO
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (1, N'Buns', 10, 1)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (2, N'Meat', 14, 2)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (3, N'Vegetables for Burger', 9, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (4, N'Condiments', 9, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (5, N'Sausage', 10, 2)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (6, N'Nachos Chips', 10, 1)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (7, N'Nachos Cheese', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (8, N'Dough', 4, 1)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (9, N'Pepperoni', 8, 2)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (10, N'Tomato Sauce', 8, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (11, N'Mozzarella', 8, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (12, N'Vegetables for Salad', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (13, N'Caesar Ranch', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (15, N'Regular Coke', 9, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (16, N'Sprite', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (17, N'Dr Pepper', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (18, N'Root Beer', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (19, N'Fanta', 9, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (20, N'Iced Tea', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (21, N'Coffee', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (22, N'Orange Juice', 9, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (23, N'Lemonade', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (24, N'Hibiscus', 9, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (25, N'Cheese Cake', 9, 1)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (26, N'Vanilla Ice Cream', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (27, N'Chocolate Ice Cream', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (28, N'Strawberry Ice Cream', 10, 3)
INSERT [dbo].[ingredients_packs] ([ingredient_id], [ingredient_name], [quantity], [supplier_id]) VALUES (29, N'Apple Pie Slice', 10, 1)
GO
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 1, N'Regular Coke', N'coke', 6, N'The classic Coke, cant go wrong with this one.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 2, N'Sprite', N'sprite', 6, N'The refreshing Sprite.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 3, N'Dr Pepper', N'drpepper', 6, N'For mad scientists only.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 4, N'Root Beer', N'rootbeer', 6, N'Standard Root Beer.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 5, N'Fanta', N'fanta', 6, N'Standard Fanta.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 6, N'Iced Tea', N'tea', 4, N'Ice cold tea.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 7, N'Coffee', N'coffee', 4, N'Regular Coffee.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 8, N'Orange Juice', N'orangejuice', 4, N'Fresh Orange Juice.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 9, N'Lemonade', N'lemonade', 4, N'Ice cold lemonade.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (1, 10, N'Hibiscus', N'hibiscus', 4, N'Imported from Mexico.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (2, 11, N'Hamburger', N'hamburger', 12, N'Classic american burger with bacon.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (2, 12, N'Hot Dog', N'hotdog', 6, N'Classic american Hot Dog with chili beans.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (2, 13, N'Nachos', N'nachos', 8, N'Nachos with home-made Cheese.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (2, 14, N'Pepperoni Pizza', N'pepperonipizza', 18, N'Big enough to share with friends and family.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (2, 15, N'Caesar Salad', N'caesarsalad', 12, N'A classic directly from Tijuana.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (3, 16, N'Cheese Cake', N'cheesecake', 8, N'New York style.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (3, 17, N'Vanilla Ice Cream', N'vanilla', 5, N'For old-fashioned fellas.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (3, 18, N'Chocolate Ice Cream', N'chocolate', 5, N'For the adventurous fellas.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (3, 19, N'Strawberry Ice Cream', N'strawberry', 5, N'For the wild fellas.', 1, 1)
INSERT [dbo].[items] ([category], [item_id], [item_name], [food_image], [price], [description], [available], [toggled]) VALUES (3, 20, N'Apple Pie Slice', N'apple', 7, N'Freshly Baked.', 1, 1)
GO
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 18)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 18)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (16, 18)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (3, 19)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (12, 19)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (17, 19)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (4, 20)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 20)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (16, 20)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (20, 21)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (16, 21)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (17, 21)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (6, 22)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (5, 22)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (7, 22)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 22)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (14, 22)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (12, 22)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 23)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (16, 23)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 23)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 24)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (17, 24)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (15, 24)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (13, 24)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 25)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (16, 25)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 25)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (16, 26)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 26)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 26)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 27)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (17, 27)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (12, 27)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 27)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (5, 28)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (7, 28)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (13, 28)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (19, 28)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (17, 28)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 30)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (11, 30)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (16, 30)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (1, 31)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (14, 31)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (5, 32)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (4, 33)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (10, 39)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (5, 45)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (8, 45)
INSERT [dbo].[ordered_items] ([item_id], [transaction_id]) VALUES (15, 28)
GO
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (1, 1)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (2, 2)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (3, 3)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (4, 4)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (5, 5)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (6, 6)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (7, 7)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (8, 8)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (9, 9)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (10, 10)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (11, 11)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (12, 12)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (13, 13)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (14, 14)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (15, 15)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (16, 16)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (17, 17)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (18, 18)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (19, 19)
INSERT [dbo].[recipe] ([recipe_id], [item_id]) VALUES (20, 20)
GO
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (1, 15)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (2, 16)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (3, 17)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (4, 18)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (5, 19)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (6, 20)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (7, 21)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (8, 22)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (9, 23)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (10, 24)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (11, 1)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (11, 2)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (11, 3)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (11, 4)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (12, 1)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (12, 4)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (12, 5)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (13, 6)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (13, 7)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (14, 8)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (14, 9)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (14, 10)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (14, 11)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (15, 12)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (15, 13)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (16, 25)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (17, 26)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (18, 27)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (19, 28)
INSERT [dbo].[recipe_ingredients_bridge] ([recipe_id], [ingredients_id]) VALUES (20, 29)
GO
INSERT [dbo].[suppliers] ([supplier_id], [supplier_name]) VALUES (1, N'Cheesycake Bakery')
INSERT [dbo].[suppliers] ([supplier_id], [supplier_name]) VALUES (2, N'Bills Butchery')
INSERT [dbo].[suppliers] ([supplier_id], [supplier_name]) VALUES (3, N'General Store')
GO
SET IDENTITY_INSERT [dbo].[transactions] ON 

INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (18, 26, 2, CAST(N'2020-11-04T18:39:18.880' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (19, 17, 2, CAST(N'2020-11-04T18:39:30.173' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (20, 44, 2, CAST(N'2020-11-04T18:39:39.397' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (21, 20, 2, CAST(N'2020-11-04T18:39:46.003' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (22, 50, 2, CAST(N'2020-11-04T18:39:55.967' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (23, 26, 2, CAST(N'2020-11-05T13:33:36.373' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (24, 31, 2, CAST(N'2020-11-09T17:37:30.710' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (25, 26, 2, CAST(N'2020-11-14T22:59:56.850' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (26, 62, 2, CAST(N'2020-11-19T17:08:09.447' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (27, 29, 2, CAST(N'2020-11-23T17:58:33.830' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (28, 40, 2, CAST(N'2020-11-23T18:00:15.293' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (29, 0, 2, CAST(N'2020-11-26T19:59:14.427' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (30, 26, 2, CAST(N'2020-12-01T17:57:41.790' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (31, 96, 2, CAST(N'2020-12-01T17:59:45.777' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (32, 72, 2, CAST(N'2020-12-01T18:02:31.763' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (33, 72, 2, CAST(N'2020-12-01T18:05:10.933' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (34, 26, 2, CAST(N'2020-12-02T12:49:36.300' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (35, 32, 2, CAST(N'2020-12-02T12:51:15.017' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (36, 6, 2, CAST(N'2020-12-02T12:52:10.803' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (37, 6, 2, CAST(N'2020-12-02T12:52:45.543' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (38, 6, 2, CAST(N'2020-12-02T12:53:37.740' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (39, 4, 2, CAST(N'2020-12-02T12:54:43.433' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (40, 72, 2, CAST(N'2020-12-02T12:55:42.580' AS DateTime))
INSERT [dbo].[transactions] ([transaction_id], [total], [status], [created_at]) VALUES (45, 10, 1, CAST(N'2020-12-03T16:38:23.330' AS DateTime))
SET IDENTITY_INSERT [dbo].[transactions] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [index_ingredient_name]    Script Date: 04-Dec-20 7:03:02 PM ******/
CREATE NONCLUSTERED INDEX [index_ingredient_name] ON [dbo].[ingredients_packs]
(
	[ingredient_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [index_available]    Script Date: 04-Dec-20 7:03:02 PM ******/
CREATE NONCLUSTERED INDEX [index_available] ON [dbo].[items]
(
	[available] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [index_toggled]    Script Date: 04-Dec-20 7:03:02 PM ******/
CREATE NONCLUSTERED INDEX [index_toggled] ON [dbo].[items]
(
	[toggled] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [index_transaction_id]    Script Date: 04-Dec-20 7:03:02 PM ******/
CREATE NONCLUSTERED INDEX [index_transaction_id] ON [dbo].[ordered_items]
(
	[transaction_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [index_recipe_id]    Script Date: 04-Dec-20 7:03:02 PM ******/
CREATE NONCLUSTERED INDEX [index_recipe_id] ON [dbo].[recipe_ingredients_bridge]
(
	[recipe_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[items] ADD  DEFAULT ((1)) FOR [toggled]
GO
ALTER TABLE [dbo].[ingredients_packs]  WITH CHECK ADD  CONSTRAINT [FK_ingredients_packs_suppliers] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[suppliers] ([supplier_id])
GO
ALTER TABLE [dbo].[ingredients_packs] CHECK CONSTRAINT [FK_ingredients_packs_suppliers]
GO
ALTER TABLE [dbo].[items]  WITH CHECK ADD  CONSTRAINT [FK_categories] FOREIGN KEY([category])
REFERENCES [dbo].[categories] ([category_id])
GO
ALTER TABLE [dbo].[items] CHECK CONSTRAINT [FK_categories]
GO
ALTER TABLE [dbo].[ordered_items]  WITH CHECK ADD  CONSTRAINT [FK_itemID] FOREIGN KEY([item_id])
REFERENCES [dbo].[items] ([item_id])
GO
ALTER TABLE [dbo].[ordered_items] CHECK CONSTRAINT [FK_itemID]
GO
ALTER TABLE [dbo].[ordered_items]  WITH CHECK ADD  CONSTRAINT [FK_transaction_id] FOREIGN KEY([transaction_id])
REFERENCES [dbo].[transactions] ([transaction_id])
GO
ALTER TABLE [dbo].[ordered_items] CHECK CONSTRAINT [FK_transaction_id]
GO
ALTER TABLE [dbo].[recipe]  WITH CHECK ADD  CONSTRAINT [FK_recipe_items] FOREIGN KEY([item_id])
REFERENCES [dbo].[items] ([item_id])
GO
ALTER TABLE [dbo].[recipe] CHECK CONSTRAINT [FK_recipe_items]
GO
ALTER TABLE [dbo].[recipe_ingredients_bridge]  WITH CHECK ADD  CONSTRAINT [fk_ingredient] FOREIGN KEY([ingredients_id])
REFERENCES [dbo].[ingredients_packs] ([ingredient_id])
GO
ALTER TABLE [dbo].[recipe_ingredients_bridge] CHECK CONSTRAINT [fk_ingredient]
GO
ALTER TABLE [dbo].[recipe_ingredients_bridge]  WITH CHECK ADD  CONSTRAINT [fk_recipe] FOREIGN KEY([recipe_id])
REFERENCES [dbo].[recipe] ([recipe_id])
GO
ALTER TABLE [dbo].[recipe_ingredients_bridge] CHECK CONSTRAINT [fk_recipe]
GO
/****** Object:  StoredProcedure [dbo].[addIngredients]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addIngredients]
@QTY int, 
@NAME varchar(20)
AS
UPDATE ingredients_packs
SET quantity = quantity + @QTY
WHERE ingredient_name = @NAME
GO
/****** Object:  StoredProcedure [dbo].[salesTotal]    Script Date: 04-Dec-20 7:03:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[salesTotal]
@DATEFROM varchar(20),
@DATETO varchar(20)
AS
SELECT created_at, transaction_id, total, COUNT(total) OVER(), SUM(total) OVER() 
FROM transactions 
WHERE created_at >= @DATEFROM AND created_at <= @DATETO AND status = 2
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ordered_items', @level2type=N'COLUMN',@level2name=N'item_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ordered_items', @level2type=N'COLUMN',@level2name=N'transaction_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TRIAL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ordered_items'
GO
USE [master]
GO
ALTER DATABASE [pos_db] SET  READ_WRITE 
GO
