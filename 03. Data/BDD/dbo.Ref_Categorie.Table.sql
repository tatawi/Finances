USE [Finance]
GO
/****** Object:  Table [dbo].[Ref_Categorie]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[Ref_Categorie] ON 

INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (16, N'Logement', CAST(20.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (17, N'Alimentaire', CAST(20.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (18, N'Voiture', CAST(20.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (19, N'Transport', CAST(20.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (20, N'Loisirs', CAST(20.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (21, N'Voyages', CAST(20.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (22, N'Cadeaux', CAST(20.00 AS Decimal(18, 2)), 8)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (23, N'Achats', CAST(20.00 AS Decimal(18, 2)), 9)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (24, N'Vetements', CAST(20.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (25, N'Sante', CAST(20.00 AS Decimal(18, 2)), 11)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (26, N'Impots', CAST(20.00 AS Decimal(18, 2)), 12)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (27, N'FraisBancaires', CAST(20.00 AS Decimal(18, 2)), 14)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (28, N'Emprunts', CAST(20.00 AS Decimal(18, 2)), 15)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (29, N'Revenus', CAST(20.00 AS Decimal(18, 2)), 17)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (30, N'ImpotsTOTAUX', CAST(0.00 AS Decimal(18, 2)), 13)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (31, N'SOLDE', CAST(0.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Ref_Categorie] ([Ref_CategorieId], [Nom], [MontantTVA], [rang]) VALUES (32, N'TOTALdépenses', CAST(0.00 AS Decimal(18, 2)), 16)
SET IDENTITY_INSERT [dbo].[Ref_Categorie] OFF
