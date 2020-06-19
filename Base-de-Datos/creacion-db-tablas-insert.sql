USE [master]
GO
/****** Object:  Database [CV]    Script Date: 19/6/2020 10:08:20 ******/
CREATE DATABASE [CV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLMARTIN\MSSQL\DATA\CV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLMARTIN\MSSQL\DATA\CV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CV] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CV] SET ARITHABORT OFF 
GO
ALTER DATABASE [CV] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CV] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CV] SET RECOVERY FULL 
GO
ALTER DATABASE [CV] SET  MULTI_USER 
GO
ALTER DATABASE [CV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CV] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CV', N'ON'
GO
ALTER DATABASE [CV] SET QUERY_STORE = OFF
GO
USE [CV]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CV]
GO
/****** Object:  Table [dbo].[Conocimiento]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conocimiento](
	[ConocimientoId] [int] IDENTITY(1,1) NOT NULL,
	[DatosPersonalesId] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Nivel] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Conocimiento] PRIMARY KEY CLUSTERED 
(
	[ConocimientoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DatosPersonales]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatosPersonales](
	[DatospersonalesId] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Nacionalidad] [varchar](20) NOT NULL,
	[LugarNacimiento] [varchar](30) NOT NULL,
	[Domicilio] [varchar](50) NOT NULL,
	[NroDomicilio] [int] NULL,
	[CodigoPostal] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Telefono] [int] NULL,
 CONSTRAINT [PK_DatosPersonales] PRIMARY KEY CLUSTERED 
(
	[DatospersonalesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Educacion]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Educacion](
	[EducacionId] [int] IDENTITY(1,1) NOT NULL,
	[DatosPersonalesId] [int] NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[EstablecimientoEducativo] [varchar](50) NOT NULL,
	[FechaDesde] [date] NOT NULL,
	[FechaHasta] [date] NOT NULL,
	[Estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Educacion] PRIMARY KEY CLUSTERED 
(
	[EducacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExperienciaLaboral]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExperienciaLaboral](
	[ExperienciaLaboralId] [int] NOT NULL,
	[DatosPersonalesId] [int] NOT NULL,
	[Puesto] [varchar](10) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[FechaDesde] [date] NOT NULL,
	[FechaHasta] [date] NOT NULL,
	[ReferenciaNombre] [varchar](50) NULL,
	[ReferenciaTelefono] [int] NULL,
 CONSTRAINT [PK_ExperienciaLaboral] PRIMARY KEY CLUSTERED 
(
	[ExperienciaLaboralId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[IdiomaId] [int] IDENTITY(1,1) NOT NULL,
	[DatosPersonalesId] [int] NOT NULL,
	[NIvel] [varchar](10) NOT NULL,
	[Descripcion] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[IdiomaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Imagen]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Imagen](
	[ImagenId] [int] IDENTITY(1,1) NOT NULL,
	[DatosPersonalesId] [int] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Imagen] PRIMARY KEY CLUSTERED 
(
	[ImagenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Objetivo]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objetivo](
	[ObjetivoId] [int] IDENTITY(1,1) NOT NULL,
	[DatosPersonalesId] [int] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Objetivo] PRIMARY KEY CLUSTERED 
(
	[ObjetivoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registro]    Script Date: 19/6/2020 10:08:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registro](
	[RegistroId] [int] IDENTITY(1,1) NOT NULL,
	[DatosPersonalesId] [int] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[ConfirmacionEmail] [bit] NULL,
 CONSTRAINT [PK_Registro] PRIMARY KEY CLUSTERED 
(
	[RegistroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DatosPersonales] ON 
GO
INSERT [dbo].[DatosPersonales] ([DatospersonalesId], [Nombres], [Apellido], [FechaNacimiento], [Nacionalidad], [LugarNacimiento], [Domicilio], [NroDomicilio], [CodigoPostal], [Email], [Telefono]) VALUES (1, N'Martín Alejandro', N'Matias', CAST(N'1986-06-01' AS Date), N'Argentino', N'Capital Federal', N'Amancio Alcorta', 2630, N'1752', N'martinmatias@outlook.com', 1562317237)
GO
INSERT [dbo].[DatosPersonales] ([DatospersonalesId], [Nombres], [Apellido], [FechaNacimiento], [Nacionalidad], [LugarNacimiento], [Domicilio], [NroDomicilio], [CodigoPostal], [Email], [Telefono]) VALUES (2, N'Pepe', N'Sapo', CAST(N'2020-01-20' AS Date), N'Argentino', N'Caba', N'Ayala', 100, N'1000', N'martinmatias@outlook.com', 1162317237)
GO
SET IDENTITY_INSERT [dbo].[DatosPersonales] OFF
GO
SET IDENTITY_INSERT [dbo].[Imagen] ON 
GO
INSERT [dbo].[Imagen] ([ImagenId], [DatosPersonalesId], [Nombre]) VALUES (1, 1, N'prueba.jpg')
GO
SET IDENTITY_INSERT [dbo].[Imagen] OFF
GO
ALTER TABLE [dbo].[Conocimiento]  WITH CHECK ADD  CONSTRAINT [FK_Conocimiento_DatosPersonales] FOREIGN KEY([DatosPersonalesId])
REFERENCES [dbo].[DatosPersonales] ([DatospersonalesId])
GO
ALTER TABLE [dbo].[Conocimiento] CHECK CONSTRAINT [FK_Conocimiento_DatosPersonales]
GO
ALTER TABLE [dbo].[Educacion]  WITH CHECK ADD  CONSTRAINT [FK_Educacion_DatosPersonales] FOREIGN KEY([DatosPersonalesId])
REFERENCES [dbo].[DatosPersonales] ([DatospersonalesId])
GO
ALTER TABLE [dbo].[Educacion] CHECK CONSTRAINT [FK_Educacion_DatosPersonales]
GO
ALTER TABLE [dbo].[ExperienciaLaboral]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciaLaboral_DatosPersonales] FOREIGN KEY([DatosPersonalesId])
REFERENCES [dbo].[DatosPersonales] ([DatospersonalesId])
GO
ALTER TABLE [dbo].[ExperienciaLaboral] CHECK CONSTRAINT [FK_ExperienciaLaboral_DatosPersonales]
GO
ALTER TABLE [dbo].[Idioma]  WITH CHECK ADD  CONSTRAINT [FK_Idioma_DatosPersonales] FOREIGN KEY([DatosPersonalesId])
REFERENCES [dbo].[DatosPersonales] ([DatospersonalesId])
GO
ALTER TABLE [dbo].[Idioma] CHECK CONSTRAINT [FK_Idioma_DatosPersonales]
GO
ALTER TABLE [dbo].[Imagen]  WITH CHECK ADD  CONSTRAINT [FK_Imagen_DatosPersonales] FOREIGN KEY([DatosPersonalesId])
REFERENCES [dbo].[DatosPersonales] ([DatospersonalesId])
GO
ALTER TABLE [dbo].[Imagen] CHECK CONSTRAINT [FK_Imagen_DatosPersonales]
GO
ALTER TABLE [dbo].[Objetivo]  WITH CHECK ADD  CONSTRAINT [FK_Objetivo_DatosPersonales] FOREIGN KEY([DatosPersonalesId])
REFERENCES [dbo].[DatosPersonales] ([DatospersonalesId])
GO
ALTER TABLE [dbo].[Objetivo] CHECK CONSTRAINT [FK_Objetivo_DatosPersonales]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_DatosPersonales] FOREIGN KEY([DatosPersonalesId])
REFERENCES [dbo].[DatosPersonales] ([DatospersonalesId])
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_DatosPersonales]
GO
USE [master]
GO
ALTER DATABASE [CV] SET  READ_WRITE 
GO
