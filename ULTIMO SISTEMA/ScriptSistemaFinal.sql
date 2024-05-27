USE [master]
GO
/****** Object:  Database [ventas]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Categorias]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Compras]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[ComprasDetalle]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[ComprasPago]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Configuracion]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[MetodosPago]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Monedas]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Proveedores]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Stock]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[UnidadesMedidas]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[UsuariosPermisos]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[Ventas]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[VentasDetalle]    Script Date: 11/05/2023 23:25:33 ******/
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
/****** Object:  Table [dbo].[VentasPago]    Script Date: 11/05/2023 23:25:33 ******/
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

INSERT [dbo].[Categorias] ([categoriaID], [nombre], [estatus]) VALUES (1, N'Adornos', 1)
INSERT [dbo].[Categorias] ([categoriaID], [nombre], [estatus]) VALUES (2, N'Recuerdos', 1)
INSERT [dbo].[Categorias] ([categoriaID], [nombre], [estatus]) VALUES (3, N'Comuniones', 0)
INSERT [dbo].[Categorias] ([categoriaID], [nombre], [estatus]) VALUES (4, N'Costura', 1)
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (1, N'Juan', N'Soto', N'Gomez', N'Ricarte', N'25653521', N'4125865426', 1, NULL)
INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (2, N'Pedro', N'José', N'Marquina', N'Ricar', N'24896321', N'4248895471', 1, NULL)
INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (3, N'Cesar', N'Julian', N'Marquez', N'Gonzalez', N'14582456', N'416548654', 0, NULL)
INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (4, N'Victor', N'Raul', N'Raymond', N'Amaya', N'21564843', N'4248542316', 0, NULL)
INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (5, N'Victor', N'', N'Amaya', N'', N'28686889', N'4286984995', 1, NULL)
INSERT [dbo].[Clientes] ([clienteID], [primerNombre], [segundoNombre], [primerApellido], [segundoApellido], [IDFiscal], [telefono], [estatus], [Direccion]) VALUES (6, N'Juan', N'', N'Soto', N'', N'2854542', N'0', 1, NULL)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Compras] ON 

INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (1, 2, CAST(N'2023-05-11T22:50:23.017' AS DateTime), N'14154', 1, NULL, 1)
INSERT [dbo].[Compras] ([compraID], [proveedorID], [fecha], [codigofactura], [estatus], [descripcion], [usuarioID]) VALUES (2, 2, CAST(N'2023-05-11T22:54:23.583' AS DateTime), N'342423', 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[Compras] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprasDetalle] ON 

INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (10, 1, 1, CAST(5.00 AS Decimal(18, 2)))
INSERT [dbo].[ComprasDetalle] ([comprasDetalleID], [compraID], [productoID], [cantidad]) VALUES (11, 2, 3, CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ComprasDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[ComprasPago] ON 

INSERT [dbo].[ComprasPago] ([comprasPagoID], [compraID], [metodoPagoID], [monto], [monedaID], [cambio]) VALUES (5, 1, 1, CAST(220.00 AS Decimal(18, 2)), 1, CAST(3.70 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ComprasPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Configuracion] ON 

INSERT [dbo].[Configuracion] ([configuracionID], [nombreEmpresa], [telefonoEmpresa], [IDFiscalempresa], [Impuesto], [IGTF]) VALUES (2, N'Casa Fortu', N'0424889582', N'31313131', CAST(12.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Configuracion] OFF
GO
SET IDENTITY_INSERT [dbo].[MetodosPago] ON 

INSERT [dbo].[MetodosPago] ([metodoPagoID], [nombre], [estatus], [aplicaIGTF]) VALUES (1, N'Efectivo USD$', 1, 1)
INSERT [dbo].[MetodosPago] ([metodoPagoID], [nombre], [estatus], [aplicaIGTF]) VALUES (2, N'Efectivo BS', 1, 0)
INSERT [dbo].[MetodosPago] ([metodoPagoID], [nombre], [estatus], [aplicaIGTF]) VALUES (3, N'Debito', 1, 0)
INSERT [dbo].[MetodosPago] ([metodoPagoID], [nombre], [estatus], [aplicaIGTF]) VALUES (4, N'Pago movil', 0, 0)
SET IDENTITY_INSERT [dbo].[MetodosPago] OFF
GO
SET IDENTITY_INSERT [dbo].[Monedas] ON 

INSERT [dbo].[Monedas] ([monedaID], [moneda], [estatus], [esBase], [valor]) VALUES (1, N'USD', 1, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[Monedas] ([monedaID], [moneda], [estatus], [esBase], [valor]) VALUES (2, N'BS', 1, 0, CAST(25.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Monedas] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([productoID], [nombre], [descripcion], [codBarras], [fechaRegistro], [precioCompra], [precioVenta], [estatus], [unidadMedidaID], [utilidad], [categoriaID], [venderBajoCero], [nivelAlerta], [exento]) VALUES (1, N'Cinta Polly', N'Cinta para decorar', N'201030', NULL, CAST(42.00 AS Decimal(18, 2)), CAST(63.00 AS Decimal(18, 2)), 1, 2, CAST(50.00 AS Decimal(18, 2)), 1, NULL, NULL, 1)
INSERT [dbo].[Productos] ([productoID], [nombre], [descripcion], [codBarras], [fechaRegistro], [precioCompra], [precioVenta], [estatus], [unidadMedidaID], [utilidad], [categoriaID], [venderBajoCero], [nivelAlerta], [exento]) VALUES (2, N'Chenille', N'Chenille para decorar', N'102030', NULL, CAST(60.00 AS Decimal(18, 2)), CAST(78.00 AS Decimal(18, 2)), 1, 2, CAST(30.00 AS Decimal(18, 2)), 1, NULL, NULL, 0)
INSERT [dbo].[Productos] ([productoID], [nombre], [descripcion], [codBarras], [fechaRegistro], [precioCompra], [precioVenta], [estatus], [unidadMedidaID], [utilidad], [categoriaID], [venderBajoCero], [nivelAlerta], [exento]) VALUES (3, N'Aguja', N'Aguja #14', N'141526', CAST(N'2023-05-11T21:19:27.617' AS DateTime), CAST(45.00 AS Decimal(18, 2)), CAST(67.50 AS Decimal(18, 2)), 1, 3, CAST(50.00 AS Decimal(18, 2)), 4, 0, CAST(20.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([proveedorID], [empresa], [vendedor], [telefono], [direccion], [IDFiscal], [estatus]) VALUES (1, N'Todo Hilos C.A', N'Sharon', N'281456786', N'Calle #23 Barcelona', N'J-545875', 1)
INSERT [dbo].[Proveedores] ([proveedorID], [empresa], [vendedor], [telefono], [direccion], [IDFiscal], [estatus]) VALUES (2, N'Costuras C.A', N'Juan', N'4125864125', N'Avenida 5 de Julio', N'254236565', 1)
INSERT [dbo].[Proveedores] ([proveedorID], [empresa], [vendedor], [telefono], [direccion], [IDFiscal], [estatus]) VALUES (3, N'Recuerdos Import', N'Mariela', N'4245687269', N'Calle #23- Costanera', N'P-45587567', 0)
INSERT [dbo].[Proveedores] ([proveedorID], [empresa], [vendedor], [telefono], [direccion], [IDFiscal], [estatus]) VALUES (4, N'Full Import', N'Eduardo', N'4254687869', N'Calle #21 con avenida 5 de julio', N'J-58456897', 1)
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (1, 1, CAST(100.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:14:02.587' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (2, 2, CAST(50.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:15:26.850' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (3, 3, CAST(20.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:18:51.867' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (4, 1, CAST(20.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:20:37.960' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (5, 1, CAST(40.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:24:42.710' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (6, 3, CAST(4.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:24:42.757' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (7, 1, CAST(30.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:29:45.007' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (8, 3, CAST(2.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:35:18.260' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (9, 1, CAST(-19.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:39:00.120' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (10, 3, CAST(-16.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:44:40.613' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (11, 3, CAST(-16.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:45:07.410' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (12, 2, CAST(-10.00 AS Decimal(18, 2)), CAST(N'2023-05-11T21:51:03.707' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (13, 1, CAST(-1.00 AS Decimal(18, 2)), CAST(N'2023-05-11T22:52:21.250' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (14, 1, CAST(-1.00 AS Decimal(18, 2)), CAST(N'2023-05-11T22:57:01.143' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (15, 2, CAST(-1.00 AS Decimal(18, 2)), CAST(N'2023-05-11T22:58:38.357' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (16, 1, CAST(5.00 AS Decimal(18, 2)), CAST(N'2023-05-11T23:09:08.557' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (17, 1, CAST(-1.00 AS Decimal(18, 2)), CAST(N'2023-05-11T23:10:13.323' AS DateTime))
INSERT [dbo].[Stock] ([stockID], [productoID], [cantidad], [fecha]) VALUES (18, 1, CAST(-1.00 AS Decimal(18, 2)), CAST(N'2023-05-11T23:18:04.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[UnidadesMedidas] ON 

INSERT [dbo].[UnidadesMedidas] ([unidadMedidaID], [nombre], [estatus]) VALUES (1, N'DOCENA', 1)
INSERT [dbo].[UnidadesMedidas] ([unidadMedidaID], [nombre], [estatus]) VALUES (2, N'METROS', 1)
INSERT [dbo].[UnidadesMedidas] ([unidadMedidaID], [nombre], [estatus]) VALUES (3, N'UNIDAD', 1)
INSERT [dbo].[UnidadesMedidas] ([unidadMedidaID], [nombre], [estatus]) VALUES (4, N'MEDIO METRO', 1)
SET IDENTITY_INSERT [dbo].[UnidadesMedidas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([usuarioID], [usuario], [contrasena], [estatus], [esAdmin]) VALUES (1, N'admin', N'123456', 1, 1)
INSERT [dbo].[Usuarios] ([usuarioID], [usuario], [contrasena], [estatus], [esAdmin]) VALUES (2, N'AUREA', N'1234563', 1, 0)
INSERT [dbo].[Usuarios] ([usuarioID], [usuario], [contrasena], [estatus], [esAdmin]) VALUES (3, N'MARI', N'mari123', 1, 1)
INSERT [dbo].[Usuarios] ([usuarioID], [usuario], [contrasena], [estatus], [esAdmin]) VALUES (4, N'CANDY', N'1234567', 0, 0)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[UsuariosPermisos] ON 

INSERT [dbo].[UsuariosPermisos] ([UsuarioPermisoID], [usuarioID], [clientes], [proveedores], [categorias], [stock], [instrumentoPago], [unidadMedida], [configuracionGeneral], [usuarios], [productos], [listadoCompras], [nuevaCompra], [listadoVenta], [nuevaVenta], [reportes], [pestanaMantenimiento], [pestanaCompras], [pestanaVentas], [pestanaReporte], [monedas], [respaldos]) VALUES (1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[UsuariosPermisos] ([UsuarioPermisoID], [usuarioID], [clientes], [proveedores], [categorias], [stock], [instrumentoPago], [unidadMedida], [configuracionGeneral], [usuarios], [productos], [listadoCompras], [nuevaCompra], [listadoVenta], [nuevaVenta], [reportes], [pestanaMantenimiento], [pestanaCompras], [pestanaVentas], [pestanaReporte], [monedas], [respaldos]) VALUES (2, 2, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1)
INSERT [dbo].[UsuariosPermisos] ([UsuarioPermisoID], [usuarioID], [clientes], [proveedores], [categorias], [stock], [instrumentoPago], [unidadMedida], [configuracionGeneral], [usuarios], [productos], [listadoCompras], [nuevaCompra], [listadoVenta], [nuevaVenta], [reportes], [pestanaMantenimiento], [pestanaCompras], [pestanaVentas], [pestanaReporte], [monedas], [respaldos]) VALUES (3, 3, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[UsuariosPermisos] ([UsuarioPermisoID], [usuarioID], [clientes], [proveedores], [categorias], [stock], [instrumentoPago], [unidadMedida], [configuracionGeneral], [usuarios], [productos], [listadoCompras], [nuevaCompra], [listadoVenta], [nuevaVenta], [reportes], [pestanaMantenimiento], [pestanaCompras], [pestanaVentas], [pestanaReporte], [monedas], [respaldos]) VALUES (4, 4, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[UsuariosPermisos] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (1, 5, CAST(N'2023-05-11T22:52:01.607' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (2, 5, CAST(N'2023-05-11T22:56:32.847' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (3, 5, CAST(N'2023-05-11T22:58:14.653' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (4, 5, CAST(N'2023-05-11T23:10:00.517' AS DateTime), 1, NULL, 1)
INSERT [dbo].[Ventas] ([ventaID], [clienteID], [fecha], [estatus], [descripcion], [usuarioID]) VALUES (5, 5, CAST(N'2023-05-11T23:17:48.467' AS DateTime), 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
SET IDENTITY_INSERT [dbo].[VentasDetalle] ON 

INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (9, 1, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (10, 2, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (11, 3, 2, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (12, 4, 1, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasDetalle] ([ventaDetalleID], [ventaID], [productoID], [cantidad]) VALUES (13, 5, 1, CAST(1.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[VentasDetalle] OFF
GO
SET IDENTITY_INSERT [dbo].[VentasPago] ON 

INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (5, 1, CAST(65.00 AS Decimal(18, 2)), 1, 1, CAST(0.11 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (6, 2, CAST(1600.00 AS Decimal(18, 2)), 2, 2, CAST(25.00 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (7, 1, CAST(90.00 AS Decimal(18, 2)), 3, 1, CAST(0.02 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (8, 1, CAST(65.00 AS Decimal(18, 2)), 4, 1, CAST(0.11 AS Decimal(18, 2)))
INSERT [dbo].[VentasPago] ([ventaPagoID], [metodoPagoID], [monto], [ventaID], [monedaID], [cambio]) VALUES (9, 1, CAST(65.00 AS Decimal(18, 2)), 5, 1, CAST(0.11 AS Decimal(18, 2)))
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
