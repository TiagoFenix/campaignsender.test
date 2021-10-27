using AutoMapper;
using Fenix.ESender.API.Models;
using Fenix.ESender.API.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fenix.ESender.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _service;
        private readonly ILogger<CampaignController> _logger;
        private readonly IMapper _mapper;


        public CampaignController(ICampaignService service, ILogger<CampaignController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get() => Ok(await _service.Get());

        [HttpGet]
        [Route("scheduledByPartyId/{partyId:int}")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSecheduledByPartyId([FromRoute] int partyId) => Ok(await _service.GetSecheduledByPartyId(partyId));

        [HttpGet]
        [Route("sentByPartyId/{partyId:int}")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSentByPartyId([FromRoute] int partyId) => Ok(await _service.GetSentByPartyId(partyId));


        [HttpGet]
        [Route("byParty/{partyId:int}")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByPartyId([FromRoute] int partyId) => Ok(await _service.Get());

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendEmailCampaign([FromBody] CampaignInsertRequestDTO request)
        {
            var validator = new CampaignInsertResquestValidator();
            var result = validator.Validate(request);
            if (result.IsValid)
            {
                Campaign newCampaing = _mapper.Map<Campaign>(request);
                return Ok(_mapper.Map<CampaignInsertResponseDTO>(await this._service.SendCampaingEmail(newCampaing, request.contactIds)));
            }                

            return BadRequest(result.Errors);
        }

        [HttpGet]
        [Route("{campaignID:int}/cancel")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CancelEmailCampaign([FromRoute] int campaignID)
        {
            Campaign campaing = await _service.GetOne(campaignID);

            //TODO: Refactor Validation with interception
            //Not sent yet sent. DateTimeSent not set
            if (campaing.dateTimeSent.HasValue && campaing.dateTimeSent.GetValueOrDefault() != DateTime.MinValue)
                return BadRequest("Campaing already sent.");

            return Ok(await _service.CancelCampaingEmail(campaing));
        }
    }
}
