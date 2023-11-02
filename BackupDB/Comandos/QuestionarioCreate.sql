USE [PII IV]
GO

/****** Object:  Table [dbo].[Questionario]    Script Date: 31/10/2023 21:58:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Questionario](
	[idQuestionario] [int] IDENTITY(1,1) NOT NULL,
	[idCrianca] [int] NOT NULL,
	[dataQuestionario] [date] NOT NULL,
	[possuiCelularProprio] [smallint] NOT NULL,
	[acessoInternet] [smallint] NOT NULL,
	[tempoUsoDiario] [int] NOT NULL,
	[recebeMonitoramento] [int] NOT NULL,
	[idOutroJogoRedeSocial] [int] NULL,
	[idCriancaJogoRedeSocial] [int] NULL,
 CONSTRAINT [PK_Questionario] PRIMARY KEY CLUSTERED 
(
	[idQuestionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Questionario]  WITH CHECK ADD  CONSTRAINT [FK_Questionario_Crianca] FOREIGN KEY([idCrianca])
REFERENCES [dbo].[Crianca] ([idCrianca])
GO

ALTER TABLE [dbo].[Questionario] CHECK CONSTRAINT [FK_Questionario_Crianca]
GO

ALTER TABLE [dbo].[Questionario]  WITH CHECK ADD  CONSTRAINT [FK_Questionario_CriancaJogoRedeSocial] FOREIGN KEY([idCriancaJogoRedeSocial])
REFERENCES [dbo].[CriancaJogoRedeSocial] ([idCriancaJogoRedeSocial])
GO

ALTER TABLE [dbo].[Questionario] CHECK CONSTRAINT [FK_Questionario_CriancaJogoRedeSocial]
GO

ALTER TABLE [dbo].[Questionario]  WITH CHECK ADD  CONSTRAINT [FK_Questionario_OutroJogoRedeSocial] FOREIGN KEY([idOutroJogoRedeSocial])
REFERENCES [dbo].[OutroJogoRedeSocial] ([idOutroJogoRedeSocial])
GO

ALTER TABLE [dbo].[Questionario] CHECK CONSTRAINT [FK_Questionario_OutroJogoRedeSocial]
GO

