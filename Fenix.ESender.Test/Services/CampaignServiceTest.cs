using Fenix.ESender.Data;
using Fenix.ESender.Models;
using Fenix.ESender.Services;
using Fenix.ESender.SQS;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.Test
{
    public class CampaignServiceTest
    {
        private Campaign _campaign;
        private CampaignService _service;

        private Mock<ICampaignRepository> _mockCampaingRepository;
        private Mock<ICampaignMessageRepository> _mockCampaingMessageRepository;
        private Mock<ICampaignSQSMessage> _mockCampaingSQSMessage;

        [SetUp]
        public void Setup()
        {
            _mockCampaingRepository = new Mock<ICampaignRepository>();
            _mockCampaingMessageRepository = new Mock<ICampaignMessageRepository>();
            _mockCampaingSQSMessage = new Mock<ICampaignSQSMessage>();
            _campaign = new Campaign();
            _service = new CampaignService(_mockCampaingRepository.Object, _mockCampaingMessageRepository.Object, _mockCampaingSQSMessage.Object);

            _campaign = new Campaign();
            _campaign.partyID = 1;
            _campaign.assetIdentifier = Guid.NewGuid();
            _campaign.dateTimeScheduled = DateTime.Now.AddDays(1);
        }

        [Test]
        public void Get_GetSentByPartyId_Success()
        {
            //Arrange
            int partyID = 1;

            List<Campaign> resultList = new List<Campaign>();
            resultList.Add(GetRandomCampaign(partyID));
            resultList.Add(GetRandomCampaign(partyID));
            resultList.Add(GetRandomCampaign(partyID));

            _mockCampaingRepository.Reset();
            _mockCampaingRepository.Setup(p => p.GetSentByPartyId(It.IsAny<int>())).Returns(resultList);

            //Act 
            var response = _service.GetSentByPartyId(partyID);

            //Assert
            Assert.IsTrue(response.Count() > 0);
            Assert.AreEqual(partyID, response.ToList<Campaign>().FirstOrDefault().partyID);            
        }

        [Test]
        public void Insert_Campaign_Success()
        {
            //Arrange
            Campaign campaignResponse = new Campaign();
            campaignResponse.campaignID = 101;

            _mockCampaingRepository.Reset();
            _mockCampaingRepository.Setup(p => p.Insert(_campaign)).ReturnsAsync(campaignResponse);

            List<int> requestContactIds = new List<int>();
            requestContactIds.Add(1);
            requestContactIds.Add(2);

            //Act
            Task<(int campaignId, List<string> errors)> response = _service.SendCampaingEmail(_campaign, requestContactIds);
            response.Wait();

            //Assert
            Assert.AreEqual(campaignResponse.campaignID.GetValueOrDefault(), response.Result.campaignId);
            Assert.IsTrue(response.Result.errors.Count <= 0);
        }

        private Campaign GetRandomCampaign(int? partyId)
        {
            List<int> contactIds = new List<int>();

            for (int i = 0; i <= Faker.RandomNumber.Next(1, 10); i++)
            {
                contactIds.Add(Faker.RandomNumber.Next(10, 1000));
            }

            return new Campaign()
            {
                campaignID = Faker.RandomNumber.Next(1, 100000)
                ,
                identifier = Guid.NewGuid()
                ,
                partyID = partyId ?? Faker.RandomNumber.Next(0, 5)
                ,
                name = Faker.Internet.DomainName()
                ,
                utm_Medium = Faker.Internet.DomainWord()
                ,
                utm_Source = Faker.Internet.DomainWord()
                ,
                utm_Term = Faker.Company.BS()
                ,
                url = Faker.Internet.Url()
                ,
                dateTimeCreated = DateTime.Now.AddDays(Faker.RandomNumber.Next(-20, -1))
                ,
                assetIdentifier = Guid.NewGuid()
                ,
                numberOfContacts = contactIds.Count
                ,
                partyCampaignId = Faker.RandomNumber.Next(1, 20)
                ,
                dateTimeScheduled = DateTime.Now.AddDays(Faker.RandomNumber.Next(1, 100))
                ,
                dateTimeDeleted = null
                ,
                dateTimeSent = null
                ,
                isQueued = true
                ,
                emailTemplateId = Faker.RandomNumber.Next(1, 20)
                ,
                personaId = Faker.RandomNumber.Next(1, 10000)
                ,
                emailTypeId = Faker.RandomNumber.Next(1, 20)
                ,
                masterCampaignId = Faker.RandomNumber.Next(1, 20)
                ,
                sendAsType = Faker.RandomNumber.Next(1, 20)
                ,
                apiClient = Guid.NewGuid()

            };
        }
    }
}