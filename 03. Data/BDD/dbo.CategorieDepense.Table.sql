USE [Finance]
GO
/****** Object:  Table [dbo].[CategorieDepense]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[CategorieDepense] ON 

INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (1, N'AMAZON', 23, 31)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (6, N'MONOPRIX', 17, 20)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (7, N'ORANGE', 16, 17)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (8, N'ADOBE CREATIVE', 23, 31)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (9, N'PICARD', 17, 20)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (10, N'MCDONALDS', 20, 27)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (11, N'DOMINO''S', 20, 27)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (12, N'STEAMGAMES', 23, 31)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (13, N'FRANPRIX', 17, 20)
INSERT [dbo].[CategorieDepense] ([CategorieDepenseId], [libelle], [CategorieId], [SousCategorieId]) VALUES (14, N'DELIVEROO.FR', 20, 27)
SET IDENTITY_INSERT [dbo].[CategorieDepense] OFF
ALTER TABLE [dbo].[CategorieDepense]  WITH CHECK ADD FOREIGN KEY([CategorieId])
REFERENCES [dbo].[Ref_Categorie] ([Ref_CategorieId])
GO
ALTER TABLE [dbo].[CategorieDepense]  WITH CHECK ADD FOREIGN KEY([SousCategorieId])
REFERENCES [dbo].[Ref_SsCategorie] ([Ref_SsCategorieId])
GO
