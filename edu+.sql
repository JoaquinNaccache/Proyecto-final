USE [edu+]
GO
/****** Object:  User [alumno]    Script Date: 14/6/2024 09:37:20 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 14/6/2024 09:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[idAdministrador] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[idAdministrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 14/6/2024 09:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 14/6/2024 09:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[nombreCurso] [varchar](max) NOT NULL,
	[descripcion] [varchar](max) NOT NULL,
	[temario] [varchar](max) NOT NULL,
	[precio] [int] NOT NULL,
	[imagen] [varchar](max) NULL,
	[idProfesor] [int] NULL,
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 14/6/2024 09:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[idProfesor] [int] IDENTITY(1,1) NOT NULL,
	[nombreProfesor] [varchar](50) NOT NULL,
	[contenido] [varchar](50) NOT NULL,
	[informacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Profesores] PRIMARY KEY CLUSTERED 
(
	[idProfesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 14/6/2024 09:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[contrasena] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Cursos]    Script Date: 14/6/2024 09:37:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Cursos](
	[idUsuario] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
	[valoracion] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_Cursos] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC,
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cursos] ON 

INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (1, N'Creacion de curriculum', N'Chat GPT', N'Clase 1: Introducción y Preparación

¿Qué es un currículum vitae?
Importancia del CV en la búsqueda de empleo
Componentes esenciales del CV
Autoconocimiento: Identificación de habilidades y logros
Clase 2: Estructura y Redacción Básica

Secciones del CV: Datos personales, objetivo profesional, experiencia laboral, educación, habilidades
Orden y jerarquía de la información
Redacción de experiencia laboral y logros con verbos de acción
Ejemplos y prácticas
Semana 2: Diseño y Personalización
Clase 3: Diseño y Formato del CV

Principios básicos de diseño gráfico
Tipografía y colores
Uso de plantillas y herramientas de diseño (Canva, Google Docs)
Ejemplos de CV bien diseñados
Clase 4: Personalización y Revisión Final

Adaptación del CV a oportunidades específicas
Investigación de la empresa y el puesto
Revisión y autoevaluación del CV
Práctica de revisión en pares
Consejos finales y recursos adicionales', 5000, NULL, 3)
INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (2, N'Leer una factura', N'Aca vas a aprender lo que es una factura', N'Parte 1: Introducción y Componentes de una Factura (1 hora)

¿Qué es una factura?
Definición y propósito
Tipos de facturas (comercial, proforma, electrónica)
Componentes Esenciales de una Factura
Datos del emisor y receptor
Número de factura y fecha de emisión
Descripción de productos o servicios
Cantidad, precio unitario y total
Impuestos aplicables (IVA, otros)
Condiciones de pago', 4500, NULL, 4)
INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (9, N'Educacion Financiera', N'Educacion financiera', N'Semana 1: Fundamentos y Presupuesto
Clase 1: Introducción a la Educación Financiera

Importancia de la educación financiera
Conceptos básicos: ingresos, gastos, ahorro, inversión
Clase 2: Elaboración de un Presupuesto Personal

¿Qué es un presupuesto?
Componentes de un presupuesto: ingresos, gastos fijos y variables
Cómo crear y mantener un presupuesto
Semana 2: Ahorro, Inversión y Crédito
Clase 3: Estrategias de Ahorro e Introducción a la Inversión

La importancia del ahorro
Técnicas para ahorrar dinero
Fundamentos de la inversión
Tipos de inversiones básicas: acciones, bonos
Clase 4: Manejo de Deudas y Uso del Crédito

Tipos de deudas: buenas y malas
Estrategias para pagar deudas
Uso responsable del crédito
Cómo construir y mantener un buen historial crediticio', 6000, NULL, 5)
INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (11, N'Crypto', N'La moneda crypto', N'Clase 1: Fundamentos de las Criptomonedas

¿Qué son las criptomonedas?
Historia y evolución de las criptomonedas
Principales criptomonedas: Bitcoin, Ethereum, y otras altcoins
Cómo funcionan las criptomonedas (tecnología blockchain)
Clase 2: Cómo Comprar y Almacenar Criptomonedas

Métodos para adquirir criptomonedas: exchanges, P2P
Tipos de wallets: hot wallets vs. cold wallets
Seguridad en el almacenamiento de criptomonedas
Cómo realizar transacciones con criptomonedas
Semana 2: Inversión y Seguridad en Criptomonedas
Clase 3: Inversión en Criptomonedas

Estrategias básicas de inversión en criptomonedas
Análisis fundamental vs. análisis técnico
Riesgos y beneficios de invertir en criptomonedas
Diversificación del portafolio de criptomonedas
Clase 4: Regulaciones y Seguridad en el Mundo Cripto

Marco regulatorio de las criptomonedas en diferentes países
Riesgos asociados a las criptomonedas: fraudes, hackeos
Buenas prácticas para asegurar tus inversiones
Futuro de las criptomonedas y su impacto en la economía global
', 8000, NULL, 6)
INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (13, N'Cuenta Bancaria', N'Como abrir una cuenta bancaria', N'Clase 1: Cómo Abrir una Cuenta Bancaria

Tipos de cuentas bancarias: cuentas de ahorro, cuentas corrientes
Documentación necesaria para abrir una cuenta
Procedimiento paso a paso para abrir una cuenta bancaria
Consideraciones al elegir un banco: tarifas, ubicaciones, servicios en línea
Clase 2: Utilidad y Funcionamiento de una Cuenta Bancaria

Beneficios de tener una cuenta bancaria
Seguridad para el dinero
Facilidad de realizar pagos y recibir depósitos
Acceso a otros servicios financieros
Cómo usar una cuenta bancaria
Depositar y retirar dinero
Transferencias y pagos electrónicos
Uso de tarjetas de débito y cheques
Gestión y monitoreo de la cuenta bancaria
Estados de cuenta
Herramientas de banca en línea y móvil
Cómo evitar cargos y comisiones
', 10000, NULL, 7)
INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (14, N'Oferta y demanda', N'Como funciona la oferta y la demanda', N'Clase 1: Introducción a la Oferta y la Demanda

Concepto de demanda
Determinantes de la demanda: precio, ingreso, gustos y preferencias, precios de bienes relacionados, expectativas
La curva de demanda: representación gráfica y desplazamientos
Concepto de oferta
Determinantes de la oferta: precio, costos de producción, tecnología, precios de bienes relacionados, expectativas
La curva de oferta: representación gráfica y desplazamientos
Clase 2: Equilibrio del Mercado y Cambios en el Equilibrio

Equilibrio del mercado
Punto de equilibrio: intersección de la curva de oferta y demanda
Cómo se determina el precio de equilibrio y la cantidad de equilibrio
Cambios en el equilibrio del mercado
Efectos de los desplazamientos en la curva de oferta y demanda
Análisis de casos: cómo factores externos afectan el equilibrio del mercado (e.g., políticas gubernamentales, cambios tecnológicos)
Aplicaciones prácticas
Ejemplos reales de cambios en oferta y demanda en diferentes mercados', 7000, NULL, 8)
INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (15, N'Mercado laboral', N'Que es el mercado laboral', N'Clase 1: Conceptos Fundamentales del Mercado Laboral

Definición y componentes del mercado laboral
Oferta de trabajo
Demanda de trabajo
Factores que influyen en la oferta y demanda de trabajo
Educación y habilidades
Condiciones económicas
Políticas gubernamentales
Tipos de empleo
Empleo formal e informal
Empleo temporal y permanente
Clase 2: Funcionamiento y Dinámicas del Mercado Laboral

Indicadores del mercado laboral
Tasa de desempleo
Tasa de participación laboral
Tasa de empleo
Salarios y determinación de salarios
Factores que afectan los niveles salariales
Diferencias salariales por industria, región y nivel de habilidad
Desafíos y tendencias actuales en el mercado laboral
Automatización y tecnología
Globalización y movilidad laboral
Políticas de empleo y formación profesional', 5500, NULL, 9)
INSERT [dbo].[Cursos] ([idCurso], [nombreCurso], [descripcion], [temario], [precio], [imagen], [idProfesor]) VALUES (17, N'Orientacion vocacional', N'Como sabes que estudiar', N'Sesión 1: Introducción y Autoconocimiento
Definición y objetivos de la orientación vocacional.
Identificación de intereses personales y habilidades.
Sesión 2: Exploración de Opciones
Análisis del mercado laboral y tendencias.
Investigación de diferentes campos profesionales.
Sesión 3: Toma de Decisiones
Métodos y técnicas para la toma de decisiones.
Factores a considerar al elegir una carrera.
Sesión 4: Planificación y Herramientas
Desarrollo de un plan de acción personalizado.
Uso de herramientas y recursos útiles (pruebas psicométricas, plataformas de investigación).
Sesión 5: Aspectos Emocionales y Evaluación
Manejo del estrés y apoyo emocional.
Evaluación y ajuste del plan de carrera.', 6000, NULL, 11)
SET IDENTITY_INSERT [dbo].[Cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[Profesores] ON 

INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (3, N'Roni', N'Curriculum', N'Vas a aprender a hacer tu curriculum')
INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (4, N'Uli', N'Factura', N'Aca vas a aprender a leer una factura')
INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (5, N'Joaco', N'Financiera', N'Aca vas a aprender sobre la educacion financiera')
INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (6, N'Nicole', N'Crypto', N'Vas a saber lo que es una moneda crypto')
INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (7, N'Fede', N'Banco', N'Como funciona y para que sirve')
INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (8, N'Guido', N'Oferta y demanda', N'Aprender sobre la oferta y demanda')
INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (9, N'Maia', N'Mercado laboral', N'Como funciona el mercado laboral')
INSERT [dbo].[Profesores] ([idProfesor], [nombreProfesor], [contenido], [informacion]) VALUES (11, N'Juli', N'Orientacion vocacional', N'Quiero empezar orientacion vocacional')
SET IDENTITY_INSERT [dbo].[Profesores] OFF
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [FK_Administrador_Usuario1] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [FK_Administrador_Usuario1]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Cursos_Profesores] FOREIGN KEY([idProfesor])
REFERENCES [dbo].[Profesores] ([idProfesor])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Cursos_Profesores]
GO
ALTER TABLE [dbo].[Usuario_Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cursos_Cursos] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Usuario_Cursos] CHECK CONSTRAINT [FK_Usuario_Cursos_Cursos]
GO
ALTER TABLE [dbo].[Usuario_Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cursos_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuario_Cursos] CHECK CONSTRAINT [FK_Usuario_Cursos_Usuario]
GO
