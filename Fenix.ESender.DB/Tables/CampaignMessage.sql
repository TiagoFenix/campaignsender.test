
--CREATE TABLE [nwsltr].[CampaignMessage](
--	[CampaignMessageID] [int] IDENTITY(5450000,1) NOT NULL,
--	[CampaignID] [int] NOT NULL,
--	[Identifier] [uniqueidentifier] NOT NULL,
--	[SimpleQueryServiceMessageId] [nvarchar](250) NULL,
--	[SimpleQueryServiceRequestId] [nvarchar](250) NULL,
--	[DateTimeCreated] [datetime] NOT NULL,
--	[SimpleEmailServiceMessageId] [nvarchar](250) NULL,
--	[SimpleEmailServiceRequestId] [nvarchar](250) NULL,
--	[SimpleEmailServiceDateTimeCreated] [datetime] NULL,
--	[ContactID] [int] NULL,
--	[Opened] [bit] NULL,
--	[ClickedThrough] [bit] NULL,
--	[SimpleQueryServiceMessageDateTimeCreated] [datetime] NULL,
--	[SimpleEmailServiceMessageDateTimeCreated] [datetime] NULL,
--	[TotalOpens] [int] NOT NULL,
--	[TotalClicks] [int] NOT NULL,
--	[SimpleEmailServiceMessageIdAddress]  AS (case when [SimpleEmailServiceMessageId] IS NULL then NULL else ('<'+[SimpleEmailServiceMessageId])+'@email.amazonses.com>' end),
-- CONSTRAINT [PK_CampaignMessage2] PRIMARY KEY NONCLUSTERED 
--(
--	[CampaignMessageID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__Ident__19D5B7CA]  DEFAULT (newsequentialid()) FOR [Identifier]
--GO

--ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__DateT__1AC9DC03]  DEFAULT (getdate()) FOR [DateTimeCreated]
--GO

--ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__Total__17B8652E]  DEFAULT ((0)) FOR [TotalOpens]
--GO

--ALTER TABLE [nwsltr].[CampaignMessage] ADD  CONSTRAINT [DF__CampaignM__Total__18AC8967]  DEFAULT ((0)) FOR [TotalClicks]
--GO

--ALTER TABLE [nwsltr].[CampaignMessage]  WITH CHECK ADD  CONSTRAINT [FK_CampaignCampaignMessage2] FOREIGN KEY([CampaignID])
--REFERENCES [nwsltr].[Campaign] ([CampaignID])
--GO

--ALTER TABLE [nwsltr].[CampaignMessage] CHECK CONSTRAINT [FK_CampaignCampaignMessage2]
--GO
