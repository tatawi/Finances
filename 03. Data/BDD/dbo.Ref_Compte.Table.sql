USE [Finance]
GO
/****** Object:  Table [dbo].[Ref_Compte]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[Ref_Compte] ON 

INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (2, N'Livret A', N'Maxime', 1, 15000)
INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (3, N'LDD', N'Maxime', 1, 9895)
INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (4, N'Fortuneo', N'Maxime', 1, 63933)
INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (5, N'Fond DORIS', N'Maxime', 1, 0)
INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (6, N'Mutualis', N'Maxime', 1, 5399)
INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (7, N'Affer', N'Maxime', 1, 1102)
INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (8, N'Boursorama', N'Maxime', 1, 2708)
INSERT [dbo].[Ref_Compte] ([Ref_CompteId], [Compte], [UserName], [IsActif], [Montant]) VALUES (9, N'Or', N'Maxime', 1, 450)
SET IDENTITY_INSERT [dbo].[Ref_Compte] OFF
