using Fenix.ESender.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Data
{
    public interface ICampaignRepository
    {
        IEnumerable<Campaign> Get(Campaign campaign = null);
        IEnumerable<Campaign> GetSecheduledByPartyId(int partyId);
        IEnumerable<Campaign> GetSentByPartyId(int partyId);
        Task<Campaign> Insert(Campaign campaign);
        Task<Campaign> Update(Campaign campaign);
        Campaign GetOne(int campaignID);
        Task<bool> Delete(int campaignID);
    }
}
