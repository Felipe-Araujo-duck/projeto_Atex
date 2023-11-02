USE [PII IV]
GO

/****** Object:  Table [dbo].[Responsavel]    Script Date: 31/10/2023 21:58:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Responsavel](
	[idResponsavel] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[telefone] [varchar](50) NULL,
 CONSTRAINT [PK_Responsavel] PRIMARY KEY CLUSTERED 
(
	[idResponsavel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

