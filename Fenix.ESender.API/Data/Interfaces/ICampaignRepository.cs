using Fenix.ESender.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Data
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<Campaign>> Get(Campaign campaign = null);
        Task<IEnumerable<Campaign>> GetSecheduledByPartyId(int partyId);
        Task<IEnumerable<Campaign>> GetSentByPartyId(int partyId);
        Task<Campaign> Insert(Campaign campaign);
        Task<Campaign> Update(Campaign campaign);
        Task<Campaign> GetOne(int campaignID);
        Task<bool> Delete(int campaignID);
    }
}
