USE [master]
GO
/****** Object:  Database [SampleSuperstore]    Script Date: 4/27/2017 7:18:02 PM ******/
CREATE DATABASE [SampleSuperstore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SampleSuperstore', FILENAME = N'C:\Users\kp12g_000\SampleSuperstore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SampleSuperstore_log', FILENAME = N'C:\Users\kp12g_000\SampleSuperstore_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SampleSuperstore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SampleSuperstore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SampleSuperstore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SampleSuperstore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SampleSuperstore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SampleSuperstore] SET ARITHABORT OFF 
GO
ALTER DATABASE [SampleSuperstore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SampleSuperstore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SampleSuperstore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SampleSuperstore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SampleSuperstore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SampleSuperstore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SampleSuperstore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SampleSuperstore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SampleSuperstore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SampleSuperstore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SampleSuperstore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SampleSuperstore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SampleSuperstore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SampleSuperstore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SampleSuperstore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SampleSuperstore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SampleSuperstore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SampleSuperstore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SampleSuperstore] SET  MULTI_USER 
GO
ALTER DATABASE [SampleSuperstore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SampleSuperstore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SampleSuperstore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SampleSuperstore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SampleSuperstore] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SampleSuperstore]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SampleSuperstore]
GO
/****** Object:  UserDefinedTableType [dbo].[ManagerType]    Script Date: 4/27/2017 7:18:02 PM ******/
CREATE TYPE [dbo].[ManagerType] AS TABLE(
	[Name] [varchar](100) NULL,
	[Region] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[OrderType]    Script Date: 4/27/2017 7:18:02 PM ******/
CREATE TYPE [dbo].[OrderType] AS TABLE(
	[OrderID] [nchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[ShipDate] [datetime] NULL,
	[ShipMode] [varchar](50) NULL,
	[CustomerID] [varchar](20) NULL,
	[CustomerName] [nvarchar](100) NULL,
	[Segment] [varchar](100) NULL,
	[Country] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](10) NULL,
	[Region] [varchar](100) NULL,
	[ProductID] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[SubCategory] [varchar](50) NULL,
	[ProductName] [varchar](200) NULL,
	[Sales] [float] NULL,
	[Quantity] [int] NULL,
	[Discount] [float] NULL,
	[Profit] [float] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[ReturnType]    Script Date: 4/27/2017 7:18:03 PM ******/
CREATE TYPE [dbo].[ReturnType] AS TABLE(
	[OrderID] [varchar](50) NULL,
	[Returned] [bit] NULL
)
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 4/27/2017 7:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Managers](
	[Name] [varchar](100) NOT NULL,
	[Region] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/27/2017 7:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [nvarchar](50) NOT NULL,
	[OrderDate] [datetime] NULL,
	[ShipDate] [datetime] NULL,
	[ShipMode] [varchar](50) NULL,
	[CustomerID] [varchar](50) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[Segment] [varchar](100) NULL,
	[Country] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](100) NULL,
	[PostalCode] [varchar](10) NULL,
	[Region] [varchar](100) NULL,
	[ProductID] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[SubCategory] [varchar](50) NULL,
	[ProductName] [varchar](200) NULL,
	[Sales] [float] NULL,
	[Quantity] [int] NULL,
	[Discount] [float] NULL,
	[Profit] [float] NULL,
 CONSTRAINT [PK_Orders_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Returns]    Script Date: 4/27/2017 7:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Returns](
	[OrderID] [nvarchar](50) NOT NULL,
	[Returned] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Returns]    Script Date: 4/27/2017 7:18:03 PM ******/
CREATE NONCLUSTERED INDEX [IX_Returns] ON [dbo].[Returns]
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddManagers]    Script Date: 4/27/2017 7:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[AddManagers]
@Name varchar(100),
@Region varchar(50)
as
Insert Into Managers(Name, Region)
Values (@Name, @Region)

GO
/****** Object:  StoredProcedure [dbo].[AddManagersBulkImport]    Script Date: 4/27/2017 7:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[AddManagersBulkImport]
@ManagerData ManagerType READONLY
as
Insert Into Managers(Name, Region)
Select Name, Region
From @ManagerData

GO
/****** Object:  StoredProcedure [dbo].[OrdersBulkImport]    Script Date: 4/27/2017 7:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[OrdersBulkImport] 
	-- Add the parameters for the stored procedure here

	@OrderData OrderType READONLY
	AS
--BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert Into Orders(OrderID, OrderDate, ShipDate, ShipMode, CustomerID, CustomerName,
	Segment, Country, City, State, PostalCode, Region, ProductID, Category, SubCategory, ProductName,
	Sales, Quantity, Discount, Profit)
	Select OrderID, OrderDate, ShipDate, ShipMode, CustomerID, CustomerName,
	Segment, Country, City, State, PostalCode, Region, ProductID, Category, SubCategory, ProductName,
	Sales, Quantity, Discount, Profit
	From @OrderData
	Where Not Exists(
		Select null 
		From Orders
		where Orders.OrderID = OrderID and Orders.CustomerID = CustomerID)
--END

GO
/****** Object:  StoredProcedure [dbo].[ReturnsBulkImport]    Script Date: 4/27/2017 7:18:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReturnsBulkImport]
	-- Add the parameters for the stored procedure here
	@ReturnData ReturnType READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert Into Returns(OrderID, Returned)
	Select OrderID, Returned
	From @ReturnData
END

GO
USE [master]
GO
ALTER DATABASE [SampleSuperstore] SET  READ_WRITE 
GO
