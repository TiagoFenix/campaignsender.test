using Amazon.SQS.Model;
using System.Threading.Tasks;

namespace Fenix.ESender.SQS
{
    public interface ICampaignSQSMessage
    {
        public Task<SendMessageResponse> SendMessagAsync(string messageBody);
    }
}
