USE [PII IV]
GO

/****** Object:  Table [dbo].[Crianca]    Script Date: 31/10/2023 21:56:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Crianca](
	[idCrianca] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[dataNascimento] [date] NOT NULL,
	[idResponsavel] [int] NOT NULL,
	[idEscola] [int] NOT NULL,
 CONSTRAINT [PK_Crianca] PRIMARY KEY CLUSTERED 
(
	[idCrianca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Crianca]  WITH CHECK ADD  CONSTRAINT [FK_Crianca_Escola] FOREIGN KEY([idEscola])
REFERENCES [dbo].[Escola] ([idEscola])
GO

ALTER TABLE [dbo].[Crianca] CHECK CONSTRAINT [FK_Crianca_Escola]
GO

ALTER TABLE [dbo].[Crianca]  WITH CHECK ADD  CONSTRAINT [FK_Crianca_Responsavel] FOREIGN KEY([idResponsavel])
REFERENCES [dbo].[Responsavel] ([idResponsavel])
GO

ALTER TABLE [dbo].[Crianca] CHECK CONSTRAINT [FK_Crianca_Responsavel]
GO

