using AutoMapper;
using Fenix.ESender.API.Models;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<CampaignInsertRequestDTO, Campaign>(); 
    }
}