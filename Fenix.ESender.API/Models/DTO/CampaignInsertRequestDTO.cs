using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Models
{
    public class CampaignInsertRequestDTO
    {
        public Guid? identifier { get; set; }
        public int? partyID { get; set; }
        public string name { get; set; }
        public string utm_Medium { get; set; }
        public string utm_Source { get; set; }
        public string utm_Term { get; set; }
        public string url { get; set; }
        public Guid? assetIdentifier { get; set; }
        public int? partyCampaignId { get; set; }
        public DateTime? dateTimeScheduled { get; set; }
        public bool? isQueued { get; set; }
        public int? emailTemplateId { get; set; }
        public int? personaId { get; set; }
        public int? emailTypeId { get; set; }
        public int? masterCampaignId { get; set; }
        public int? sendAsType { get; set; }
        public Guid? apiClient { get; set; }
        public List<int> contactIds { get; set; }
    }
}
