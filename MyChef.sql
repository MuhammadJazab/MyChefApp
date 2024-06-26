USE [master]
GO
/****** Object:  Database [MyChefDB]    Script Date: 7/26/2021 3:19:02 PM ******/
CREATE DATABASE [MyChefDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyChefDB_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\MyChefDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MyChefDB_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\MyChefDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MyChefDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyChefDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyChefDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyChefDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyChefDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyChefDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyChefDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyChefDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyChefDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyChefDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyChefDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyChefDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyChefDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyChefDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyChefDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyChefDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyChefDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyChefDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyChefDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyChefDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyChefDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyChefDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyChefDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyChefDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyChefDB] SET RECOVERY FULL 
GO
ALTER DATABASE [MyChefDB] SET  MULTI_USER 
GO
ALTER DATABASE [MyChefDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyChefDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyChefDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyChefDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyChefDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MyChefDB', N'ON'
GO
ALTER DATABASE [MyChefDB] SET QUERY_STORE = OFF
GO
USE [MyChefDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [MyChefDB]
GO
/****** Object:  Table [dbo].[AccountTypes]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTypes](
	[AccountTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountTypeName] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED 
(
	[AccountTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CookingSkills]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CookingSkills](
	[CookingSkillId] [bigint] IDENTITY(1,1) NOT NULL,
	[CookingSkillName] [nvarchar](30) NULL,
 CONSTRAINT [PK_CookingSkills] PRIMARY KEY CLUSTERED 
(
	[CookingSkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodPreferences]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodPreferences](
	[FoodPreferenceId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[FoodId] [bigint] NOT NULL,
 CONSTRAINT [PK_FoodPreferences] PRIMARY KEY CLUSTERED 
(
	[FoodPreferenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[FoodID] [bigint] IDENTITY(1,1) NOT NULL,
	[FoodTypeId] [bigint] NOT NULL,
	[FoodName] [nvarchar](20) NOT NULL,
	[IsSelected] [bit] NOT NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodTypes]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodTypes](
	[FoodTypeId] [bigint] IDENTITY(1,1) NOT NULL,
	[FoodTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FoodTypes] PRIMARY KEY CLUSTERED 
(
	[FoodTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[IngredientId] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuRecipeId] [bigint] NOT NULL,
	[MenuIngredients] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[MenuRecipeId] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[MenuDay] [nvarchar](12) NOT NULL,
	[Directions] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[MenuRecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[AccountTypeId] [bigint] NOT NULL,
	[CookingSkillId] [bigint] NOT NULL,
	[HasFoodPreference] [bit] NOT NULL,
	[ProfileImage] [binary](1) NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeekMenu]    Script Date: 7/26/2021 3:19:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeekMenu](
	[MenuId] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuTitle] [nvarchar](50) NOT NULL,
	[WeekDay] [nvarchar](20) NOT NULL,
	[IsEven] [bit] NOT NULL,
 CONSTRAINT [PK_WeekMenu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AccountTypes] ON 

INSERT [dbo].[AccountTypes] ([AccountTypeId], [AccountTypeName]) VALUES (1, N'Free')
INSERT [dbo].[AccountTypes] ([AccountTypeId], [AccountTypeName]) VALUES (2, N'Premium')
INSERT [dbo].[AccountTypes] ([AccountTypeId], [AccountTypeName]) VALUES (3, N'FKPremium')
SET IDENTITY_INSERT [dbo].[AccountTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[CookingSkills] ON 

INSERT [dbo].[CookingSkills] ([CookingSkillId], [CookingSkillName]) VALUES (1, N'Fresh Meat')
INSERT [dbo].[CookingSkills] ([CookingSkillId], [CookingSkillName]) VALUES (2, N'Seasoned Cook')
INSERT [dbo].[CookingSkills] ([CookingSkillId], [CookingSkillName]) VALUES (3, N'Prep. Cook')
INSERT [dbo].[CookingSkills] ([CookingSkillId], [CookingSkillName]) VALUES (4, N'Line Cook')
INSERT [dbo].[CookingSkills] ([CookingSkillId], [CookingSkillName]) VALUES (5, N'Sous Chef')
INSERT [dbo].[CookingSkills] ([CookingSkillId], [CookingSkillName]) VALUES (6, N'Executive Chef')
SET IDENTITY_INSERT [dbo].[CookingSkills] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodPreferences] ON 

INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (1, 5, 11)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (2, 5, 13)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (3, 5, 14)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (4, 5, 15)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (5, 5, 18)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (6, 5, 20)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (7, 5, 10)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (8, 5, 26)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (9, 5, 1)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (10, 5, 3)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (11, 5, 11)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (12, 5, 12)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (13, 5, 13)
INSERT [dbo].[FoodPreferences] ([FoodPreferenceId], [UserId], [FoodId]) VALUES (14, 5, 14)
SET IDENTITY_INSERT [dbo].[FoodPreferences] OFF
GO
SET IDENTITY_INSERT [dbo].[Foods] ON 

INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (1, 4, N'Peanuts', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (2, 4, N'Dairy', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (3, 4, N'Gluten', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (4, 4, N'Sugar', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (5, 4, N'Salt', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (6, 4, N'Spicy', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (7, 4, N'Soy', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (8, 4, N'Shellfish', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (9, 4, N'Tree Nuts', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (10, 3, N'Asparagus', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (11, 1, N'Shellfish', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (12, 1, N'Fish', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (13, 1, N'Chicken', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (14, 1, N'Beef', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (15, 2, N'Peas', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (16, 2, N'Lentile', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (17, 2, N'Beans', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (18, 2, N'Couscous', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (19, 2, N'Quinoa', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (20, 2, N'Pasta', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (21, 2, N'Corn', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (22, 2, N'Rice', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (23, 3, N'Garlic', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (24, 3, N'Cucumbers', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (25, 1, N'Turkey', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (26, 3, N'Green beans', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (27, 3, N'Celery', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (28, 3, N'Sprouts', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (29, 3, N'Brussel', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (30, 3, N'Squash', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (31, 4, N'Sweet Potato', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (32, 3, N'Yams', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (33, 3, N'Potato', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (34, 3, N'Tomatoes', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (35, 3, N'Onion', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (36, 3, N'Mushrooms', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (37, 3, N'Leafy Greens', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (38, 3, N'Carrots', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (39, 3, N'Cabbage', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (40, 3, N'Broccoli', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (41, 3, N'Couliflower', 0)
INSERT [dbo].[Foods] ([FoodID], [FoodTypeId], [FoodName], [IsSelected]) VALUES (42, 1, N'Pork', 0)
SET IDENTITY_INSERT [dbo].[Foods] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodTypes] ON 

INSERT [dbo].[FoodTypes] ([FoodTypeId], [FoodTypeName]) VALUES (1, N'Protein')
INSERT [dbo].[FoodTypes] ([FoodTypeId], [FoodTypeName]) VALUES (2, N'Grain')
INSERT [dbo].[FoodTypes] ([FoodTypeId], [FoodTypeName]) VALUES (3, N'Veggie')
INSERT [dbo].[FoodTypes] ([FoodTypeId], [FoodTypeName]) VALUES (4, N'AllergieAndRestriction')
SET IDENTITY_INSERT [dbo].[FoodTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (6, 2, N'ff f f f ')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (7, 2, N' asf')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (8, 2, N'asdfa')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (9, 2, N'fda')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (10, 2, N'fa')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (11, 2, N'fsda')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (12, 2, N'fsd')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (13, 3, N'ff')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (14, 3, N'  d')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (15, 3, N'ffd')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (16, 3, N'fd')
INSERT [dbo].[Ingredients] ([IngredientId], [MenuRecipeId], [MenuIngredients]) VALUES (17, 3, N'ffdsf')
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipes] ON 

INSERT [dbo].[Recipes] ([MenuRecipeId], [MenuId], [MenuDay], [Directions]) VALUES (2, 6, N'Monday', N'alsdfjalsjfaljsf;la fas f;afjk afjkdal;fj ;akdfjc a;ja; fd')
INSERT [dbo].[Recipes] ([MenuRecipeId], [MenuId], [MenuDay], [Directions]) VALUES (3, 7, N'Tuesday', N'fff asd as fasf as fa. dfas')
SET IDENTITY_INSERT [dbo].[Recipes] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Email], [Password], [UserName], [AccountTypeId], [CookingSkillId], [HasFoodPreference], [ProfileImage], [IsAdmin]) VALUES (5, N'test@test.com', N'123456', N'test', 1, 1, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[WeekMenu] ON 

INSERT [dbo].[WeekMenu] ([MenuId], [MenuTitle], [WeekDay], [IsEven]) VALUES (6, N'Test', N'Monday', 0)
INSERT [dbo].[WeekMenu] ([MenuId], [MenuTitle], [WeekDay], [IsEven]) VALUES (7, N'asdfasdf', N'Tuesday', 0)
SET IDENTITY_INSERT [dbo].[WeekMenu] OFF
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_HasFoodPreference]  DEFAULT ((0)) FOR [HasFoodPreference]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
USE [master]
GO
ALTER DATABASE [MyChefDB] SET  READ_WRITE 
GO
