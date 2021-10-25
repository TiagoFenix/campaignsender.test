using FluentValidation;
using System;

namespace Fenix.ESender.API.Models
{
    public class CampaignInsertResquestValidator : AbstractValidator<CampaignInsertRequestDTO>
    {
        public CampaignInsertResquestValidator()
        {
            RuleFor(x => x.dateTimeScheduled).NotNull()
                .WithMessage("dateTimeScheduled cannot be null.");
            RuleFor(x => x.partyID).NotNull()
                .WithMessage("partyID cannot be null.");
            RuleFor(x => x.assetIdentifier).NotNull()
                .WithMessage("assetIdentifier cannot be null.");
            RuleFor(x => x.dateTimeScheduled).Must(x => x.GetValueOrDefault() >= DateTime.Now)
                .WithMessage("Schedule cannot be in the past.");
        }
    }
}
