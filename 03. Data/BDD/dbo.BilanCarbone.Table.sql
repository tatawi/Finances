USE [Finance]
GO
/****** Object:  Table [dbo].[BilanCarbone]    Script Date: 02/12/2019 17:07:39 ******/
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
