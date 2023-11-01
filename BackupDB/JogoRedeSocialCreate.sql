USE [PII IV]
GO

/****** Object:  Table [dbo].[JogoRedeSocial]    Script Date: 31/10/2023 21:57:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[JogoRedeSocial](
	[idJogoRedeSocial] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[dominio] [varchar](150) NULL,
	[tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_JogoRedeSocial] PRIMARY KEY CLUSTERED 
(
	[idJogoRedeSocial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

