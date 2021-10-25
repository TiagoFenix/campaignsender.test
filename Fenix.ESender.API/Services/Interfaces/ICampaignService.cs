using Fenix.ESender.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Services
{
    public interface ICampaignService
    {
        Task<IEnumerable<Campaign>> Get(Campaign campaign = null);
        Task<Campaign> GetOne(int campaignID);
        Task<CampaignInsertResponseDTO> SendCampaingEmail(Campaign campaign, List<int> contactIds);
        Task<bool> CancelCampaingEmail(Campaign campaign);
        Task<IEnumerable<Campaign>> GetSecheduledByPartyId(int partyId);
        Task<IEnumerable<Campaign>> GetSentByPartyId(int partyId);
    }
}
