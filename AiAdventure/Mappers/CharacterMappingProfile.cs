using AiAdventure.Domain.Entities;
using AiAdventure.Domain.Models;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class CharacterMappingProfile : Profile
    {
        public CharacterMappingProfile()
        {
            CreateMap<Character, CharacterModel>();
            CreateMap<CharacterModel, Character>();
        }
    }
}
