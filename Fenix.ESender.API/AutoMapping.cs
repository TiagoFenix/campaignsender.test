using AutoMapper;
using Fenix.ESender.API.Models;
using System.Collections.Generic;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CampaignInsertRequestDTO, Campaign>();
        CreateMap<(int campaingId, List<string> errors), CampaignInsertResponseDTO>()
            .ForMember(d => d.campaingId, act => act.MapFrom(src => src.campaingId))
            .ForMember(d => d.errors, act => act.MapFrom(src => src.errors));
    }
}