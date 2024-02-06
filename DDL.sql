USE [FIAPPortalInvest]
GO

/****** Object:  Table [dbo].[Usuario]    Script Date: 05/01/2024 16:36:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('[dbo].[Usuario]') <> NULL 
	DROP TABLE [dbo].[Usuario]
IF OBJECT_ID('[dbo].[Proposta]') <> NULL 
	DROP TABLE [dbo].[Proposta]
GO
IF OBJECT_ID('[dbo].[Log]') is NOT NULL 
	DROP TABLE [dbo].[Log]
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nome] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL, 
	[TipoAcesso] [int] NOT NULL, 
	CONSTRAINT AK_Usuario_Email UNIQUE(Email)  
) ON [PRIMARY]
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Proposta](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Codigo_Interno] [varchar](50) NOT NULL,
	[Codigo_Empresa] [varchar](100) NOT NULL,
	[Codigo_Apolice] [varchar](100) NOT NULL, 
	[Segurado_Id] int, 
	[Endereco_Segurado] [int] NOT NULL, 
	CONSTRAINT AK_Usuario_Email UNIQUE(Email)  
) ON [PRIMARY]
GO


GO

CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Data_Log] DATETIME NOT NULL,
	[Tipo_Log] [varchar](20) NOT NULL, 
	[Mensagem] [varchar](500) NOT NULL,
	[Stack_Trace] [varchar](1000) NULL,
	[Module_Name] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
GO

CREATE TABLE [dbo].[Condicao_Pagto](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Descricao] [varchar](50) NOT NULL,
	[Codigo] [varchar](20) NOT NULL, 
	[Max_Parcelamento] int NOT NULL
) ON [PRIMARY]
GO




