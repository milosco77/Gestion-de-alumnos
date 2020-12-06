USE [Alumnos]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Notas]') AND type in (N'U'))
ALTER TABLE [dbo].[Notas] DROP CONSTRAINT IF EXISTS [FK_Notas_Asignaturas_AsignaturaID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListadoCarreras]') AND type in (N'U'))
ALTER TABLE [dbo].[ListadoCarreras] DROP CONSTRAINT IF EXISTS [FK_Carreras_Facultades_FacultadID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ListadoAsignaturas]') AND type in (N'U'))
ALTER TABLE [dbo].[ListadoAsignaturas] DROP CONSTRAINT IF EXISTS [FK_ListadoAsignaturas_Carrera_ListadoCarrerasID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Carreras]') AND type in (N'U'))
ALTER TABLE [dbo].[Carreras] DROP CONSTRAINT IF EXISTS [FK_Carreras_ListadoCarreras_ListadoCarrerasID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Carreras]') AND type in (N'U'))
ALTER TABLE [dbo].[Carreras] DROP CONSTRAINT IF EXISTS [FK_Carreras_Alumnos_AlumnoID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asignaturas]') AND type in (N'U'))
ALTER TABLE [dbo].[Asignaturas] DROP CONSTRAINT IF EXISTS [FK_Asignaturas_ListadoAsignaturas_ListadoAsignaturasID]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asignaturas]') AND type in (N'U'))
ALTER TABLE [dbo].[Asignaturas] DROP CONSTRAINT IF EXISTS [FK_Asignaturas_Carreras_CarreraID]
GO
/****** Object:  Index [UK_Carreras]    Script Date: 05/12/2020 19:50:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Carreras]') AND type in (N'U'))
ALTER TABLE [dbo].[Carreras] DROP CONSTRAINT IF EXISTS [UK_Carreras]
GO
/****** Object:  Index [UK_Asignaturas]    Script Date: 05/12/2020 19:50:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Asignaturas]') AND type in (N'U'))
ALTER TABLE [dbo].[Asignaturas] DROP CONSTRAINT IF EXISTS [UK_Asignaturas]
GO
/****** Object:  Table [dbo].[Notas]    Script Date: 05/12/2020 19:50:56 ******/
DROP TABLE IF EXISTS [dbo].[Notas]
GO
/****** Object:  Table [dbo].[ListadoCarreras]    Script Date: 05/12/2020 19:50:56 ******/
DROP TABLE IF EXISTS [dbo].[ListadoCarreras]
GO
/****** Object:  Table [dbo].[ListadoAsignaturas]    Script Date: 05/12/2020 19:50:56 ******/
DROP TABLE IF EXISTS [dbo].[ListadoAsignaturas]
GO
/****** Object:  Table [dbo].[Facultades]    Script Date: 05/12/2020 19:50:56 ******/
DROP TABLE IF EXISTS [dbo].[Facultades]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 05/12/2020 19:50:56 ******/
DROP TABLE IF EXISTS [dbo].[Carreras]
GO
/****** Object:  Table [dbo].[Asignaturas]    Script Date: 05/12/2020 19:50:56 ******/
DROP TABLE IF EXISTS [dbo].[Asignaturas]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 05/12/2020 19:50:56 ******/
DROP TABLE IF EXISTS [dbo].[Alumnos]
GO
USE [master]
GO
/****** Object:  Database [Alumnos]    Script Date: 05/12/2020 19:50:56 ******/
DROP DATABASE IF EXISTS [Alumnos]
GO
/****** Object:  Database [Alumnos]    Script Date: 05/12/2020 19:50:57 ******/
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
ALTER DATABASE [Alumnos] SET AUTO_CLOSE OFF 
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
ALTER DATABASE [Alumnos] SET READ_COMMITTED_SNAPSHOT OFF 
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
ALTER DATABASE [Alumnos] SET QUERY_STORE = OFF
GO
USE [Alumnos]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 05/12/2020 19:50:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[AlumnoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Edad] [tinyint] NOT NULL,
	[DNI] [int] NOT NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[AlumnoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asignaturas]    Script Date: 05/12/2020 19:50:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaturas](
	[AsignaturaID] [int] IDENTITY(1,1) NOT NULL,
	[ListadoAsignaturasID] [int] NOT NULL,
	[AlumnoID] [int] NOT NULL,
	[CarreraID] [int] NOT NULL,
	[Comision] [int] NOT NULL,
	[HorarioEntrada] [time](0) NOT NULL,
	[HorarioSalida] [time](0) NOT NULL,
	[Dias] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Asignaturas_1] PRIMARY KEY CLUSTERED 
(
	[ListadoAsignaturasID] ASC,
	[AlumnoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carreras]    Script Date: 05/12/2020 19:50:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carreras](
	[CarreraID] [int] IDENTITY(1,1) NOT NULL,
	[AlumnoID] [int] NOT NULL,
	[ListadoCarrerasID] [int] NOT NULL,
 CONSTRAINT [PK_Carreras_2] PRIMARY KEY CLUSTERED 
(
	[AlumnoID] ASC,
	[ListadoCarrerasID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultades]    Script Date: 05/12/2020 19:50:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultades](
	[FacultadID] [int] IDENTITY(1,1) NOT NULL,
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
	[FacultadID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListadoAsignaturas]    Script Date: 05/12/2020 19:50:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListadoAsignaturas](
	[ListadoAsignaturasID] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](5) NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Creditos] [tinyint] NULL,
	[Horas] [smallint] NULL,
	[Correlativas] [nvarchar](50) NULL,
	[Categoria] [nvarchar](max) NOT NULL,
	[ListadoCarrerasID] [int] NOT NULL,
 CONSTRAINT [PK_Materia] PRIMARY KEY CLUSTERED 
(
	[ListadoAsignaturasID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ListadoCarreras]    Script Date: 05/12/2020 19:50:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListadoCarreras](
	[ListadoCarrerasID] [int] IDENTITY(1,1) NOT NULL,
	[FacultadID] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[DuracionEstimadaAnios] [float] NOT NULL,
 CONSTRAINT [PK_Carreras] PRIMARY KEY CLUSTERED 
(
	[ListadoCarrerasID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notas]    Script Date: 05/12/2020 19:50:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notas](
	[NotasID] [int] IDENTITY(1,1) NOT NULL,
	[AsignaturaID] [int] NULL,
	[PrimerParcial] [float] NULL,
	[PrimerRecuperatorio] [float] NULL,
	[SegundoParcial] [float] NULL,
	[SegundoRecuperatorio] [float] NULL,
	[Final] [float] NULL,
 CONSTRAINT [PK_Notas] PRIMARY KEY CLUSTERED 
(
	[NotasID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alumnos] ON 

INSERT [dbo].[Alumnos] ([AlumnoID], [Nombre], [Apellido], [Edad], [DNI]) VALUES (1, N'Patricio', N'Cordoba', 28, 37035790)
INSERT [dbo].[Alumnos] ([AlumnoID], [Nombre], [Apellido], [Edad], [DNI]) VALUES (2, N'Milos', N'Perez', 29, 35654712)
INSERT [dbo].[Alumnos] ([AlumnoID], [Nombre], [Apellido], [Edad], [DNI]) VALUES (3, N'Natalia', N'Calvo', 20, 54896748)
INSERT [dbo].[Alumnos] ([AlumnoID], [Nombre], [Apellido], [Edad], [DNI]) VALUES (4, N'Camilo', N'Esperanza', 14, 63529846)
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[Asignaturas] ON 

INSERT [dbo].[Asignaturas] ([AsignaturaID], [ListadoAsignaturasID], [AlumnoID], [CarreraID], [Comision], [HorarioEntrada], [HorarioSalida], [Dias]) VALUES (1, 1, 1, 1, 100, CAST(N'13:00:00' AS Time), CAST(N'16:00:00' AS Time), N'Lunes-Miercoles-Viernes')
INSERT [dbo].[Asignaturas] ([AsignaturaID], [ListadoAsignaturasID], [AlumnoID], [CarreraID], [Comision], [HorarioEntrada], [HorarioSalida], [Dias]) VALUES (2, 109, 2, 2, 23000, CAST(N'12:30:00' AS Time), CAST(N'15:00:00' AS Time), N'Martes-Jueves')
SET IDENTITY_INSERT [dbo].[Asignaturas] OFF
GO
SET IDENTITY_INSERT [dbo].[Carreras] ON 

INSERT [dbo].[Carreras] ([CarreraID], [AlumnoID], [ListadoCarrerasID]) VALUES (1, 1, 6)
INSERT [dbo].[Carreras] ([CarreraID], [AlumnoID], [ListadoCarrerasID]) VALUES (2, 2, 6)
INSERT [dbo].[Carreras] ([CarreraID], [AlumnoID], [ListadoCarrerasID]) VALUES (3, 3, 4)
INSERT [dbo].[Carreras] ([CarreraID], [AlumnoID], [ListadoCarrerasID]) VALUES (4, 4, 5)
SET IDENTITY_INSERT [dbo].[Carreras] OFF
GO
SET IDENTITY_INSERT [dbo].[Facultades] ON 

INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (1, N'Agronomía', N'Av. San Martín 4453 - CABA - (cp:C1417DSE)', 45248000, NULL, N'https://www.facebook.com/facultaddeagronomia.uba', N'https://www.instagram.com/fauba_oficial/', N'https://twitter.com/fauba_oficial', N'http://www.agro.uba.ar/', N'siav@mail.agro.uba', N'http://www.uba.ar/recorridos/agronomia/agronomia_entrada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (2, N'Arquitectura, Diseño y Urbanismo', N'Ciudad Universitaria. Nuñez -  Pabellón III - CABA - (cp:1428)', 52859200, NULL, N'https://www.facebook.com/faducomunica/', N'https://www.instagram.com/faducomunica/', N'https://twitter.com/faducomunica', N'http://www.fadu.uba.ar/', N'webmaster@fadu.uba.ar', N'http://www.uba.ar/recorridos/fadu/fadu_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (3, N'Ciencias Económicas', N'Av. Córdoba 2122. - CABA - (cp:C1120AAQ)', 52857000, N'consultas@fce.uba.ar', N'https://www.facebook.com/economicas.uba', N'https://www.instagram.com/fceuba/', N'https://twitter.com/ubaeconomicas', N'http://www.econ.uba.ar/', NULL, N'http://www.uba.ar/recorridos/economicas/economicas_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (4, N'Ciencias Exactas y Naturales', N'Ciudad Universitaria. Nuñez - Pabellón II - CABA - (cp:1428)', 45763300, N'comunicacion@de.fcen.uba.ar', N'https://www.facebook.com/UBAExactas', N'https://www.instagram.com/exactas_uba/', N'https://twitter.com/exactas_uba', N'http://www.exactas.uba.ar/', NULL, N'http://www.uba.ar/recorridos/exactas/exactas_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (5, N'Ciencias Sociales', N'Marcelo T. de Alvear 2230. - CABA -  (cp:C1122AAJ)', 52871500, N'estudiantesgrado@sociales.uba.ar', N'https://www.facebook.com/ubasocialesoficial/', N'https://www.instagram.com/socialesuba/?hl=en', N'https://twitter.com/ubasociales?', N'http://www.sociales.uba.ar/', NULL, N'http://www.uba.ar/recorridos/sociales_constitucion/sociales_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (6, N'Ciencias Veterinarias', N'Chorroarín 280.  - CABA - (C1427CWO)', 45248400, N'alumnos@fvet.uba.ar', N'https://www.facebook.com/FvetUBA', N'https://www.instagram.com/veterinariasuba/?hl=en', NULL, N'http://www.fvet.uba.ar/', NULL, N'http://www.uba.ar/recorridos/veterinaria/veterinaria_entrada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (7, N'Derecho', N'Av. Pte. Figueroa Alcorta 2263 - CABA (C1425CKB)', 48095600, N'estudiantiles@derecho.uba.ar', N'https://www.facebook.com/DerechoUBA', N'https://www.instagram.com/fduba/', N'https://twitter.com/DerechoUBA', N'http://www.derecho.uba.ar/', NULL, N'http://www.uba.ar/recorridos/derecho/derecho_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (8, N'Farmacia y Bioquímica', N'Junín 954/6 - CABA (C1113AAD)', 52875001, N'alumnos@ffyb.uba.ar', N'https://www.facebook.com/FacultaddeFarmaciayBioquimicaUBA', N'https://www.instagram.com/ffybuba_oficial/', N'https://twitter.com/FFyB_UBA', N'http://www.ffyb.uba.ar/', NULL, N'http://www.uba.ar/recorridos/farmacia/farmacia_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (9, N'Filosofía y Letras', N'Púan 480 - CABA - (C1406CQJ)', 44320606, N'alumnos@filo.uba.ar', N'https://www.facebook.com/filosofiayletrasuba', N'https://www.instagram.com/filo.uba/', N'https://twitter.com/filo_uba', N'http://www.filo.uba.ar/', NULL, N'http://www.uba.ar/recorridos/filosofia/filosofia_puan_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (10, N'Ingeniería', N'Av. Paseo Colón 850 CABA (C1063ACV)', 43430893, N'comuniv@fi.uba.ar', N'https://www.facebook.com/ingenieriauba', N'https://www.instagram.com/ingenieriauba/', N'https://twitter.com/ingenieriauba', N'http://www.ingenieria.uba.ar/', NULL, N'http://www.uba.ar/recorridos/ingenieria_paseo_colon/ingenieria_columnas.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (11, N'Medicina', N'Paraguay 2155 - CABA (C1121ABG)', 59509500, N'diralumnos@fmed.uba.ar', N'https://www.facebook.com/Medicina-UBA-155385487867667', NULL, N'https://twitter.com/UBAMedicina', N'http://www.fmed.uba.ar/', NULL, N'http://www.uba.ar/recorridos/medicina/medicina_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (12, N'Odontología', N'Marcelo T de Alvear 2142 - CABA (C1122AAH)', 52876000, NULL, N'https://www.facebook.com/OdontoUBA', N'https://www.instagram.com/odontouba/?hl=es-la', N'https://twitter.com/odontoUBA', N'http://www.odontologia.uba.ar/', N'info@odontologia.uba.ar', N'http://www.uba.ar/recorridos/odontologia/odontologia_fachada.html')
INSERT [dbo].[Facultades] ([FacultadID], [Nombre], [Direccion], [Telefono], [DepartamentoAlumnos], [Facebook], [Instagram], [Twitter], [PaginaWeb], [Email], [RecorridoVirtual]) VALUES (13, N'Psicología', N'Hipólito Yrigoyen 3242 - CABA(C1207ABQ)', 49316900, N'diralu@psi.uba.ar', N'https://www.facebook.com/uba.psi/', N'https://www.instagram.com/uba.psicologia/', N'https://twitter.com/UBAPsicologia/', N'http://www.psi.uba.ar/', NULL, N'http://www.uba.ar/recorridos/psicologia_yrigoyen/psicologia_fachada.html')
SET IDENTITY_INSERT [dbo].[Facultades] OFF
GO
SET IDENTITY_INSERT [dbo].[ListadoAsignaturas] ON 

INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (1, N'61.03', N'Análisis Matemático II A', 8, 128, N'Ciclo Basico Comun', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (2, N'62.01', N'Física I A', 8, 128, N'Ciclo Basico Comun', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (3, N'75.40', N'Algoritmos y Programación I', 6, 96, N'Ciclo Basico Comun', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (4, N'61.08', N'Álgebra II A', 8, 128, N'Ciclo Basico Comun', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (5, N'62.03', N'Física II A', 8, 128, N'61.03-62.01', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (6, N'63.01', N'Química', 6, 96, N'Ciclo Basico Comun', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (7, N'75.41', N'Algoritmos y Programación II', 6, 96, N'75.40', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (8, N'62.15', N'Física III D', 4, 64, N'61.08-62.03-63.01', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (9, N'66.02', N'Laboratorio', 6, 96, N'62.03', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (10, N'66.70', N'Estructura del Computador', 6, 96, N'61.08-62.03-75.41', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (11, N'75.07', N'Algoritmos y Programación III', 6, 96, N'75.41', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (12, N'75.12', N'Análisis Numérico I', 6, 96, N'61.03-61.08-75.41', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (13, N'61.09', N'Probabilidad y Estadística B', 6, 96, N'61.03-61.08', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (14, N'61.10', N'Análisis Matemático III A', 6, 96, N'61.03-61.08', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (15, N'66.20', N'Organización de Computadoras', 6, 96, N'66.02-66.70', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (16, N'75.06', N'Organización de Datos', 6, 96, N'66.70-75.41', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (17, N'75.42', N'Taller de Programación I', 4, 64, N'66.70-75.12-75.41', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (18, N'71.12', N'Estructura de las Organizaciones', 6, 96, N'75.06', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (19, N'71.14', N'Modelos y Optimización I', 6, 96, N'61.10-62.03-63.01-75.42', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (20, N'75.08', N'Sistemas Operativos', 6, 96, N'75.06', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (21, N'75.09', N'Análisis de la Información', 6, 96, N'75.07-75.42', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (22, N'75.10', N'Técnicas de Diseño', 6, 96, N'75.08-75.09', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (23, N'75.15', N'Base de Datos', 6, 96, N'75.06-75.09', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (24, N'75.43', N'Introducción a los Sistemas Distribuidos', 6, 96, N'66.20-62.15-75.08', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (25, N'75.52', N'Taller de Programación II', 4, 64, N'71.14-75.07-75.42', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (26, N'71.13', N'Información en las Organizaciones', 6, 96, N'71.12', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (27, N'75.44', N'Administración y Control de Proyectos Informáticos I', 6, 96, N'71.12-75.10', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (28, N'75.45', N'Taller de Desarrollo de Proyectos I', 6, 96, N'75.10', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (29, N'75.46', N'Administración y Control de Proyectos Informáticos II', 6, 96, N'75.44', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (30, N'75.47', N'Taller de Desarrollo de Proyectos II', 6, 96, N'75.44-75.45', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (31, N'75.48', N'Calidad en Desarrollo de Sistemas', 4, 64, N'75.45', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (32, N'71.40', N'Legislación y Ejercicio Profesional de la Ingeniería en Informática', 4, 64, N'140 créditos aprobados', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (33, N'75.00', N'Tesis', 12, 192, N'140 créditos aprobados', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (34, N'75.99', N'Trabajo Profesional', 6, 96, N'140 créditos aprobados', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (35, N'66.06', N'Análisis de Circuitos', 10, 160, N'61.10-62.03', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (36, N'75.59', N'Técnicas de Programación Concurrente I', 6, 96, N'75. 08', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (37, N'66.74', N'Señales y Sistemas', 6, 96, N'61.09-66.06', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (38, N'75.74', N'Sistemas Distribuidos I', 6, 96, N'61.10-75.43-75.59', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (39, N'75.61', N'Taller de Programación III', 6, 96, N'66.74-75.74', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (40, N'64.05', N'Estática y Resistencia de Materiales B', 6, 96, N'61.03-61.08', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (41, N'75.65', N'Manufactura Integrada por Computadora (CIM) I', 6, 96, N'75.15-75.52', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (42, N'75.67', N'Sistemas Automáticos de Diagnóstico y Detección Fallas I', 6, 96, N'71.14', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (43, N'72.01', N'Materiales Industriales I', 6, 96, N'63.01-64.05', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (44, N'75.66', N'Manufactura Integrada por Computadora (CIM) II', 6, 96, N'75.65', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (45, N'75.68', N'Sistemas de Soporte para Celdas Producción Flexible', 4, 64, N'75.65-75.67', N'Segundo Ciclo', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (46, N'61.07', N'Matemática Discreta', 6, NULL, N'Ciclo Basico Comun', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (47, N'61.18', N'Ecuaciones Diferenciales Ordinarias', 6, NULL, N'61.03 - 61.08', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (48, N'61.19', N'Análisis Funcional', 6, NULL, N'61.10', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (49, N'62.11', N'Mecánica Racional', 4, NULL, N'61.10-62.01', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (50, N'66.08', N'Circuitos Electrónicos I', 8, NULL, N'62.15-66.02-66.06', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (51, N'66.09', N'Laboratorio de Microcomputadoras', 6, NULL, N'66.02-66.70', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (52, N'66.17', N'Sistemas Digitales', 6, NULL, N'66.70', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (53, N'66.18', N'Teoría de Control I', 6, NULL, N'66.74', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (54, N'66.19', N'Circuitos de Pulsos', 6, NULL, N'66.08-66.70', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (55, N'66.24', N'Teoría de la Información y Codificación', 4, NULL, N'66.74-66.75-66.70', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (56, N'66.26', N'Arquitecturas Paralelas', 6, NULL, N'66.20', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (57, N'66.32', N'Robótica', 6, NULL, N'62.11-66.18', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (58, N'66.35', N'Técnica Digital Avanzada', 6, NULL, N'61.07-66.17', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (59, N'66.46', N'Procesamiento del Habla', 6, NULL, N'66.74', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (60, N'66.47', N'Procesamiento de Imágenes', 6, NULL, N'61.09-66.74', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (61, N'66.49', N'Sistemas Biológicos', 6, NULL, N'66.74-63.01', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (62, N'66.55', N'Simulación de Sistemas de Control', 4, NULL, N'66.18', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (63, N'66.63', N'Redes Neuronales', 6, NULL, N'66.74-66.75', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (64, N'66.69', N'Criptografía y Seguridad Informática', 6, NULL, N'75.43', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (65, N'66.71', N'Sistemas Gráficos', 6, NULL, N'61.10-75.41', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (66, N'66.74', N'Señales y Sistemas', 6, NULL, N'61.09-66.06', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (67, N'66.75', N'Procesos Estocásticos', 6, NULL, N'61.03-61.09', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (68, N'67.71', N'Fundamentos Matemáticos de la Visión en Robótica', 6, NULL, N'61.08-75.07', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (69, N'71.15', N'Modelos y Optimización II', 6, NULL, N'61.09-71.14', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (70, N'71.18', N'Estructura Económica Argentina', 4, NULL, N'Ciclo Basico Comun', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (71, N'71.20', N'Modelos y Optimización III', 6, NULL, N'71.15', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (72, N'71.41', N'Análisis y Resolución de Problemas', 6, NULL, N'71.15', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (73, N'71.42', N'Circuitos de Información en la Empresa', 4, NULL, N'71.46', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (74, N'71.44', N'Recursos Humanos', 4, NULL, N'140 créditos aprobados', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (75, N'71.46', N'Ingeniería Económica', 6, NULL, N'71.13', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (76, N'75.14', N'Lenguajes Formales', 6, NULL, N'61.09', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (77, N'75.16', N'Lenguajes de Programación', 6, NULL, N'75.14', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (78, N'75.26', N'Simulación', 6, NULL, N'61.09', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (79, N'75.29', N'Teoría de Algoritmos I', 6, NULL, N'61.07-75.41', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (80, N'75.30', N'Teoría de Algoritmos II', 6, NULL, N'75.29', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (81, N'75.31', N'Teoría de Lenguaje', 4, NULL, N'75.41', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (82, N'75.38', N'Análisis Numérico II A', 6, NULL, N'75.52', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (83, N'75.50', N'Introducción a los Sistemas Inteligentes', 6, NULL, N'61.09-71.14', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (84, N'75.51', N'Técnicas de Producción de Software I', 4, NULL, N'75.15-75.52', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (85, N'75.53', N'Técnicas de Producción de Software II', 4, NULL, N'75.51', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (86, N'75.54', N'Técnicas de Producción de Software III', 4, NULL, N'75.48-75.53', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (87, N'75.55', N'Taller de Desarrollo de Proyectos III', 4, NULL, N'75.46-75.47-75.48', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (88, N'75.56', N'Organización de la Implantación y el Mantenimiento', 6, NULL, N'75.46-75.48', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (89, N'75.57', N'Modelos de Proceso de Desarrollo', 4, NULL, N'75.46-75.48', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (90, N'75.58', N'Evaluación de Proyectos y Manejo de Riesgos', 4, NULL, N'75.46-75.48', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (91, N'75.62', N'Técnicas de Programación Concurrente II', 4, NULL, N'75.59', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (92, N'75.63', N'Sistemas Distribuidos II', 4, NULL, N'75.74', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (93, N'75.64', N'Sistemas Multimediales', 4, NULL, N'66.74-75.74', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (94, N'75.69', N'Sistemas Automáticos de Diagnóstico y Detección Fallas II', 6, NULL, N'75.67', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (95, N'75.70', N'Sistemas de Programación no convencional de Robots', 6, NULL, N'75.50', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (96, N'75.71', N'Seminario de Ingeniería en Informática I', 3, NULL, N'75.07', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (97, N'75.72', N'Seminario de Ingeniería en Informática II', 3, NULL, N'75.06-75.44', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (98, N'75.73', N'Arquitectura de Software', 4, NULL, N'75.07-75.09', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (99, N'78.01', N'Idioma Inglés', 4, NULL, N'Ciclo Basico Comun', N'Electivas', 6)
GO
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (100, N'78.02', N'Idioma Alemán', 4, NULL, N'Ciclo Basico Comun', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (101, N'78.03', N'Idioma Francés', 4, NULL, N'Ciclo Basico Comun', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (102, N'78.04', N'Idioma Italiano', 4, NULL, N'Ciclo Basico Comun', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (103, N'78.05', N'Idioma Portugués', 4, NULL, N'Ciclo Basico Comun', N'Electivas', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (104, N'28   ', N'Análisis Matemático', NULL, 144, NULL, N'Primer Ciclo - Ciclo Basico Comun', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (105, N'3    ', N'Física', NULL, 96, NULL, N'Primer Ciclo - Ciclo Basico Comun', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (106, N'24   ', N'Introducción al Conocimiento de la Sociedad y el Estado', NULL, 64, NULL, N'Primer Ciclo - Ciclo Basico Comun', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (107, N'40   ', N'Introducción al Pensamiento Científico', NULL, 64, NULL, N'Primer Ciclo - Ciclo Basico Comun', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (108, N'5    ', N'Química', NULL, 96, NULL, N'Primer Ciclo - Ciclo Basico Comun', 6)
INSERT [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID], [Codigo], [Nombre], [Creditos], [Horas], [Correlativas], [Categoria], [ListadoCarrerasID]) VALUES (109, N'27   ', N'Algebra', NULL, 144, NULL, N'Primer Ciclo - Ciclo Basico Comun', 6)
SET IDENTITY_INSERT [dbo].[ListadoAsignaturas] OFF
GO
SET IDENTITY_INSERT [dbo].[ListadoCarreras] ON 

INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (1, 10, N'Ingeniería Civil', N'Ingeniero Civil', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (2, 10, N'Ingeniería en Alimentos', N'Ingeniero de Alimentos', 2.5)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (3, 10, N'Ingeniería Electricista', N'Ingeniero Electricista', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (4, 10, N'Ingeniería Electrónica', N'Ingeniero Electrónico', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (5, 10, N'Ingeniería en Agrimensura', N'Ingeniero Agrimensor', 5.5)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (6, 10, N'Ingeniería en Informática', N'Ingeniero en Informática', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (7, 10, N'Ingeniería en Petróleo', N'Ingeniero en Petróleo', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (8, 10, N'Ingeniería Industrial', N'Ingeniero Industrial', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (9, 10, N'Ingeniería Mecánica', N'Ingeniero Mácanico', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (10, 10, N'Ingeniería Naval y Mecánica', N'Ingeniero Naval y Macánico', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (11, 10, N'Ingeniería Quimica', N'Ingeniero Quimico', 6)
INSERT [dbo].[ListadoCarreras] ([ListadoCarrerasID], [FacultadID], [Nombre], [Titulo], [DuracionEstimadaAnios]) VALUES (12, 10, N'Licenciatura en Análisis de Sistemas', N'Licenciado en Análisis de Sistemas', 4.5)
SET IDENTITY_INSERT [dbo].[ListadoCarreras] OFF
GO
SET IDENTITY_INSERT [dbo].[Notas] ON 

INSERT [dbo].[Notas] ([NotasID], [AsignaturaID], [PrimerParcial], [PrimerRecuperatorio], [SegundoParcial], [SegundoRecuperatorio], [Final]) VALUES (1, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Notas] OFF
GO
/****** Object:  Index [UK_Asignaturas]    Script Date: 05/12/2020 19:50:57 ******/
ALTER TABLE [dbo].[Asignaturas] ADD  CONSTRAINT [UK_Asignaturas] UNIQUE NONCLUSTERED 
(
	[AsignaturaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UK_Carreras]    Script Date: 05/12/2020 19:50:57 ******/
ALTER TABLE [dbo].[Carreras] ADD  CONSTRAINT [UK_Carreras] UNIQUE NONCLUSTERED 
(
	[CarreraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Asignaturas_Carreras_CarreraID] FOREIGN KEY([CarreraID])
REFERENCES [dbo].[Carreras] ([CarreraID])
GO
ALTER TABLE [dbo].[Asignaturas] CHECK CONSTRAINT [FK_Asignaturas_Carreras_CarreraID]
GO
ALTER TABLE [dbo].[Asignaturas]  WITH CHECK ADD  CONSTRAINT [FK_Asignaturas_ListadoAsignaturas_ListadoAsignaturasID] FOREIGN KEY([ListadoAsignaturasID])
REFERENCES [dbo].[ListadoAsignaturas] ([ListadoAsignaturasID])
GO
ALTER TABLE [dbo].[Asignaturas] CHECK CONSTRAINT [FK_Asignaturas_ListadoAsignaturas_ListadoAsignaturasID]
GO
ALTER TABLE [dbo].[Carreras]  WITH CHECK ADD  CONSTRAINT [FK_Carreras_Alumnos_AlumnoID] FOREIGN KEY([AlumnoID])
REFERENCES [dbo].[Alumnos] ([AlumnoID])
GO
ALTER TABLE [dbo].[Carreras] CHECK CONSTRAINT [FK_Carreras_Alumnos_AlumnoID]
GO
ALTER TABLE [dbo].[Carreras]  WITH CHECK ADD  CONSTRAINT [FK_Carreras_ListadoCarreras_ListadoCarrerasID] FOREIGN KEY([ListadoCarrerasID])
REFERENCES [dbo].[ListadoCarreras] ([ListadoCarrerasID])
GO
ALTER TABLE [dbo].[Carreras] CHECK CONSTRAINT [FK_Carreras_ListadoCarreras_ListadoCarrerasID]
GO
ALTER TABLE [dbo].[ListadoAsignaturas]  WITH CHECK ADD  CONSTRAINT [FK_ListadoAsignaturas_Carrera_ListadoCarrerasID] FOREIGN KEY([ListadoCarrerasID])
REFERENCES [dbo].[ListadoCarreras] ([ListadoCarrerasID])
GO
ALTER TABLE [dbo].[ListadoAsignaturas] CHECK CONSTRAINT [FK_ListadoAsignaturas_Carrera_ListadoCarrerasID]
GO
ALTER TABLE [dbo].[ListadoCarreras]  WITH CHECK ADD  CONSTRAINT [FK_Carreras_Facultades_FacultadID] FOREIGN KEY([FacultadID])
REFERENCES [dbo].[Facultades] ([FacultadID])
GO
ALTER TABLE [dbo].[ListadoCarreras] CHECK CONSTRAINT [FK_Carreras_Facultades_FacultadID]
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD  CONSTRAINT [FK_Notas_Asignaturas_AsignaturaID] FOREIGN KEY([AsignaturaID])
REFERENCES [dbo].[Asignaturas] ([AsignaturaID])
GO
ALTER TABLE [dbo].[Notas] CHECK CONSTRAINT [FK_Notas_Asignaturas_AsignaturaID]
GO
USE [master]
GO
ALTER DATABASE [Alumnos] SET  READ_WRITE 
GO
