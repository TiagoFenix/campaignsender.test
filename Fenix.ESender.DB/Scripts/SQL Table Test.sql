
/****** Object:  Table [nwsltr].[Campaign]    Script Date: 10/19/2021 10:34:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE SCHEMA [nwsltr]

CREATE TABLE [nwsltr].[Campaign](
	[CampaignID] [int] IDENTITY(1,1) NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[PartyID] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[UTM_Medium] [nvarchar](50) NOT NULL,
	[UTM_Source] [nvarchar](50) NOT NULL,
	[UTM_Term] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](2000) NULL,
	[DateTimeCreated] [datetime] NOT NULL,
	[AssetIdentifier] [uniqueidentifier] NULL,
	[NumberOfContacts] [int] NULL,
	[PartyCampaignId] [int] NULL,
	[DateTimeScheduled] [datetime] NULL,
	[DateTimeDeleted] [datetime] NULL,
	[DateTimeSent] [datetime] NULL,
	[IsQueued] [bit] NOT NULL,
	[EmailTemplateId] [int] NULL,
	[PersonaId] [int] NULL,
	[EmailTypeId] [int] NOT NULL,
	[MasterCampaignId] [int] NULL,
	[SendAsType] [int] NOT NULL,
	[ApiClient] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED 
(
	[CampaignID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF__Campaign__Identi__3C1FE2D6]  DEFAULT (newsequentialid()) FOR [Identifier]
GO

ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF__Campaign__DateTi__3D14070F]  DEFAULT (getutcdate()) FOR [DateTimeCreated]
GO

ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF_nwsltr_Campaign_IsQueued]  DEFAULT ((0)) FOR [IsQueued]
GO

ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF_nwsltr_Campaign_EmailTypeId]  DEFAULT ((0)) FOR [EmailTypeId]
GO

ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF__Campaign__SendAs__7599EE02]  DEFAULT ((0)) FOR [SendAsType]
GO


CREATE TABLE [nwsltr].[CampaignMessage](
	[CampaignMessageID] [int] IDENTITY(5450000,1) NOT NULL,
	[CampaignID] [int] NOT NULL,
	[Identifier] [uniqueidentifier] NOT NULL,
	[SimpleQueryServiceMessageId] [nvarchar](250) NULL,
	[SimpleQueryServiceRequestId] [nvarchar](250) NULL,
	[DateTimeCreated] [datetime] NOT NULL,
	[SimpleEmailServiceMessageId] [nvarchar](250) NULL,
	[SimpleEmailServiceRequestId] [nvarchar](250) NULL,
	[SimpleEmailServiceDateTimeCreated] [datetime] NULL,
	[ContactID] [int] NULL,
	[Opened] [bit] NULL,
	[ClickedThrough] [bit] NULL,
	[SimpleQueryServiceMessageDateTimeCreated] [datetime] NULL,
	[SimpleEmailServiceMessageDateTimeCreated] [datetime] NULL,
	[TotalOpens] [int] NOT NULL,
	[TotalClicks] [int] NOT NULL,
	[SimpleEmailServiceMessageIdAddress]  AS (case when [SimpleEmailServiceMessageId] IS NULL then NULL else ('<'+[SimpleEmailServiceMessageId])+'@email.amazonses.com>' end),
 CONSTRAINT [PK_CampaignMessage2] PRIMARY KEY NONCLUSTERED 
(
	[CampaignMessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__Ident__19D5B7CA]  DEFAULT (newsequentialid()) FOR [Identifier]
GO

ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__DateT__1AC9DC03]  DEFAULT (getdate()) FOR [DateTimeCreated]
GO

ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__Total__17B8652E]  DEFAULT ((0)) FOR [TotalOpens]
GO

ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__Total__18AC8967]  DEFAULT ((0)) FOR [TotalClicks]
GO

ALTER TABLE [nwsltr].[CampaignMessage]  WITH CHECK ADD  CONSTRAINT [FK_CampaignCampaignMessage2] FOREIGN KEY([CampaignID])
REFERENCES [nwsltr].[Campaign] ([CampaignID])
GO

ALTER TABLE [nwsltr].[CampaignMessage] CHECK CONSTRAINT [FK_CampaignCampaignMessage2]
GO


