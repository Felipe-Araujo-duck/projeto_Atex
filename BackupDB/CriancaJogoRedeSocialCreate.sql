USE [PII IV]
GO

/****** Object:  Table [dbo].[CriancaJogoRedeSocial]    Script Date: 31/10/2023 21:57:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CriancaJogoRedeSocial](
	[idJogoRedeSocial] [int] NOT NULL,
	[idCrianca] [int] NOT NULL,
	[idCriancaJogoRedeSocial] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CriancaJogoRedeSocial] PRIMARY KEY CLUSTERED 
(
	[idCriancaJogoRedeSocial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CriancaJogoRedeSocial]  WITH CHECK ADD  CONSTRAINT [FK_CriancaJogoRedeSocial_JogoRedeSocial] FOREIGN KEY([idJogoRedeSocial])
REFERENCES [dbo].[JogoRedeSocial] ([idJogoRedeSocial])
GO

ALTER TABLE [dbo].[CriancaJogoRedeSocial] CHECK CONSTRAINT [FK_CriancaJogoRedeSocial_JogoRedeSocial]
GO

