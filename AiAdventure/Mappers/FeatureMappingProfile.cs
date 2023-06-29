using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class FeatureMappingProfile : Profile
    {
        public FeatureMappingProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<FeatureDto, Feature>();
        }
    }
}
