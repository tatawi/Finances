USE [Finance]
GO
/****** Object:  Table [dbo].[Ref_Reconductible]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[Ref_Reconductible] ON 

INSERT [dbo].[Ref_Reconductible] ([Ref_ReconductibleId], [Nom]) VALUES (1014, N'NR')
INSERT [dbo].[Ref_Reconductible] ([Ref_ReconductibleId], [Nom]) VALUES (1015, N'Annuel')
INSERT [dbo].[Ref_Reconductible] ([Ref_ReconductibleId], [Nom]) VALUES (1016, N'Trimestriel')
INSERT [dbo].[Ref_Reconductible] ([Ref_ReconductibleId], [Nom]) VALUES (1017, N'Mensuel')
INSERT [dbo].[Ref_Reconductible] ([Ref_ReconductibleId], [Nom]) VALUES (1018, N'Hebdomadaire')
INSERT [dbo].[Ref_Reconductible] ([Ref_ReconductibleId], [Nom]) VALUES (1019, N'Quotidient')
SET IDENTITY_INSERT [dbo].[Ref_Reconductible] OFF
