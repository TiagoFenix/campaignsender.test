using Dapper;
using Fenix.ESender.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Fenix.ESender.Data
{
    public class CampaignMessageRepository : BaseRepository, ICampaignMessageRepository
    {
        public CampaignMessageRepository(IConnectionFactory connection) : base(connection, "nwsltr.CampaignMessage", "CampaignMessageID")
        {

        }

        protected override string GetTableColumns()
        {
            return @"
                       [CampaignID]
                       ,[Identifier]
                       ,[SimpleQueryServiceMessageId]
                       ,[SimpleQueryServiceRequestId]
                       ,[DateTimeCreated]
                       ,[SimpleEmailServiceMessageId]
                       ,[SimpleEmailServiceRequestId]
                       ,[SimpleEmailServiceDateTimeCreated]
                       ,[ContactID]
                       ,[Opened]
                       ,[ClickedThrough]
                       ,[SimpleQueryServiceMessageDateTimeCreated]
                       ,[SimpleEmailServiceMessageDateTimeCreated]
                       ,[TotalOpens]
                       ,[TotalClicks] 
                   ";
        }

        protected override string GetTableValues()
        {
            return @"
                       @campaignID
                      ,@identifier
                      ,@simpleQueryServiceMessageId
                      ,@simpleQueryServiceRequestId
                      ,@dateTimeCreated
                      ,@simpleEmailServiceMessageId
                      ,@simpleEmailServiceRequestId
                      ,@simpleEmailServiceDateTimeCreated
                      ,@contactID
                      ,@opened
                      ,@clickedThrough
                      ,@simpleQueryServiceMessageDateTimeCreated
                      ,@simpleEmailServiceMessageDateTimeCreated
                      ,@totalOpens
                      ,@totalClicks ";
        }

        public Task<bool> Delete(int campaignMessageID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CampaignMessage>> Get()
        {
            using (IDbConnection db = connection.GetOpenConnection())
            {
                return await db.QueryAsync<CampaignMessage>(GetSelectSqlStr());
            }
        }

        public Task<CampaignMessage> GetOne(int campaignMessageID)
        {
            throw new NotImplementedException();
        }

        public async Task<CampaignMessage> Insert(CampaignMessage campaignMessage)
        {
            using (IDbConnection db = connection.GetOpenConnection())
            {
                campaignMessage.campaignMessageID = await db.QuerySingleAsync<int>(GetInsertSqlStr(), campaignMessage);
                return campaignMessage;
            }
        }

        public Task<CampaignMessage> Update(CampaignMessage campaignMessage)
        {
            throw new NotImplementedException();
        }
    }
}
