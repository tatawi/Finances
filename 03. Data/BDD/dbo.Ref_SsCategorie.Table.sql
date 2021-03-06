USE [Finance]
GO
/****** Object:  Table [dbo].[Ref_SsCategorie]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[Ref_SsCategorie] ON 

INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (14, N'Loyer', N'Logement', 1)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (15, N'Charges', N'Logement', 2)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (16, N'Electricite', N'Logement', 3)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (17, N'Internet', N'Logement', 4)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (18, N'Assurance', N'Logement', 5)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (19, N'Decoration', N'Logement', 6)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (20, N'Courses', N'Alimentaire', 7)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (21, N'Repas travail', N'Alimentaire', 8)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (22, N'Essence', N'Voiture', 9)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (23, N'Entretien', N'Voiture', 10)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (24, N'Peages', N'Voiture', 11)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (25, N'Assurances', N'Voiture', 12)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (26, N'Sorties', N'Loisirs', 13)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (27, N'Restaurants', N'Loisirs', 14)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (28, N'Visites', N'Loisirs', 15)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (29, N'Chat', N'Loisirs', 16)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (30, N'General', N'Loisirs', 17)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (31, N'Informatique', N'Achats', 18)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (32, N'Divers', N'Achats', 19)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (33, N'Frais', N'Sante', 20)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (34, N'Remboursement', N'Sante', 21)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (35, N'Mutuelle', N'Sante', 22)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (36, N'Taxe habitation', N'Impots', 23)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (37, N'Taxe fonciere', N'Impots', 24)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (38, N'Taxe Ordures M', N'Impots', 25)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (39, N'Impots revenus', N'Impots', 26)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (40, N'Autre', N'Impots', 27)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (41, N'Appartement', N'Emprunts', 28)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (42, N'Emprunt1', N'Emprunts', 29)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (43, N'Emprunt2', N'Emprunts', 30)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (44, N'Salaire', N'Revenus', 31)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (45, N'Entreprise', N'Revenus', 32)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (46, N'Aides', N'Revenus', 33)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (47, N'Interets Fi', N'Revenus', 34)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (48, N'Vente', N'Revenus', 35)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (49, N'Location', N'Revenus', 36)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (50, N'Cadeaux R', N'Revenus', 37)
INSERT [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId], [Nom], [Categorie], [rang]) VALUES (52, N'Cotisations', N'Impots', 26)
SET IDENTITY_INSERT [dbo].[Ref_SsCategorie] OFF
