USE [master]
GO
/****** Object:  Database [ventas]    Script Date: 11/5/2023 10:01:37 a. m. ******/
CREATE DATABASE [ventas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ventas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ventas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ventas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ventas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ventas] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ventas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ventas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ventas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ventas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ventas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ventas] SET ARITHABORT OFF 
GO
ALTER DATABASE [ventas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ventas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ventas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ventas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ventas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ventas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ventas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ventas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ventas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ventas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ventas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ventas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ventas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ventas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ventas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ventas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ventas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ventas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ventas] SET  MULTI_USER 
GO
ALTER DATABASE [ventas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ventas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ventas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ventas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ventas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ventas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ventas] SET QUERY_STORE = ON
GO
ALTER DATABASE [ventas] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ventas]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[categoriaID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[estatus] [bit] NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[categoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[clienteID] [int] IDENTITY(1,1) NOT NULL,
	[primerNombre] [varchar](50) NULL,
	[segundoNombre] [varchar](50) NULL,
	[primerApellido] [varchar](50) NULL,
	[segundoApellido] [varchar](50) NULL,
	[IDFiscal] [varchar](20) NULL,
	[telefono] [varchar](10) NULL,
	[estatus] [bit] NULL,
	[Direccion] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[clienteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[compraID] [int] IDENTITY(1,1) NOT NULL,
	[proveedorID] [int] NULL,
	[fecha] [datetime] NULL,
	[codigofactura] [varchar](50) NULL,
	[estatus] [bit] NULL,
	[descripcion] [varchar](50) NULL,
	[usuarioID] [int] NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[compraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprasDetalle]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprasDetalle](
	[comprasDetalleID] [int] IDENTITY(1,1) NOT NULL,
	[compraID] [int] NULL,
	[productoID] [int] NULL,
	[cantidad] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ComprasDetalle] PRIMARY KEY CLUSTERED 
(
	[comprasDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComprasPago]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComprasPago](
	[comprasPagoID] [int] IDENTITY(1,1) NOT NULL,
	[compraID] [int] NULL,
	[metodoPagoID] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[monedaID] [int] NULL,
	[cambio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_ComprasPago] PRIMARY KEY CLUSTERED 
(
	[comprasPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuracion]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuracion](
	[configuracionID] [int] IDENTITY(1,1) NOT NULL,
	[nombreEmpresa] [varchar](50) NULL,
	[telefonoEmpresa] [varchar](50) NULL,
	[IDFiscalempresa] [varchar](50) NULL,
	[Impuesto] [decimal](18, 2) NULL,
	[IGTF] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Configuracion] PRIMARY KEY CLUSTERED 
(
	[configuracionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetodosPago]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetodosPago](
	[metodoPagoID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[estatus] [bit] NULL,
	[aplicaIGTF] [bit] NULL,
 CONSTRAINT [PK_MetodosPago] PRIMARY KEY CLUSTERED 
(
	[metodoPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Monedas]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Monedas](
	[monedaID] [int] IDENTITY(1,1) NOT NULL,
	[moneda] [varchar](50) NULL,
	[estatus] [bit] NULL,
	[esBase] [bit] NULL,
	[valor] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED 
(
	[monedaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[productoID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[descripcion] [varchar](150) NULL,
	[codBarras] [varchar](50) NULL,
	[fechaRegistro] [datetime] NULL,
	[precioCompra] [decimal](18, 2) NULL,
	[precioVenta] [decimal](18, 2) NULL,
	[estatus] [bit] NULL,
	[unidadMedidaID] [int] NULL,
	[utilidad] [decimal](18, 2) NULL,
	[categoriaID] [int] NULL,
	[venderBajoCero] [bit] NULL,
	[nivelAlerta] [decimal](18, 2) NULL,
	[exento] [bit] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[productoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[proveedorID] [int] IDENTITY(1,1) NOT NULL,
	[empresa] [varchar](50) NULL,
	[vendedor] [varchar](50) NULL,
	[telefono] [varchar](10) NULL,
	[direccion] [varchar](100) NULL,
	[IDFiscal] [varchar](20) NULL,
	[estatus] [bit] NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[proveedorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[stockID] [int] IDENTITY(1,1) NOT NULL,
	[productoID] [int] NULL,
	[cantidad] [decimal](18, 2) NULL,
	[fecha] [datetime] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[stockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadesMedidas]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadesMedidas](
	[unidadMedidaID] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[estatus] [bit] NULL,
 CONSTRAINT [PK_UnidadesMedidas] PRIMARY KEY CLUSTERED 
(
	[unidadMedidaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[usuarioID] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[contrasena] [varchar](50) NULL,
	[estatus] [bit] NULL,
	[esAdmin] [bit] NULL,
 CONSTRAINT [PK_Usuarios_1] PRIMARY KEY CLUSTERED 
(
	[usuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosPermisos]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosPermisos](
	[UsuarioPermisoID] [int] IDENTITY(1,1) NOT NULL,
	[usuarioID] [int] NULL,
	[clientes] [bit] NULL,
	[proveedores] [bit] NULL,
	[categorias] [bit] NULL,
	[stock] [bit] NULL,
	[instrumentoPago] [bit] NULL,
	[unidadMedida] [bit] NULL,
	[configuracionGeneral] [bit] NULL,
	[usuarios] [bit] NULL,
	[productos] [bit] NULL,
	[listadoCompras] [bit] NULL,
	[nuevaCompra] [bit] NULL,
	[listadoVenta] [bit] NULL,
	[nuevaVenta] [bit] NULL,
	[reportes] [bit] NULL,
	[pestanaMantenimiento] [bit] NULL,
	[pestanaCompras] [bit] NULL,
	[pestanaVentas] [bit] NULL,
	[pestanaReporte] [bit] NULL,
	[monedas] [bit] NULL,
	[respaldos] [bit] NULL,
 CONSTRAINT [PK_UsuariosPermisos] PRIMARY KEY CLUSTERED 
(
	[UsuarioPermisoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[ventaID] [int] IDENTITY(1,1) NOT NULL,
	[clienteID] [int] NULL,
	[fecha] [datetime] NULL,
	[estatus] [bit] NULL,
	[descripcion] [varchar](50) NULL,
	[usuarioID] [int] NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[ventaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentasDetalle](
	[ventaDetalleID] [int] IDENTITY(1,1) NOT NULL,
	[ventaID] [int] NULL,
	[productoID] [int] NULL,
	[cantidad] [decimal](18, 2) NULL,
 CONSTRAINT [PK_VentasDetalle] PRIMARY KEY CLUSTERED 
(
	[ventaDetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentasPago]    Script Date: 11/5/2023 10:01:37 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentasPago](
	[ventaPagoID] [int] IDENTITY(1,1) NOT NULL,
	[metodoPagoID] [int] NULL,
	[monto] [decimal](18, 2) NULL,
	[ventaID] [int] NULL,
	[monedaID] [int] NULL,
	[cambio] [decimal](18, 2) NULL,
 CONSTRAINT [PK_VentasPago] PRIMARY KEY CLUSTERED 
(
	[ventaPagoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([categoriaID], [nombre], [estatus]) VALUES (1, N'Costura', 1)
INSERT [dbo].[Categorias] ([categoriaID], [nombre], [estatus]) VALUES (2, N'Decoraciones', 1)
INSERT [dbo].[Categorias] ([categoriaID], [nombre], [estatus]) VALUES (3, N'Recuerdos', 1)
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (3, N'Victor', N'', N'Raymond', N'', N'28686889', N'4248844545', 1, NULL)
INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (4, N'Juan', N'pedro', N'Soto', N'luc', N'25648545', N'5454545554', 1, NULL)
INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (1002, N'Juan', N'', N'Carlos', N'', N'25868487', N'4248896983', 1, NULL)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Compras] ON 

INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1005, 2, CAST(N'2023-05-07T00:00:00.000' AS DateTime), N'2131', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1006, 1, CAST(N'2023-05-10T14:43:07.240' AS DateTime), N'3465465', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1007, 1, CAST(N'2023-05-10T00:00:00.000' AS DateTime), N'3534534', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1008, 2, CAST(N'2023-05-10T14:59:55.260' AS DateTime), N'5464565', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1009, 1, CAST(N'2023-05-10T15:01:05.943' AS DateTime), N'54567567', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1010, 2, CAST(N'2023-05-10T15:14:06.827' AS DateTime), N'346546', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1011, 1, CAST(N'2023-05-10T15:15:09.413' AS DateTime), N'545', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1012, 2, CAST(N'2023-05-10T15:25:47.190' AS DateTime), N'5445', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1013, 1, CAST(N'2023-05-10T00:00:00.000' AS DateTime), N'34545', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1014, 1, CAST(N'2023-05-10T15:50:22.303' AS DateTime), N'45', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1015, 2, CAST(N'2023-05-10T15:53:40.850' AS DateTime), N'56546456', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1016, 2, CAST(N'2023-05-10T15:55:51.317' AS DateTime), N'34344344', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1017, 1, CAST(N'2023-05-10T15:57:10.240' AS DateTime), N'234234543545', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1018, 2, CAST(N'2023-05-10T16:07:34.587' AS DateTime), N'354345345', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1019, 2, CAST(N'2023-05-10T16:09:12.310' AS DateTime), N'456546546', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1020, 1, CAST(N'2023-05-10T16:11:57.697' AS DateTime), N'435345', 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Compras] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprasDetalle] ON 

INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1005, 1005, 2, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1006, 1006, 1, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1007, 1007, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1008, 1008, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1009, 1009, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1010, 1010, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1011, 1011, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1012, 1012, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1013, 1013, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1014, 1014, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1015, 1015, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1016, 1015, 1, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1017, 1016, 1, CAST(3.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1018, 1017, 1, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1019, 1018, 1, CAST(12.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1020, 1019, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (1021, 1020, 1, CAST(1.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ComprasDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprasPago] ON 

INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (7, 1005, 1, CAST(244.00 AS Decimal(18, 2)), 1, CAST(190.44 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (8, 1006, 2, CAST(150.00 AS Decimal(18, 2)), 1, CAST(49.20 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (9, 1007, 1, CAST(52.00 AS Decimal(18, 2)), 1, CAST(0.09 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (10, 1008, 2, CAST(60.00 AS Decimal(18, 2)), 1, CAST(9.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (11, 1009, 2, CAST(51.00 AS Decimal(18, 2)), 1, CAST(0.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (12, 1010, 2, CAST(51.00 AS Decimal(18, 2)), 1, CAST(0.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (13, 1011, 3, CAST(51.00 AS Decimal(18, 2)), 1, CAST(0.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (14, 1011, 2, CAST(56.00 AS Decimal(18, 2)), 1, CAST(5.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (15, 1012, 2, CAST(60.00 AS Decimal(18, 2)), 1, CAST(9.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (16, 1013, 2, CAST(51.00 AS Decimal(18, 2)), 1, CAST(0.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (17, 1014, 3, CAST(52.00 AS Decimal(18, 2)), 1, CAST(1.60 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (18, 1015, 2, CAST(152.00 AS Decimal(18, 2)), 1, CAST(0.80 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (19, 1016, 1, CAST(153.00 AS Decimal(18, 2)), 1, CAST(1.80 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (20, 1017, 1, CAST(520.00 AS Decimal(18, 2)), 1, CAST(0.88 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (21, 1018, 1, CAST(625.00 AS Decimal(18, 2)), 1, CAST(2.06 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (22, 1019, 1, CAST(52.00 AS Decimal(18, 2)), 1, CAST(0.09 AS Decimal(18, 2)))
INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (23, 1020, 1, CAST(52.00 AS Decimal(18, 2)), 1, CAST(0.09 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ComprasPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Configuracion] ON 

INSERT [dbo].[Configuracion] ([configuracionID], [nombreEmpresa], [telefonoEmpresa], [IDFiscalempresa], [Impuesto], [IGTF]) VALUES (1, N'Mercería Casa Fortu 18 C.A.', N'0281-2655526', N'J-297489732-2', CAST(12.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Configuracion] OFF
GO
SET IDENTITY_INSERT [dbo].[MetodosPago] ON 

INSERT [dbo].[MetodosPago] ([metodoPagoID], [nombre], [estatus], [aplicaIGTF]) VALUES (1, N'Efectivo $', 1, 1)
INSERT [dbo].[MetodosPago] ([metodoPagoID], [nombre], [estatus], [aplicaIGTF]) VALUES (2, N'Efectivo BS', 1, 0)
INSERT [dbo].[MetodosPago] ([metodoPagoID], [nombre], [estatus], [aplicaIGTF]) VALUES (3, N'Debito', 1, 0)
SET IDENTITY_INSERT [dbo].[MetodosPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Monedas] ON 

INSERT [dbo].[Monedas] ([monedaID], [moneda], [estatus], [esBase], [valor]) VALUES (1, N'USD', 1, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Monedas] ([monedaID], [moneda], [estatus], [esBase], [valor]) VALUES (2, N'BS', 1, 0, CAST(25.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Monedas] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([productoID], [nombre], [descripcion], [codBarras], [fechaRegistro], [precioCompra], [precioVenta], [estatus], [unidadMedidaID], [utilidad], [categoriaID], [venderBajoCero], [nivelAlerta], [exento]) VALUES (1, N'Cinta Polly', N'Cinta polly Negra', N'25464565', CAST(N'2023-05-03T20:07:41.543' AS DateTime), CAST(45.00 AS Decimal(18, 2)), CAST(50.40 AS Decimal(18, 2)), 1, 1, CAST(12.00 AS Decimal(18, 2)), 2, 1, CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Productos] ([productoID], [nombre], [descripcion], [codBarras], [fechaRegistro], [precioCompra], [precioVenta], [estatus], [unidadMedidaID], [utilidad], [categoriaID], [venderBajoCero], [nivelAlerta], [exento]) VALUES (2, N'Cinta Raso', N'Cinta Raso #4', N'54454', CAST(N'2023-05-10T19:36:38.157' AS DateTime), CAST(52.00 AS Decimal(18, 2)), CAST(62.92 AS Decimal(18, 2)), 1, 1, CAST(21.00 AS Decimal(18, 2)), 2, 1, CAST(20.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Productos] ([productoID], [nombre], [descripcion], [codBarras], [fechaRegistro], [precioCompra], [precioVenta], [estatus], [unidadMedidaID], [utilidad], [categoriaID], [venderBajoCero], [nivelAlerta], [exento]) VALUES (3, N'Aguja Doble', N'n/a', N'454256', CAST(N'2023-05-09T21:40:36.630' AS DateTime), CAST(52.00 AS Decimal(18, 2)), CAST(72.80 AS Decimal(18, 2)), 1, 2, CAST(40.00 AS Decimal(18, 2)), 1, 0, CAST(1.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([proveedorID], [empresa], [vendedor], [telefono], [direccion], [IDFiscal], [estatus]) VALUES (1, N'Todo Hilo CA', N'Julian', N'424889683', N'Calle #43', N'25686556', 1)
INSERT [dbo].[Proveedores] ([proveedorID], [empresa], [vendedor], [telefono], [direccion], [IDFiscal], [estatus]) VALUES (2, N'Costuras C.A', N'Ricardo', N'4248896845', N'Calle #41', N'245456656', 1)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1, 1, CAST(50.00 AS Decimal(18, 2)), CAST(N'2023-05-03T19:43:09.820' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (2, 2, CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-05-03T19:44:31.633' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (3, 3, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-03T19:45:56.087' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (4, 2, CAST(-1.00 AS Decimal(18, 2)), CAST(N'2023-05-03T19:52:20.777' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (5, 1, CAST(52.00 AS Decimal(18, 2)), CAST(N'2023-05-03T21:22:39.867' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (6, 1, CAST(-4.00 AS Decimal(18, 2)), CAST(N'2023-05-06T08:44:10.173' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1002, 1, CAST(5.00 AS Decimal(18, 2)), CAST(N'2023-05-07T20:47:43.323' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1003, 2, CAST(8.00 AS Decimal(18, 2)), CAST(N'2023-05-07T20:47:59.180' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1004, 1, CAST(5.00 AS Decimal(18, 2)), CAST(N'2023-05-07T22:14:58.843' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1005, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-07T22:16:55.980' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1006, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-07T22:20:05.623' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1007, 2, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-07T22:22:11.000' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1008, 2, CAST(-18.00 AS Decimal(18, 2)), CAST(N'2023-05-09T21:38:47.727' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1009, 1, CAST(2.00 AS Decimal(18, 2)), CAST(N'2023-05-10T14:43:28.330' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1010, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T14:50:31.257' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1011, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:00:36.860' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1012, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:11:44.513' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1013, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:14:32.200' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1014, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:18:54.583' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1015, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:20:59.810' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1016, 2, CAST(-4.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:24:15.333' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1017, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:26:16.637' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1018, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:49:58.387' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1019, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:51:10.203' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1020, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:54:35.637' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1021, 1, CAST(2.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:54:35.707' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1022, 1, CAST(3.00 AS Decimal(18, 2)), CAST(N'2023-05-10T15:56:34.653' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1023, 1, CAST(10.00 AS Decimal(18, 2)), CAST(N'2023-05-10T16:00:30.413' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1024, 1, CAST(12.00 AS Decimal(18, 2)), CAST(N'2023-05-10T16:08:19.617' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1025, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T16:09:52.930' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1026, 1, CAST(1.00 AS Decimal(18, 2)), CAST(N'2023-05-10T16:12:38.537' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1027, 1, CAST(-10.00 AS Decimal(18, 2)), CAST(N'2023-05-10T16:18:01.483' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[UnidadesMedidas] ON 

INSERT [dbo].[UnidadesMedidas] ([unidadMedidaID], [nombre], [estatus]) VALUES (1, N'METROS', 1)
INSERT [dbo].[UnidadesMedidas] ([unidadMedidaID], [nombre], [estatus]) VALUES (2, N'UNIDAD', 1)
INSERT [dbo].[UnidadesMedidas] ([unidadMedidaID], [nombre], [estatus]) VALUES (3, N'DOCENA', 1)
SET IDENTITY_INSERT [dbo].[UnidadesMedidas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([usuarioID], [usuario], [contrasena], [estatus], [esAdmin]) VALUES (1, N'admin', N'123456', 1, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuariosPermisos] ON 

INSERT [dbo].[UsuariosPermisos] ([UsuarioPermisoID], [usuarioID], [clientes], [proveedores], [categorias], [stock], [instrumentoPago], [unidadMedida], [configuracionGeneral], [usuarios], [productos], [listadoCompras], [nuevaCompra], [listadoVenta], [nuevaVenta], [reportes], [pestanaMantenimiento], [pestanaCompras], [pestanaVentas], [pestanaReporte], [monedas], [respaldos]) VALUES (1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[UsuariosPermisos] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (1, 3, CAST(N'2023-05-03T19:49:20.543' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (2, 3, CAST(N'2023-05-03T20:00:49.570' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (3, 3, CAST(N'2023-05-03T20:08:45.830' AS DateTime), 0, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (4, 4, CAST(N'2023-05-03T20:18:22.863' AS DateTime), 0, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (5, 3, CAST(N'2023-05-03T20:31:48.960' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (6, 3, CAST(N'2023-05-06T08:40:56.833' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (1002, 1002, CAST(N'2023-05-09T21:38:15.437' AS DateTime), 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
SET IDENTITY_INSERT [dbo].[VentasDetalle] ON 

INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (1, 1, 2, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (2, 2, 1, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (3, 3, 1, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (4, 4, 1, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (5, 5, 1, CAST(10.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (6, 6, 2, CAST(4.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (1002, 1002, 2, CAST(18.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[VentasDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[VentasPago] ON 

INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (1, 1, CAST(65.00 AS Decimal(18, 2)), 1, 1, CAST(0.19 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (2, 1, CAST(226.00 AS Decimal(18, 2)), 2, 1, CAST(0.21 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (1002, 1, CAST(2000.00 AS Decimal(18, 2)), 1002, 1, CAST(833.46 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (1003, 1, CAST(252.00 AS Decimal(18, 2)), 6, 1, CAST(0.32 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (1004, 1, CAST(565.00 AS Decimal(18, 2)), 5, 1, CAST(0.52 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[VentasPago] OFF
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Proveedores] FOREIGN KEY([proveedorID])
REFERENCES [dbo].[Proveedores] ([proveedorID])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Proveedores]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Usuarios] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuarios] ([usuarioID])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Usuarios]
GO
ALTER TABLE [dbo].[ComprasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDetalle_Compras] FOREIGN KEY([compraID])
REFERENCES [dbo].[Compras] ([compraID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComprasDetalle] CHECK CONSTRAINT [FK_ComprasDetalle_Compras]
GO
ALTER TABLE [dbo].[ComprasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ComprasDetalle_Productos] FOREIGN KEY([productoID])
REFERENCES [dbo].[Productos] ([productoID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComprasDetalle] CHECK CONSTRAINT [FK_ComprasDetalle_Productos]
GO
ALTER TABLE [dbo].[ComprasPago]  WITH CHECK ADD  CONSTRAINT [FK_ComprasPago_Compras] FOREIGN KEY([compraID])
REFERENCES [dbo].[Compras] ([compraID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ComprasPago] CHECK CONSTRAINT [FK_ComprasPago_Compras]
GO
ALTER TABLE [dbo].[ComprasPago]  WITH CHECK ADD  CONSTRAINT [FK_ComprasPago_MetodosPago] FOREIGN KEY([metodoPagoID])
REFERENCES [dbo].[MetodosPago] ([metodoPagoID])
GO
ALTER TABLE [dbo].[ComprasPago] CHECK CONSTRAINT [FK_ComprasPago_MetodosPago]
GO
ALTER TABLE [dbo].[ComprasPago]  WITH CHECK ADD  CONSTRAINT [FK_ComprasPago_Monedas] FOREIGN KEY([monedaID])
REFERENCES [dbo].[Monedas] ([monedaID])
GO
ALTER TABLE [dbo].[ComprasPago] CHECK CONSTRAINT [FK_ComprasPago_Monedas]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_Categorias] FOREIGN KEY([categoriaID])
REFERENCES [dbo].[Categorias] ([categoriaID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_Categorias]
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_UnidadesMedidas] FOREIGN KEY([unidadMedidaID])
REFERENCES [dbo].[UnidadesMedidas] ([unidadMedidaID])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_UnidadesMedidas]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Productos] FOREIGN KEY([productoID])
REFERENCES [dbo].[Productos] ([productoID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Productos]
GO
ALTER TABLE [dbo].[UsuariosPermisos]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosPermisos_Usuarios] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuarios] ([usuarioID])
GO
ALTER TABLE [dbo].[UsuariosPermisos] CHECK CONSTRAINT [FK_UsuariosPermisos_Usuarios]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Clientes] FOREIGN KEY([clienteID])
REFERENCES [dbo].[Clientes] ([clienteID])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Clientes]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_Ventas_Usuarios] FOREIGN KEY([usuarioID])
REFERENCES [dbo].[Usuarios] ([usuarioID])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_Ventas_Usuarios]
GO
ALTER TABLE [dbo].[VentasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentasDetalle_Productos] FOREIGN KEY([productoID])
REFERENCES [dbo].[Productos] ([productoID])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[VentasDetalle] CHECK CONSTRAINT [FK_VentasDetalle_Productos]
GO
ALTER TABLE [dbo].[VentasDetalle]  WITH CHECK ADD  CONSTRAINT [FK_VentasDetalle_Ventas] FOREIGN KEY([ventaID])
REFERENCES [dbo].[Ventas] ([ventaID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentasDetalle] CHECK CONSTRAINT [FK_VentasDetalle_Ventas]
GO
ALTER TABLE [dbo].[VentasPago]  WITH CHECK ADD  CONSTRAINT [FK_VentasPago_MetodosPago] FOREIGN KEY([metodoPagoID])
REFERENCES [dbo].[MetodosPago] ([metodoPagoID])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[VentasPago] CHECK CONSTRAINT [FK_VentasPago_MetodosPago]
GO
ALTER TABLE [dbo].[VentasPago]  WITH CHECK ADD  CONSTRAINT [FK_VentasPago_Monedas] FOREIGN KEY([monedaID])
REFERENCES [dbo].[Monedas] ([monedaID])
GO
ALTER TABLE [dbo].[VentasPago] CHECK CONSTRAINT [FK_VentasPago_Monedas]
GO
ALTER TABLE [dbo].[VentasPago]  WITH CHECK ADD  CONSTRAINT [FK_VentasPago_Ventas] FOREIGN KEY([ventaID])
REFERENCES [dbo].[Ventas] ([ventaID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VentasPago] CHECK CONSTRAINT [FK_VentasPago_Ventas]
GO
USE [master]
GO
ALTER DATABASE [ventas] SET  READ_WRITE 
GO
