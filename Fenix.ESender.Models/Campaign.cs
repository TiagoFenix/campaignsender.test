using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.Models
{
    public class Campaign
    {
        public int?         campaignID        { get; set; }
        public Guid?        identifier        { get; set; }
        public int?         partyID           { get; set; }
        public string       name              { get; set; }
        public string       utm_Medium        { get; set; }
        public string       utm_Source        { get; set; }
        public string       utm_Term          { get; set; }
        public string       url               { get; set; }
        public DateTime?    dateTimeCreated   { get; set; }
        public Guid?        assetIdentifier   { get; set; }
        public int?         numberOfContacts  { get; set; }
        public int?         partyCampaignId   { get; set; }
        public DateTime?    dateTimeScheduled { get; set; }
        public DateTime?    dateTimeDeleted   { get; set; }
        public DateTime?    dateTimeSent      { get; set; }
        public bool?        isQueued          { get; set; }
        public int?         emailTemplateId   { get; set; }
        public int?         personaId         { get; set; }
        public int?         emailTypeId       { get; set; }
        public int?         masterCampaignId  { get; set; }
        public int?         sendAsType        { get; set; }
        public Guid?        apiClient         { get; set; }

        public Campaign()
        {
            this.dateTimeCreated = DateTime.Now;
        }
    }
}
