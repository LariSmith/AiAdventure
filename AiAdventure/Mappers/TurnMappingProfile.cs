using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class TurnMappingProfile : Profile
    {
        public TurnMappingProfile()
        {
            CreateMap<Turn, TurnDto>();
            CreateMap<TurnDto, Turn>();
        }
    }
}
