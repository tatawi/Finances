USE [Finance]
GO
/****** Object:  Table [dbo].[BilanCarbone]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BilanCarbone](
	[BilanCarboneId] [int] IDENTITY(1,1) NOT NULL,
	[Annee] [int] NOT NULL,
	[Logement] [decimal](18, 0) NOT NULL,
	[ServiceId] [decimal](18, 0) NOT NULL,
	[Transports] [decimal](18, 0) NOT NULL,
	[Alimentation] [decimal](18, 0) NOT NULL,
	[Dechets] [decimal](18, 0) NOT NULL,
	[Achats] [decimal](18, 0) NOT NULL,
	[Finance] [decimal](18, 0) NOT NULL,
	[ServicePublique] [decimal](18, 0) NOT NULL,
	[UserName] [varchar](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BilanCarboneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategorieDepense]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategorieDepense](
	[CategorieDepenseId] [int] IDENTITY(1,1) NOT NULL,
	[libelle] [varchar](15) NULL,
	[CategorieId] [int] NULL,
	[SousCategorieId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategorieDepenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsoChauffage]    Script Date: 02/12/2019 16:57:47 ******/
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
/****** Object:  Table [dbo].[ConsoEau]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsoEau](
	[ConsoEauId] [int] IDENTITY(1,1) NOT NULL,
	[Annee] [int] NOT NULL,
	[Type] [varchar](20) NULL,
	[Emplacement] [varchar](20) NULL,
	[Montant] [decimal](18, 2) NULL,
	[Consommation] [decimal](18, 0) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsoElectricite]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsoElectricite](
	[ElectriciteId] [int] IDENTITY(1,1) NOT NULL,
	[Montant] [decimal](5, 2) NULL,
	[Consommation] [int] NULL,
	[Date] [datetime] NULL,
	[Description] [varchar](50) NULL,
	[PrixKwh] [decimal](5, 2) NULL,
	[UserName] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ElectriciteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Depense]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depense](
	[DepenseId] [int] IDENTITY(1,1) NOT NULL,
	[Montant] [decimal](18, 2) NULL,
	[Date] [datetime] NULL,
	[Libelle] [varchar](max) NULL,
	[Categorie] [varchar](30) NULL,
	[SousCategorie] [varchar](30) NULL,
	[Reconductible] [varchar](30) NULL,
	[compte] [varchar](10) NULL,
	[UserName] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepenseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Epargne]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Epargne](
	[EpargneId] [int] IDENTITY(1,1) NOT NULL,
	[CompteId] [int] NULL,
	[Montant] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PF_EpargneId] PRIMARY KEY CLUSTERED 
(
	[EpargneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InfosAppartement]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InfosAppartement](
	[InfosAppartementId] [int] IDENTITY(1,1) NOT NULL,
	[Montant] [decimal](18, 2) NULL,
	[Date] [datetime] NULL,
	[Description] [varchar](max) NULL,
	[UserName] [varchar](20) NULL,
	[Type] [varchar](20) NULL,
 CONSTRAINT [PF_InfosAppartementId] PRIMARY KEY CLUSTERED 
(
	[InfosAppartementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ref_Categorie]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_Categorie](
	[Ref_CategorieId] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NULL,
	[MontantTVA] [decimal](18, 2) NULL,
	[rang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ref_CategorieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ref_Compte]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_Compte](
	[Ref_CompteId] [int] IDENTITY(1,1) NOT NULL,
	[Compte] [varchar](20) NULL,
	[UserName] [varchar](20) NULL,
	[IsActif] [bit] NULL,
	[Montant] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ref_CompteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ref_Reconductible]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_Reconductible](
	[Ref_ReconductibleId] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Ref_ReconductibleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ref_SsCategorie]    Script Date: 02/12/2019 16:57:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ref_SsCategorie](
	[Ref_SsCategorieId] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [varchar](50) NULL,
	[Categorie] [varchar](30) NULL,
	[rang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ref_SsCategorieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CategorieDepense]  WITH CHECK ADD FOREIGN KEY([CategorieId])
REFERENCES [dbo].[Ref_Categorie] ([Ref_CategorieId])
GO
ALTER TABLE [dbo].[CategorieDepense]  WITH CHECK ADD FOREIGN KEY([SousCategorieId])
REFERENCES [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId])
GO
ALTER TABLE [dbo].[Epargne]  WITH CHECK ADD FOREIGN KEY([CompteId])
REFERENCES [dbo].[Ref_Compte] ([Ref_CompteId])
GO
