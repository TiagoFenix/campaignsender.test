using Dapper;
using Fenix.ESender.API.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Data
{
    public class CampaignRepository : BaseRepository, ICampaignRepository
    {
        public CampaignRepository(IConnectionFactory connection) : base(connection, "nwsltr.Campaign", "CampaignID")
        {
        }

        protected override string GetTableUpdateValues()
        {
            return @"
                       [Identifier]        = @identifier      
                      ,[PartyID]           = @partyID         
                      ,[Name]              = @name            
                      ,[UTM_Medium]        = @utm_Medium      
                      ,[UTM_Source]        = @utm_Source      
                      ,[UTM_Term]          = @utm_Term        
                      ,[URL]               = @url             
                      ,[DateTimeCreated]   = @dateTimeCreated 
                      ,[AssetIdentifier]   = @assetIdentifier 
                      ,[NumberOfContacts]  = @numberOfContacts
                      ,[PartyCampaignId]   = @partyCampaignId 
                      ,[DateTimeScheduled] = @dateTimeScheduled
                      ,[DateTimeDeleted]   = @dateTimeDeleted 
                      ,[DateTimeSent]      = @dateTimeSent    
                      ,[IsQueued]          = @isQueued        
                      ,[EmailTemplateId]   = @emailTemplateId 
                      ,[PersonaId]         = @personaId       
                      ,[EmailTypeId]       = @emailTypeId     
                      ,[MasterCampaignId]  = @masterCampaignId
                      ,[SendAsType]        = @sendAsType      
                      ,[ApiClient]         = @apiClient       
                ";
        }

        protected override string GetTableColumns()
        {
            return @"
                        [Identifier]
                       ,[PartyID]
                       ,[Name]
                       ,[UTM_Medium]
                       ,[UTM_Source]
                       ,[UTM_Term]
                       ,[URL]
                       ,[DateTimeCreated]
                       ,[AssetIdentifier]
                       ,[NumberOfContacts]
                       ,[PartyCampaignId]
                       ,[DateTimeScheduled]
                       ,[DateTimeDeleted]
                       ,[DateTimeSent]
                       ,[IsQueued]
                       ,[EmailTemplateId]
                       ,[PersonaId]
                       ,[EmailTypeId]
                       ,[MasterCampaignId]
                       ,[SendAsType]
                       ,[ApiClient] ";
        }

        protected override string GetTableValues()
        {
            return @"
                        @identifier
                       ,@partyID
                       ,@name
                       ,@utm_Medium
                       ,@utm_Source
                       ,@utm_Term
                       ,@url
                       ,@dateTimeCreated
                       ,@assetIdentifier
                       ,@numberOfContacts
                       ,@partyCampaignId
                       ,@dateTimeScheduled
                       ,@dateTimeDeleted
                       ,@dateTimeSent
                       ,@isQueued
                       ,@emailTemplateId
                       ,@personaId
                       ,@emailTypeId
                       ,@masterCampaignId
                       ,@sendAsType
                       ,@apiClient ";
        }

        public async Task<bool> Delete(int campaignID)
        {
            using (IDbConnection db = connection.GetOpenConnection())
            {
                await db.QueryAsync(GetDeleteSqlStr(), new Campaign() { campaignID = campaignID });
                return true;
            }
        }

        public async Task<IEnumerable<Campaign>> Get(Campaign campaign = null)
        {
            using (IDbConnection db = connection.GetOpenConnection())
            {
                return await db.QueryAsync<Campaign>(GetSelectSqlStr(), campaign);
            }
        }

        public async Task<IEnumerable<Campaign>> GetSecheduledByPartyId(int partyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("partyId", partyId);

            using (IDbConnection db = connection.GetOpenConnection())
            {
                return await db.QueryAsync<Campaign>(GetSelectSqlStr() + " WHERE DateTimeSent IS NULL AND PartyId = @partyId ORDER BY DateTimeScheduled DESC", parameters);
            }
        }

        public async Task<IEnumerable<Campaign>> GetSentByPartyId(int partyId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("partyId", partyId);

            using (IDbConnection db = connection.GetOpenConnection())
            {
                return await db.QueryAsync<Campaign>(GetSelectSqlStr() + " WHERE DateTimeSent IS NOT NULL AND PartyId = @partyId ORDER BY DateTimeSent DESC", parameters);
            }
        }

        public async Task<Campaign> GetOne(int campaignID)
        {
            using (IDbConnection db = connection.GetOpenConnection())
            {
                return await db.QueryFirstOrDefaultAsync<Campaign>(GetSelectSqlStr(), new Campaign() { campaignID = campaignID });
            }
        }

        public async Task<Campaign> Insert(Campaign campaign)
        {
            using (IDbConnection db = connection.GetOpenConnection())
            {
                campaign.campaignID = await db.QuerySingleAsync<int>(GetInsertSqlStr(), campaign);
                return campaign;
            }
        }

        public async Task<Campaign> Update(Campaign campaign)
        {
            using (IDbConnection db = connection.GetOpenConnection())
            {
                await db.ExecuteAsync(GetUpdateSqlStr(), campaign);
                return campaign;
            }
        }
    }
}
