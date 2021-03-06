USE [Finance]
GO
/****** Object:  Table [dbo].[ConsoEau]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[ConsoEau] ON 

INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (16, 2017, N'Froid', N'Cuisine', CAST(30.00 AS Decimal(18, 2)), CAST(9 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (17, 2017, N'Chaud', N'Cuisine', CAST(66.00 AS Decimal(18, 2)), CAST(5 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (18, 2017, N'Froid', N'Sdb', CAST(54.00 AS Decimal(18, 2)), CAST(16 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (19, 2017, N'Chaud', N'Sdb', CAST(165.00 AS Decimal(18, 2)), CAST(13 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (20, 2017, N'Froid', N'WC', CAST(41.00 AS Decimal(18, 2)), CAST(12 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (11, 2018, N'Froid', N'Cuisine', CAST(42.00 AS Decimal(18, 2)), CAST(12 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (12, 2018, N'Chaud', N'Cuisine', CAST(66.00 AS Decimal(18, 2)), CAST(5 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (13, 2018, N'Froid', N'Sdb', CAST(64.00 AS Decimal(18, 2)), CAST(18 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (14, 2018, N'Chaud', N'Sdb', CAST(165.00 AS Decimal(18, 2)), CAST(13 AS Decimal(18, 0)))
INSERT [dbo].[ConsoEau] ([ConsoEauId], [Annee], [Type], [Emplacement], [Montant], [Consommation]) VALUES (15, 2018, N'Froid', N'WC', CAST(60.00 AS Decimal(18, 2)), CAST(17 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[ConsoEau] OFF
