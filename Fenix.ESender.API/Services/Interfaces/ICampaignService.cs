using Fenix.ESender.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Services
{
    public interface ICampaignService
    {
        IEnumerable<Campaign> Get(Campaign campaign = null);
        Campaign GetOne(int campaignID);        
        Task<(int campaingId, List<string> errors)> SendCampaingEmail(Campaign campaign, List<int> contactIds);
        Task<bool> CancelCampaingEmail(Campaign campaign);
        IEnumerable<Campaign> GetSecheduledByPartyId(int partyId);
        IEnumerable<Campaign> GetSentByPartyId(int partyId);
    }
}
