using Fenix.ESender.Data;
using Fenix.ESender.Models;
using Fenix.ESender.SQS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fenix.ESender.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository campaingRepository;
        private readonly ICampaignMessageRepository campaingMessageRepository;
        private readonly ICampaignSQSMessage campaignSQSMessage;

        public CampaignService(ICampaignRepository campaingRepository, ICampaignMessageRepository campaingMessageRepository, ICampaignSQSMessage campaignSQSMessage)
        {
            this.campaingRepository = campaingRepository;
            this.campaingMessageRepository = campaingMessageRepository;
            this.campaignSQSMessage = campaignSQSMessage;
        }

        /// <summary>
        /// Get all Campaigns
        /// </summary>
        /// <param name="campaign">Dapper Filter Object</param>
        /// <returns></returns>
        public IEnumerable<Campaign> Get(Campaign campaign = null)
        {
            return campaingRepository.Get(campaign);
        }

        public Campaign GetOne(int campaignID)
        {
            return campaingRepository.GetOne(campaignID);
        }

        /// <summary>
        /// Sends Campaign and Campaign Message using SQS queue
        /// </summary>
        /// <param name="campaign"></param>
        /// <param name="contactIds"></param>
        /// <returns></returns>
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
                    string jsonString = JsonSerializer.Serialize(newCampaignMsg);
                    tasks.Add(campaignSQSMessage.SendMessagAsync(jsonString));
                }
                catch (Exception e)
                {
                    errors.Add(e.Message);
                }
            }

            await Task.WhenAll(tasks.ToArray());

            return (campaingId, errors);
        }

        /// <summary>
        /// Cancel Campaing Email 
        /// </summary>
        /// <param name="campaing"></param>
        /// <returns></returns>
        public async Task<bool> CancelCampaingEmail(Campaign campaing)
        {
            campaing.dateTimeDeleted = DateTime.Now;
            await campaingRepository.Update(campaing);
            return true;
        }

        /// <summary>
        /// Returns Campaign List scheduled by PartyId
        /// </summary>
        /// <param name="partyId"></param>
        /// <returns></returns>
        public IEnumerable<Campaign> GetSecheduledByPartyId(int partyId)
        {
            return campaingRepository.GetSecheduledByPartyId(partyId);
        }

        /// <summary>
        /// Returns Campaign List already sent by PartyId
        /// </summary>
        /// <param name="partyId"></param>
        /// <returns></returns>
        public IEnumerable<Campaign> GetSentByPartyId(int partyId)
        {
            return campaingRepository.GetSentByPartyId(partyId);
        }
    }
}
