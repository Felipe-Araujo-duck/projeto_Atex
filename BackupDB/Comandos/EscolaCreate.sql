USE [PII IV]
GO

/****** Object:  Table [dbo].[Escola]    Script Date: 31/10/2023 21:57:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Escola](
	[idEscola] [int] IDENTITY(1,1) NOT NULL,
	[cidade] [varchar](100) NOT NULL,
	[rua] [varchar](100) NOT NULL,
	[bairro] [varchar](50) NOT NULL,
	[numero] [varchar](10) NOT NULL,
	[nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Escola] PRIMARY KEY CLUSTERED 
(
	[idEscola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

