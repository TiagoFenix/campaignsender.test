using Fenix.ESender.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Data
{
    public interface ICampaignMessageRepository
    {
        Task<IEnumerable<CampaignMessage>> Get();
        Task<CampaignMessage> Insert(CampaignMessage campaignMessage);
        Task<CampaignMessage> Update(CampaignMessage campaignMessage);
        Task<CampaignMessage> GetOne(int campaignMessageID);
        Task<bool> Delete(int campaignMessageID);
    }
}
