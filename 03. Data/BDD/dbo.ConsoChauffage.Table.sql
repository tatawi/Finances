USE [Finance]
GO
/****** Object:  Table [dbo].[ConsoChauffage]    Script Date: 02/12/2019 17:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsoChauffage](
	[ChauffageId] [int] IDENTITY(1,1) NOT NULL,
	[Annee] [int] NULL,
	[ConsoTotale] [int] NULL,
	[ConsoPerso] [int] NULL,
	[CoutTotal] [int] NULL,
	[CoutPerso] [int] NULL,
	[KwhTotal] [int] NULL,
	[KwhPerso] [int] NULL,
	[CoutKwh] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ChauffageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ConsoChauffage] ON 

INSERT [dbo].[ConsoChauffage] ([ChauffageId], [Annee], [ConsoTotale], [ConsoPerso], [CoutTotal], [CoutPerso], [KwhTotal], [KwhPerso], [CoutKwh]) VALUES (8, 2018, 1901901, 1339, 84436, 60, 1196360, 843, CAST(0.07 AS Decimal(5, 2)))
INSERT [dbo].[ConsoChauffage] ([ChauffageId], [Annee], [ConsoTotale], [ConsoPerso], [CoutTotal], [CoutPerso], [KwhTotal], [KwhPerso], [CoutKwh]) VALUES (9, 2017, 0, 0, 42600, 294, 608695, 2768, CAST(0.07 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[ConsoChauffage] OFF
