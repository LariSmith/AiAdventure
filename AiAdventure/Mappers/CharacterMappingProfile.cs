using AiAdventure.Domain.Entities;
using AiAdventure.Domain.Models;
using AiAdventure.DTOs;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class CharacterMappingProfile : Profile
    {
        public CharacterMappingProfile()
        {
            CreateMap<Character, CharacterModel>();
            CreateMap<CharacterModel, Character>();
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterModel, CharacterDto>();
        }
    }
}
