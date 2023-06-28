﻿using AiAdventure.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace AiAdventure.Interfaces.Services
{
    public interface ICharacterService
    {
        Task<Character> CreateCharacter(JObject character, int playerId);
        Task<Character> GetCharacter(int characterId);
        Task<IEnumerable<Character>> GetAllCharacters(int playerId);
        Character AddSkill(JObject skillsJson, Character character);
        Character AddProficiency(JObject proficienciesJson, Character character);
        Character AddFeature(JObject featureJson, Character character);
        Character AddItem(JObject itemJson, Character character);
    }
}
