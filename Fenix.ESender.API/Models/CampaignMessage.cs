using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Models
{
    public class CampaignMessage
    {
        public CampaignMessage(int? campaignID, int? contactID)
        {
            this.campaignID = campaignID;
            this.contactID = contactID;
            this.identifier = Guid.NewGuid();
            this.dateTimeCreated = DateTime.Now;
        }

        public int? campaignMessageID { get; set; }
        public int? campaignID { get; set; }
        public Guid? identifier { get; set; }
        public int? simpleQueryServiceMessageId { get; set; }
        public int? simpleQueryServiceRequestId { get; set; }
        public DateTime? dateTimeCreated { get; set; }
        public int? simpleEmailServiceMessageId { get; set; }
        public int? simpleEmailServiceRequestId { get; set; }
        public DateTime? simpleEmailServiceDateTimeCreated { get; set; }
        public int? contactID { get; set; }
        public bool? opened { get; set; }
        public bool? clickedThrough { get; set; }
        public DateTime? simpleQueryServiceMessageDateTimeCreated { get; set; }
        public DateTime? simpleEmailServiceMessageDateTimeCreated { get; set; }
        public int totalOpens { get; set; }
        public int totalClicks { get; set; }
        public string simpleEmailServiceMessageIdAddress { get; set; }
    }
}
