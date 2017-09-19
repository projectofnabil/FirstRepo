USE [PortfolioDB]
GO

/****** Object:  Table [dbo].[PersonalData]    Script Date: 9/19/2017 12:04:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PersonalData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Phone] [varchar](20) NULL,
	[Nid] [varchar](25) NULL,
	[Gender] [varchar](10) NULL,
	[DOB] [date] NULL,
	[Password] [varchar](20) NULL,
	[Email] [varchar](20) NULL,
	[Photo] [varchar](30) NULL,
	[Role] [varchar](10) NULL,
 CONSTRAINT [PK_PersonalData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


