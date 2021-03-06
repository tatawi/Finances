USE [Finance]
GO
/****** Object:  Table [dbo].[InfosAppartement]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[InfosAppartement] ON 

INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (1, CAST(440000.00 AS Decimal(18, 2)), CAST(N'2017-01-04T12:00:00.000' AS DateTime), N'Achat', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (2, CAST(507000.00 AS Decimal(18, 2)), CAST(N'2017-06-01T12:00:00.000' AS DateTime), N'indication meilleursagents.com', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (3, CAST(506000.00 AS Decimal(18, 2)), CAST(N'2017-11-01T12:00:00.000' AS DateTime), N'indication meilleursagents.com', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (4, CAST(519000.00 AS Decimal(18, 2)), CAST(N'2018-03-20T16:17:00.000' AS DateTime), N'indication meilleursagents.com', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (1003, CAST(520000.00 AS Decimal(18, 2)), CAST(N'2018-04-12T09:46:54.940' AS DateTime), N'Meilleurs agents', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (1005, CAST(521200.00 AS Decimal(18, 2)), CAST(N'2018-06-07T10:55:19.763' AS DateTime), N'Meilleurs Agents', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (1006, CAST(525000.00 AS Decimal(18, 2)), CAST(N'2018-07-11T10:36:18.690' AS DateTime), N'Meilleurs agents', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (2006, CAST(559000.00 AS Decimal(18, 2)), CAST(N'2019-02-04T16:44:18.733' AS DateTime), N'Meilleurs agents', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (3006, CAST(572400.00 AS Decimal(18, 2)), CAST(N'2019-04-23T10:16:00.630' AS DateTime), N'Meilleurs Agents', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (3007, CAST(577100.00 AS Decimal(18, 2)), CAST(N'2019-05-03T14:12:36.347' AS DateTime), N'Meilleurs agents', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (3008, CAST(581700.00 AS Decimal(18, 2)), CAST(N'2019-06-19T11:12:51.387' AS DateTime), N'Meilleurs Agents', N'Maxime', N'Valeur')
INSERT [dbo].[InfosAppartement] ([InfosAppartementId], [Montant], [Date], [Description], [UserName], [Type]) VALUES (3009, CAST(553300.00 AS Decimal(18, 2)), CAST(N'2019-07-18T10:59:18.270' AS DateTime), N'indication meilleursagents.com', N'Maxime', N'Valeur')
SET IDENTITY_INSERT [dbo].[InfosAppartement] OFF
