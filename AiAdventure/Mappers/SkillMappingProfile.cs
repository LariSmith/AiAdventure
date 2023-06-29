using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class SkillMappingProfile : Profile
    {
        public SkillMappingProfile()
        {
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();
        }
    }
}
