using Fenix.ESender.Data;
using Fenix.ESender.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.Services
{
    public class CampaignMessageService : ICampaignMessageService
    {
        private ICampaignMessageRepository repository;

        public CampaignMessageService(ICampaignMessageRepository repository)
        {
                this.repository = repository;
        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CampaignMessage>> Get()
        {
            return await repository.Get();
        }

        public Task<CampaignMessage> GetOne()
        {
            throw new NotImplementedException();
        }

        public Task<CampaignMessage> Insert()
        {
            throw new NotImplementedException();
        }

        public Task<CampaignMessage> Update()
        {
            throw new NotImplementedException();
        }
    }
}
