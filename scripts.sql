USE [PapeleriaBDDM3C]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 16/05/2024 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Codigo] [bigint] NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[stock] [int] NOT NULL,
	[PrecioUnitario] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 16/05/2024 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rut] [nvarchar](max) NOT NULL,
	[RazonSocial] [nvarchar](max) NOT NULL,
	[Direccion_Calle] [nvarchar](max) NOT NULL,
	[Direccion_Numero] [int] NOT NULL,
	[Direccion_Ciudad] [nvarchar](max) NOT NULL,
	[Direccion_DistanciaDesdeTienda] [decimal](18, 2) NOT NULL,
	[NombreCompleto_Apellido] [nvarchar](max) NOT NULL,
	[NombreCompleto_Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 16/05/2024 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Recargo] [decimal](18, 2) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[PrecioTotal] [decimal](18, 2) NOT NULL,
	[FechaEntrega] [datetime2](7) NOT NULL,
	[IVA] [decimal](18, 2) NOT NULL,
	[anulado] [bit] NOT NULL,
 CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/05/2024 12:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[ClaveSinEncriptar] [nvarchar](max) NOT NULL,
	[NombreCompleto_Apellido] [nvarchar](max) NOT NULL,
	[NombreCompleto_Nombre] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articulos] ON 

INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (4, N'Monitor Gamer', 1234567891234, N'Un buen monitor', 113, CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (7, N'zapato incomodo', 6543217654321, N'zapatito incomodo', 151, CAST(1500.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (19, N'Cuaderno de Espiral', 1234567890123, N'Cuaderno de 100 hojas', 88, CAST(148.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (20, N'Pluma Azul', 2345678901234, N'Bolígrafo de tinta azul', 198, CAST(53.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (21, N'Carpeta de Archivo', 3456789012345, N'Carpeta de plástico para documentos', 41, CAST(99.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (23, N'Resaltador Amarillo', 5678901234567, N'Resaltador fluorescente color amarillo', 150, CAST(78.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (24, N'Pegamento en Barra', 6789012345678, N'Pegamento adhesivo en formato de barra', 73, CAST(32.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (25, N'Libreta de Notas', 7890123456789, N'Libreta de 50 hojas rayadas', 120, CAST(120.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (26, N'Corrector Líquido', 8901234567890, N'Corrector líquido de punta fina', 70, CAST(64.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (27, N'Goma de Borrar', 9012345678901, N'Goma de borrar de vinilo', 212, CAST(11.00 AS Decimal(18, 2)))
INSERT [dbo].[Articulos] ([Id], [Nombre], [Codigo], [Descripcion], [stock], [PrecioUnitario]) VALUES (28, N'Tijeras Escolares', 123456789012, N'Tijeras escolares de punta roma', 90, CAST(42.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Articulos] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (1, N'123456789111', N'Razon', N'Munar', 12, N'Canelones', CAST(12.00 AS Decimal(18, 2)), N'Diaz', N'Martin')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (8, N'123456789012', N'Papelería García Ltda.', N'Avenida Libertador Bernardo O''Higgins', 1234, N'Santiago', CAST(5.60 AS Decimal(18, 2)), N'García', N'Pedro')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (9, N'234567890123', N'Librería Martínez EIRL', N'Calle San Diego', 567, N'Valparaíso', CAST(12.30 AS Decimal(18, 2)), N'Martínez', N'María')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (10, N'345678901234', N'Papelería El Universitario SPA', N'Avenida Matta', 987, N'Concepción', CAST(8.90 AS Decimal(18, 2)), N'López', N'Juan')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (11, N'456789012345', N'Librería La Esquina del Saber Ltda.', N'Calle Maipú', 432, N'Puerto Montt', CAST(15.20 AS Decimal(18, 2)), N'González', N'Ana')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (12, N'567890123456', N'Papelería y Librería Los Ángeles', N'Avenida 18 de Septiembre', 654, N'Los Ángeles', CAST(20.50 AS Decimal(18, 2)), N'Hernández', N'Luis')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (13, N'678901234567', N'Librería El Rincón Literario EIRL', N'Calle Prat', 876, N'La Serena', CAST(9.80 AS Decimal(18, 2)), N'Torres', N'Carolina')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (14, N'789012345678', N'Papelería y Librería San Pedro SPA', N'Calle Colón', 321, N'Arica', CAST(3.20 AS Decimal(18, 2)), N'Díaz', N'Javier')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (15, N'890123456789', N'Librería El Dorado EIRL', N'Avenida Argentina', 765, N'Temuco', CAST(10.10 AS Decimal(18, 2)), N'Rodríguez', N'Marcela')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (16, N'901234567890', N'Papelería La Pluma Dorada Ltda.', N'Calle Merced', 543, N'Antofagasta', CAST(6.70 AS Decimal(18, 2)), N'Fernández', N'Diego')
INSERT [dbo].[Clientes] ([Id], [Rut], [RazonSocial], [Direccion_Calle], [Direccion_Numero], [Direccion_Ciudad], [Direccion_DistanciaDesdeTienda], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (17, N'012345678901', N'Librería La Fuente de Sabiduría SPA', N'Avenida Los Carrera', 987, N'Rancagua', CAST(12.90 AS Decimal(18, 2)), N'Gómez', N'Laura')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedidos] ON 

INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (41, CAST(0.05 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 17, CAST(362.34 AS Decimal(18, 2)), CAST(N'2024-05-31T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (42, CAST(0.15 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 1, CAST(74.36 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (43, CAST(0.10 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 8, CAST(810.57 AS Decimal(18, 2)), CAST(N'2024-05-18T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (44, CAST(0.05 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 11, CAST(514.84 AS Decimal(18, 2)), CAST(N'2024-06-13T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (45, CAST(0.05 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 13, CAST(483.12 AS Decimal(18, 2)), CAST(N'2024-05-31T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (46, CAST(0.15 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 10, CAST(353.56 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (47, CAST(0.10 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 9, CAST(858.88 AS Decimal(18, 2)), CAST(N'2024-05-17T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (48, CAST(0.05 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 9, CAST(902.80 AS Decimal(18, 2)), CAST(N'2024-05-20T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (49, CAST(0.15 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 8, CAST(134.69 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Pedidos] ([Id], [Recargo], [Fecha], [ClienteId], [PrecioTotal], [FechaEntrega], [IVA], [anulado]) VALUES (50, CAST(0.10 AS Decimal(18, 2)), CAST(N'2024-05-16T00:00:00.0000000' AS DateTime2), 16, CAST(1752.65 AS Decimal(18, 2)), CAST(N'2024-05-17T00:00:00.0000000' AS DateTime2), CAST(22.00 AS Decimal(18, 2)), 0)
SET IDENTITY_INSERT [dbo].[Pedidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Email], [Clave], [ClaveSinEncriptar], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (3, N'martin@gmail.com', N'kZHqdm//aU5OrjFg+zkfUbd9NAU/bvXVDdeZQ+Q2HgE=', N'HolaComoEstas-4123H', N'diaz', N'M artin')
INSERT [dbo].[Usuarios] ([Id], [Email], [Clave], [ClaveSinEncriptar], [NombreCompleto_Apellido], [NombreCompleto_Nombre]) VALUES (7, N'santiago@gmail.com', N'/NskhXCJV3odrPb56Em2cw==', N'LaClave12-3', N'Pintos', N'Santiago')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (N'') FOR [NombreCompleto_Apellido]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT (N'') FOR [NombreCompleto_Nombre]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaEntrega]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT ((0.0)) FOR [IVA]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT (CONVERT([bit],(0))) FOR [anulado]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (N'') FOR [NombreCompleto_Apellido]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (N'') FOR [NombreCompleto_Nombre]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD  CONSTRAINT [FK_Pedidos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pedidos] CHECK CONSTRAINT [FK_Pedidos_Clientes_ClienteId]
GO
