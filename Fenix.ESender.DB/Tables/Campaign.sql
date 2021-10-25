--CREATE TABLE [nwsltr].[Campaign](
--	[CampaignID] [int] IDENTITY(1,1) NOT NULL,
--	[Identifier] [uniqueidentifier] NOT NULL,
--	[PartyID] [int] NOT NULL,
--	[Name] [nvarchar](150) NOT NULL,
--	[UTM_Medium] [nvarchar](50) NOT NULL,
--	[UTM_Source] [nvarchar](50) NOT NULL,
--	[UTM_Term] [nvarchar](50) NOT NULL,
--	[URL] [nvarchar](2000) NULL,
--	[DateTimeCreated] [datetime] NOT NULL,
--	[AssetIdentifier] [uniqueidentifier] NULL,
--	[NumberOfContacts] [int] NULL,
--	[PartyCampaignId] [int] NULL,
--	[DateTimeScheduled] [datetime] NULL,
--	[DateTimeDeleted] [datetime] NULL,
--	[DateTimeSent] [datetime] NULL,
--	[IsQueued] [bit] NOT NULL,
--	[EmailTemplateId] [int] NULL,
--	[PersonaId] [int] NULL,
--	[EmailTypeId] [int] NOT NULL,
--	[MasterCampaignId] [int] NULL,
--	[SendAsType] [int] NOT NULL,
--	[ApiClient] [uniqueidentifier] NULL,
-- CONSTRAINT [PK_Campaign] PRIMARY KEY CLUSTERED 
--(
--	[CampaignID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
--) ON [PRIMARY]
--GO

--ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF__Campaign__Identi__3C1FE2D6]  DEFAULT (newsequentialid()) FOR [Identifier]
--GO

--ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF__Campaign__DateTi__3D14070F]  DEFAULT (getutcdate()) FOR [DateTimeCreated]
--GO

--ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF_nwsltr_Campaign_IsQueued]  DEFAULT ((0)) FOR [IsQueued]
--GO

--ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF_nwsltr_Campaign_EmailTypeId]  DEFAULT ((0)) FOR [EmailTypeId]
--GO

--ALTER TABLE [nwsltr].[Campaign] ADD  CONSTRAINT [DF__Campaign__SendAs__7599EE02]  DEFAULT ((0)) FOR [SendAsType]
--GO
