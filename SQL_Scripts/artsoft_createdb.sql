USE [master]
GO
/****** Object:  Database [ArtsofteDB]    Script Date: 21.08.2022 11:55:57 ******/
CREATE DATABASE [ArtsofteDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArtsofteDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ArtsofteDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ArtsofteDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ArtsofteDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ArtsofteDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArtsofteDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArtsofteDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArtsofteDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArtsofteDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArtsofteDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArtsofteDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArtsofteDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ArtsofteDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArtsofteDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArtsofteDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArtsofteDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArtsofteDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArtsofteDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArtsofteDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArtsofteDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArtsofteDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArtsofteDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArtsofteDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArtsofteDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArtsofteDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArtsofteDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArtsofteDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArtsofteDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArtsofteDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArtsofteDB] SET  MULTI_USER 
GO
ALTER DATABASE [ArtsofteDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArtsofteDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArtsofteDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArtsofteDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ArtsofteDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ArtsofteDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ArtsofteDB] SET QUERY_STORE = OFF
GO
USE [ArtsofteDB]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Floor] [int] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[SurName] [varchar](50) NULL,
	[DepartmentId] [int] NOT NULL,
	[ProgrammingLangId] [int] NOT NULL,
	[Age] [int] NULL,
	[Gender] [varchar](10) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Programming_language]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Programming_language](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Programming_language] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_progLang] FOREIGN KEY([ProgrammingLangId])
REFERENCES [dbo].[Programming_language] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_progLang]
GO
/****** Object:  StoredProcedure [dbo].[DepartmentSelectCommand]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[DepartmentSelectCommand]
AS
	SET NOCOUNT ON;
select * from dbo.Department
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDeleteCommand]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeDeleteCommand]
(
	@Id int
)
AS
	SET NOCOUNT OFF;
DELETE FROM [dbo].[Employee] WHERE [Id] = @Id;
GO
/****** Object:  StoredProcedure [dbo].[EmployeeInsertCommand]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeInsertCommand]
(
	@Name varchar(50),
	@SurName varchar(50),
	@DepartmentId int,
	@ProgrammingLangId int,
	@Age int,
	@Gender varchar(10)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [dbo].[Employee] ([Name], [SurName], [DepartmentId], [ProgrammingLangId], [Age], [Gender]) VALUES (@Name, @SurName, @DepartmentId, @ProgrammingLangId, @Age, @Gender);
	
SELECT Id, Name, SurName, DepartmentId, ProgrammingLangId, Age, Gender FROM Employee WHERE (Id = SCOPE_IDENTITY())
GO
/****** Object:  StoredProcedure [dbo].[EmployeeSelectById]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EmployeeSelectById]
@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT Id, Name, SurName, DepartmentId, ProgrammingLangId, Age, Gender FROM Employee WHERE (Id = @Id)
END
GO
/****** Object:  StoredProcedure [dbo].[EmployeeSelectCommand]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeSelectCommand]
AS
	SET NOCOUNT ON;
select l.Id, l.Name, l.SurName, l.Age, l.dName, p.Name from 
(select e.Id, e.Name, e.SurName, e.DepartmentId, e.ProgrammingLangId, e.Age, d.Name dName 
		from dbo.Employee e    join dbo.Department d on e.DepartmentId = d.Id) l
join dbo.Programming_language p on p.Id = l.ProgrammingLangId
GO
/****** Object:  StoredProcedure [dbo].[EmployeeUpdateCommand]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmployeeUpdateCommand]
(
	@Id int,
	@Name varchar(50),
	@SurName varchar(50),
	@DepartmentId int,
	@ProgrammingLangId int,
	@Age int,
	@Gender varchar(10)

)
AS
	SET NOCOUNT OFF;
UPDATE [dbo].[Employee] SET [Name] = @Name, 
[SurName] = @SurName, 
[DepartmentId] = @DepartmentId, 
[ProgrammingLangId] = @ProgrammingLangId, 
[Age] = @Age, 
[Gender] = @Gender 
WHERE [Id] = @Id;
	
SELECT Id, Name, SurName, DepartmentId, ProgrammingLangId, Age, Gender FROM Employee WHERE (Id = @Id)
GO
/****** Object:  StoredProcedure [dbo].[ProgLangSelectCommand]    Script Date: 21.08.2022 11:55:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[ProgLangSelectCommand]
AS
	SET NOCOUNT ON;
select * from dbo.Programming_language
GO
USE [master]
GO
ALTER DATABASE [ArtsofteDB] SET  READ_WRITE 
GO
