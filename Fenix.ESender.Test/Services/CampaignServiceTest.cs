using Fenix.ESender.API.Data;
using Fenix.ESender.API.Models;
using Fenix.ESender.API.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.Test
{
    public class CampaignServiceTest
    {
        private Campaign _campaign;
        private CampaignService _service;
        private Mock<ICampaignRepository> _mockCampaingRepository;
        private Mock<ICampaignMessageRepository> _mockCampaingMessageRepository;

        [SetUp]
        public void Setup()
        {
            _mockCampaingRepository = new Mock<ICampaignRepository>();
            _mockCampaingMessageRepository = new Mock<ICampaignMessageRepository>();
            _campaign = new Campaign();
            _service = new CampaignService(_mockCampaingRepository.Object, _mockCampaingMessageRepository.Object);

            _campaign = new Campaign();
            _campaign.partyID = 1;
            _campaign.assetIdentifier = Guid.NewGuid();
            _campaign.dateTimeScheduled = DateTime.Now.AddDays(1);
        }

        [Test]
        public void CampaignInsert_Success()
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
    }
}