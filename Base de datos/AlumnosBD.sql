USE [master]
GO
/****** Object:  Database [Alumnos]    Script Date: 25/11/2020 14:10:16 ******/
CREATE DATABASE [Alumnos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Alumnos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Alumnos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Alumnos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Alumnos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Alumnos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Alumnos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Alumnos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Alumnos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Alumnos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Alumnos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Alumnos] SET ARITHABORT OFF 
GO
ALTER DATABASE [Alumnos] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Alumnos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Alumnos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Alumnos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Alumnos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Alumnos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Alumnos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Alumnos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Alumnos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Alumnos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Alumnos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Alumnos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Alumnos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Alumnos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Alumnos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Alumnos] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Alumnos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Alumnos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Alumnos] SET  MULTI_USER 
GO
ALTER DATABASE [Alumnos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Alumnos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Alumnos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Alumnos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Alumnos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Alumnos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Alumnos] SET QUERY_STORE = OFF
GO
USE [Alumnos]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 25/11/2020 14:10:16 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 25/11/2020 14:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[IdAlumno] [int] IDENTITY(1,1) NOT NULL,
	[FkCarreraId] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Edad] [tinyint] NOT NULL,
	[DNI] [int] NOT NULL,
	[FkAsignaturaId] [int] NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[IdAlumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignaturas]    Script Date: 25/11/2020 14:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaturas](
	[IdAsignatura] [int] NOT NULL,
	[FkMateriaId] [int] NOT NULL,
	[FkNotaId] [int] NOT NULL,
	[FkAlumnoId] [int] NOT NULL,
	[Comision] [int] NOT NULL,
	[Horario] [int] NOT NULL,
 CONSTRAINT [PK_Asignaturas] PRIMARY KEY CLUSTERED 
(
	[IdAsignatura] ASC,
	[FkMateriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 25/11/2020 14:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[IdCarrera] [int] IDENTITY(1,1) NOT NULL,
	[FkFacultadId] [int] NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Titulo] [nvarchar](max) NOT NULL,
	[DuracionEstimadaAnios] [float] NOT NULL,
 CONSTRAINT [PK_Carreras] PRIMARY KEY CLUSTERED 
(
	[IdCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultades]    Script Date: 25/11/2020 14:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultades](
	[IdFacultad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Telefono] [int] NULL,
	[DepartamentoAlumnos] [nvarchar](max) NULL,
	[Facebook] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[PaginaWeb] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[RecorridoVirtual] [nvarchar](max) NULL,
 CONSTRAINT [PK_Facultades] PRIMARY KEY CLUSTERED 
(
	[IdFacultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 25/11/2020 14:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[MateriaId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Codigo] [nchar](10) NULL,
	[Categoria] [nvarchar](max) NULL,
	[Horas] [smallint] NULL,
	[Correlativas] [nvarchar](50) NULL,
	[FkCarreraId] [int] NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[MateriaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notas]    Script Date: 25/11/2020 14:10:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notas](
	[IdNotas] [int] IDENTITY(1,1) NOT NULL,
	[PrimerParcial] [float] NOT NULL,
	[PrimerRecuperatorio] [float] NOT NULL,
	[SegundoParcial] [float] NOT NULL,
	[SegundoRecuperatorio] [float] NOT NULL,
	[Final] [float] NOT NULL,
 CONSTRAINT [PK_Notas] PRIMARY KEY CLUSTERED 
(
	[IdNotas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Alumnos_CarreraIdCarrera]    Script Date: 25/11/2020 14:10:16 ******/
CREATE NONCLUSTERED INDEX [IX_Alumnos_CarreraIdCarrera] ON [dbo].[Alumnos]
(
	[FkCarreraId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Asignaturas_NotaIdNotas]    Script Date: 25/11/2020 14:10:16 ******/
CREATE NONCLUSTERED INDEX [IX_Asignaturas_NotaIdNotas] ON [dbo].[Asignaturas]
(
	[FkNotaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Alumnos] FOREIGN KEY([IdAlumno])
REFERENCES [dbo].[Alumnos] ([IdAlumno])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Alumnos]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Carreras_FkCarreraId] FOREIGN KEY([FkCarreraId])
REFERENCES [dbo].[Carreras] ([IdCarrera])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Carreras_FkCarreraId]
GO
ALTER TABLE [dbo].[Asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Asignaturas_Alumnos_FkAlumnoId] FOREIGN KEY([FkAlumnoId])
REFERENCES [dbo].[Alumnos] ([IdAlumno])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignaturas] CHECK CONSTRAINT [FK_Asignaturas_Alumnos_FkAlumnoId]
GO
ALTER TABLE [dbo].[Asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Asignaturas_Materias_FkMateriaId] FOREIGN KEY([FkMateriaId])
REFERENCES [dbo].[Materias] ([MateriaId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignaturas] CHECK CONSTRAINT [FK_Asignaturas_Materias_FkMateriaId]
GO
ALTER TABLE [dbo].[Asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Asignaturas_Notas_FkNotaId] FOREIGN KEY([FkNotaId])
REFERENCES [dbo].[Notas] ([IdNotas])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Asignaturas] CHECK CONSTRAINT [FK_Asignaturas_Notas_FkNotaId]
GO
ALTER TABLE [dbo].[Carreras]  WITH CHECK ADD  CONSTRAINT [FK_Carreras_Facultades_FkFacultadId] FOREIGN KEY([FkFacultadId])
REFERENCES [dbo].[Facultades] ([IdFacultad])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carreras] CHECK CONSTRAINT [FK_Carreras_Facultades_FkFacultadId]
GO
ALTER TABLE [dbo].[Materias]  WITH CHECK ADD  CONSTRAINT [FK_Materias_Carrera_FkCarreraId] FOREIGN KEY([FkCarreraId])
REFERENCES [dbo].[Carreras] ([IdCarrera])
GO
ALTER TABLE [dbo].[Materias] CHECK CONSTRAINT [FK_Materias_Carrera_FkCarreraId]
GO
USE [master]
GO
ALTER DATABASE [Alumnos] SET  READ_WRITE 
GO
