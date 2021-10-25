using Fenix.ESender.API.Data;
using Moq;
using NUnit.Framework;

namespace Fenix.ESender.Test
{
    public class CampaignServiceTest
    {
        [SetUp]
        public void Setup()
        {
            //Seed Data
        }

        [Test]
        public void CampaignInsert_Success()
        {
            //Arrange
            API.Models.Campaign request = new API.Models.Campaign();
            var mock = new Mock<ICampaignRepository>();
            mock.Setup(p => p.Insert(request)).ReturnsAsync(request);

            //Act


            //Assert
            Assert.Pass();
        }

        [Test]
        public void CampaignRequestDTO_Validation_Error()
        {
            //Arrange


            //Act


            //Assert
        }

        [Test]
        public void CampaignInsert_Insert10KPerformanceTest_Success()
        {
            //Arrange


            //Act


            //Assert
            Assert.Pass();
        }
    }
}