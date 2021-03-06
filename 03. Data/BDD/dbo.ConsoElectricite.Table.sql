USE [Finance]
GO
/****** Object:  Table [dbo].[ConsoElectricite]    Script Date: 02/12/2019 17:07:39 ******/
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
SET IDENTITY_INSERT [dbo].[ConsoElectricite] ON 

INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (39, CAST(20.00 AS Decimal(5, 2)), 65, CAST(N'2019-01-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (40, CAST(23.00 AS Decimal(5, 2)), 89, CAST(N'2019-02-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (41, CAST(26.00 AS Decimal(5, 2)), 105, CAST(N'2019-03-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (42, CAST(26.00 AS Decimal(5, 2)), 104, CAST(N'2019-04-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (43, CAST(27.00 AS Decimal(5, 2)), 110, CAST(N'2019-05-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (44, CAST(25.00 AS Decimal(5, 2)), 96, CAST(N'2019-06-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (45, CAST(23.00 AS Decimal(5, 2)), 87, CAST(N'2019-07-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (46, CAST(26.00 AS Decimal(5, 2)), 106, CAST(N'2019-08-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (47, CAST(24.00 AS Decimal(5, 2)), 93, CAST(N'2019-09-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (48, CAST(25.00 AS Decimal(5, 2)), 96, CAST(N'2019-10-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (49, CAST(12.00 AS Decimal(5, 2)), 42, CAST(N'2019-11-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (50, CAST(0.00 AS Decimal(5, 2)), 0, CAST(N'2019-12-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (51, CAST(25.00 AS Decimal(5, 2)), 98, CAST(N'2018-01-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (52, CAST(25.00 AS Decimal(5, 2)), 100, CAST(N'2018-02-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (53, CAST(25.00 AS Decimal(5, 2)), 98, CAST(N'2018-03-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (54, CAST(24.00 AS Decimal(5, 2)), 95, CAST(N'2018-04-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (55, CAST(25.00 AS Decimal(5, 2)), 102, CAST(N'2018-05-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (56, CAST(25.00 AS Decimal(5, 2)), 101, CAST(N'2018-06-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (57, CAST(25.00 AS Decimal(5, 2)), 101, CAST(N'2018-07-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (58, CAST(26.00 AS Decimal(5, 2)), 103, CAST(N'2018-08-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (59, CAST(24.00 AS Decimal(5, 2)), 95, CAST(N'2018-09-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (60, CAST(27.00 AS Decimal(5, 2)), 110, CAST(N'2018-10-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (61, CAST(25.00 AS Decimal(5, 2)), 99, CAST(N'2018-11-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (62, CAST(26.00 AS Decimal(5, 2)), 105, CAST(N'2018-12-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (63, CAST(12.00 AS Decimal(5, 2)), 52, CAST(N'2017-01-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (64, CAST(14.00 AS Decimal(5, 2)), 59, CAST(N'2017-02-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (65, CAST(16.00 AS Decimal(5, 2)), 69, CAST(N'2017-03-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (66, CAST(22.00 AS Decimal(5, 2)), 94, CAST(N'2017-04-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (67, CAST(22.00 AS Decimal(5, 2)), 92, CAST(N'2017-05-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (68, CAST(25.00 AS Decimal(5, 2)), 105, CAST(N'2017-06-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (69, CAST(21.00 AS Decimal(5, 2)), 89, CAST(N'2017-07-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (70, CAST(22.00 AS Decimal(5, 2)), 98, CAST(N'2017-08-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (71, CAST(20.00 AS Decimal(5, 2)), 83, CAST(N'2017-09-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (72, CAST(20.00 AS Decimal(5, 2)), 84, CAST(N'2017-10-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (73, CAST(22.00 AS Decimal(5, 2)), 94, CAST(N'2017-11-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
INSERT [dbo].[ConsoElectricite] ([ElectriciteId], [Montant], [Consommation], [Date], [Description], [PrixKwh], [UserName]) VALUES (74, CAST(26.00 AS Decimal(5, 2)), 108, CAST(N'2017-12-01T00:00:00.000' AS DateTime), N'', CAST(0.00 AS Decimal(5, 2)), N'Maxime')
SET IDENTITY_INSERT [dbo].[ConsoElectricite] OFF
