using Fenix.ESender.API.Data;
using Fenix.ESender.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Fenix.ESender.API.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository campaingRepository;
        private readonly ICampaignMessageRepository campaingMessageRepository;

        public CampaignService(ICampaignRepository campaingRepository, ICampaignMessageRepository campaingMessageRepository)
        {
            this.campaingRepository = campaingRepository;
            this.campaingMessageRepository = campaingMessageRepository;
        }

        public async Task<IEnumerable<Campaign>> Get(Campaign campaign = null)
        {
            return await campaingRepository.Get(campaign);
        }

        public async Task<Campaign> GetOne(int campaignID)
        {
            return await campaingRepository.GetOne(campaignID);
        }

        public async Task<(int,List<string>)> SendCampaingEmail(Campaign campaign, List<int> contactIds)
        {
            int campaingId = 0;
            List<string> errors = new List<string>();

            var newCampaign = await campaingRepository.Insert(campaign);

            campaingId = newCampaign.campaignID.GetValueOrDefault();

            List<Task> tasks = new List<Task>();

            foreach (int contactID in contactIds)
            {
                try
                {
                    CampaignMessage newCampaignMsg = new CampaignMessage(newCampaign.campaignID, contactID);
                    tasks.Add(campaingMessageRepository.Insert(newCampaignMsg));
                }
                catch (Exception e)
                {
                    errors.Add(e.Message);
                }
            }

            await Task.WhenAll(tasks.ToArray());

            return (campaingId, errors);
        }

        public async Task<bool> CancelCampaingEmail(Campaign campaing)
        {
            campaing.dateTimeDeleted = DateTime.Now;
            await campaingRepository.Update(campaing);
            return true;
        }

        public async Task<IEnumerable<Campaign>> GetSecheduledByPartyId(int partyId)
        {
            return await campaingRepository.GetSecheduledByPartyId(partyId);
        }

        public async Task<IEnumerable<Campaign>> GetSentByPartyId(int partyId)
        {
            return await campaingRepository.GetSentByPartyId(partyId);
        }
    }
}
