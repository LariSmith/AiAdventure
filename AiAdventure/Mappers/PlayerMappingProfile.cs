using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();
        }
    }
}
