using AiAdventure.Domain.Entities;
using AiAdventure.DTOs;
using AutoMapper;

namespace AiAdventure.Mappers
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
        }
    }
}
