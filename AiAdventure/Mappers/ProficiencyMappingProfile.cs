using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class ProficiencyMappingProfile : Profile
    {
        public ProficiencyMappingProfile()
        {
            CreateMap<Proficiency, ProficiencyDto>();
            CreateMap<ProficiencyDto, Proficiency>();
        }
    }
}
