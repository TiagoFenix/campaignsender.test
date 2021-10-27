using Fenix.ESender.API.Data;
using Fenix.ESender.API.Models;
using Fenix.ESender.API.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fenix.ESender.Test
{
    public class CampaignInsertResquestValidatorTest
    {
        private CampaignInsertRequestDTO _campaign;

        [SetUp]
        public void Setup()
        {
            _campaign = new CampaignInsertRequestDTO();
            _campaign.partyID = 1;
            _campaign.assetIdentifier = Guid.NewGuid();
            _campaign.dateTimeScheduled = DateTime.Now.AddDays(1);
        }


        [Test]
        public void CampaignRequestDTO_Validation_PartID_Null_Error()
        {
            //Arrange
            _campaign.partyID = null;
            var validator = new CampaignInsertResquestValidator();

            //Act
            var result = validator.Validate(_campaign);

            //Assert
            Assert.IsFalse(result.IsValid);
            Assert.Contains("partyID cannot be null.", result.Errors.Select(x => x.ErrorMessage).ToArray());
        }
    }
}