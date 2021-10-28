using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace Fenix.ESender.SQS
{
    public class CampaignSQSMessage : ICampaignSQSMessage
    {
        public async Task<SendMessageResponse> SendMessagAsync(string messageBody)
        {
            var client = new AmazonSQSClient(RegionEndpoint.USEast2);
            var request = new SendMessageRequest(){ QueueUrl = "https://sqs.us-east-2.amazonaws.com/658005288860/SimpleQueue", MessageBody = messageBody };
            return await client.SendMessageAsync(request);
        }
    }
}
