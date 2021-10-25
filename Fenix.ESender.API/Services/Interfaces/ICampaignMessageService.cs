using Fenix.ESender.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Services
{
    public interface ICampaignMessageService
    {
        Task<IEnumerable<CampaignMessage>> Get();
        Task<CampaignMessage> Insert();
        Task<CampaignMessage> Update();
        Task<CampaignMessage> GetOne();
        Task<bool> Delete();
    }
}
