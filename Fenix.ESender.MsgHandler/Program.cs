using System;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Fenix.ESender.Data;
using Fenix.ESender.Models;

namespace Fenix.ESender.MsgHandler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start Processing Msgs!");

            var client = new AmazonSQSClient(RegionEndpoint.USEast2);
            var request = new ReceiveMessageRequest(){ QueueUrl = "https://sqs.us-east-2.amazonaws.com/658005288860/SimpleQueue" };

            IConnectionFactory connection = new SqlConnectionFactory("Data Source=(local);Initial Catalog=ESender;Persist Security Info=True;User ID=sender;Password=Sender@123;");
            CampaignMessageRepository campaingMessageRepository = new CampaignMessageRepository(connection);

            while (true)
            {
                var response = await client.ReceiveMessageAsync(request);

                foreach (var message in response.Messages)
                {
                    Console.WriteLine(message.Body);

                    CampaignMessage campaignMessage= JsonSerializer.Deserialize<CampaignMessage>(message.Body);

                    try
                    {
                        var result = await campaingMessageRepository.Insert(campaignMessage);

                        if (result.campaignMessageID.HasValue)
                        {
                            Console.WriteLine("Message processed - ########");
                            await client.DeleteMessageAsync("https://sqs.us-east-2.amazonaws.com/658005288860/SimpleQueue", message.ReceiptHandle);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error processing message##########");
                    }                    
                }
            }
        }
    }
}
