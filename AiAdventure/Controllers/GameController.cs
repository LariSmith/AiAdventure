using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace AiAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICharacterService _characterService;
        private readonly string _key;

        public GameController(IConfiguration configuration, ICharacterService characterService)
        {
            _configuration = configuration;
            _key = _configuration.GetSection("OpenAi")["Key"];
            _characterService = characterService;
        }

        [HttpPost]
        [Route("new-game")]
        public async Task<IActionResult> StartGame()
        {
            try
            {
                var api = new OpenAIAPI(_key);

                var chat = await api.Chat.CreateChatCompletionAsync(new OpenAI_API.Chat.ChatRequest()
                {
                    Model = Model.AdaText,
                    Temperature = 0.1,
                    Messages = new ChatMessage[]
                    {
                        new ChatMessage(ChatMessageRole.System, _configuration.GetSection("OpenAi")["rules"]),
                        new ChatMessage(ChatMessageRole.User, "Generate Character"),
                        new ChatMessage(ChatMessageRole.Assistant, "{\r\n\"status\": \"success\",\r\n\"data\": {\r\n\"name\": \"Eldric Stoneforge\",\r\n\"race\": \"Dwarf\",\r\n\"gender\": \"Male\",\r\n\"class\": \"Fighter\",\r\n\"level\": 5,\r\n\"health\": 42,\r\n\"gold\": 250,\r\n\"experience\": 3200.00,\r\n\"maxExperience\": 5000.00,\r\n\"strength\": 16,\r\n\"dexterity\": 12,\r\n\"Constitution\": 18,\r\n\"Intelligence\": 10,\r\n\"Wisdom\": 12,\r\n\"Charisma\": 8,\r\n\"background\": \"Soldier\",\r\n\"skills\": {\r\n\"Athletics\": 5,\r\n\"Survival\": 2\r\n},\r\n\"hitPoints\": 42,\r\n\"armorClass\": 17,\r\n\"proficiencies\": {\r\n\"armor\": [\"Chain Mail\", \"Shield\"],\r\n\"weapons\": [\"Longsword\", \"Battleaxe\", \"Longbow\"],\r\n\"tools\": [],\r\n\"savingThrows\": [\"Strength\", \"Constitution\"],\r\n\"languages\": [\"Common\", \"Dwarvish\"]\r\n},\r\n\"classFeatures\": {\r\n\"Fighting Style\": \"Great Weapon Fighting\",\r\n\"Second Wind\": true,\r\n\"Action Surge\": true\r\n},\r\n\"inventory\": {\r\n\"Health Potion\": 3,\r\n\"Rations\": 10,\r\n\"Rope\": 1\r\n},\r\n\"backgroundFeature\": \"Military Rank\"\r\n}\r\n}"),
                        new ChatMessage(ChatMessageRole.User, "Generate Character"),
                        new ChatMessage(ChatMessageRole.Assistant, "{\r\n\"status\": \"success\",\r\n\"data\": {\r\n\"name\": \"Alistair\",\r\n\"race\": \"Human\",\r\n\"gender\": \"Male\",\r\n\"class\": \"Rogue\",\r\n\"level\": 3,\r\n\"health\": 24,\r\n\"gold\": 50,\r\n\"experience\": 1250.00,\r\n\"maxExperience\": 3000.00,\r\n\"strength\": 10,\r\n\"dexterity\": 18,\r\n\"Constitution\": 12,\r\n\"Intelligence\": 14,\r\n\"Wisdom\": 13,\r\n\"Charisma\": 16,\r\n\"background\": \"Criminal\",\r\n\"skills\": {\r\n\"Acrobatics\": 5,\r\n\"Sleight of Hand\": 4,\r\n\"Stealth\": 6,\r\n\"Deception\": 5,\r\n\"Insight\": 3,\r\n\"Perception\": 5\r\n},\r\n\"hitPoints\": 24,\r\n\"armorClass\": 15,\r\n\"proficiencies\": {\r\n\"armor\": [],\r\n\"weapons\": [\"Daggers\", \"Shortsword\", \"Rapier\"],\r\n\"tools\": [\"Thieves' Tools\"],\r\n\"savingThrows\": [\"Dexterity\", \"Intelligence\"],\r\n\"languages\": [\"Common\", \"Thieves' Cant\"]\r\n},\r\n\"classFeatures\": {\r\n\"Sneak Attack\": \"1d6\",\r\n\"Cunning Action\": \"Dash, Disengage, or Hide as a bonus action\",\r\n\"Roguish Archetype\": \"Assassin\"\r\n},\r\n\"inventory\": {\r\n\"Dagger\": 2,\r\n\"Shortsword\": 1,\r\n\"Thieves' Tools\": 1,\r\n\"Potion of Healing\": 2\r\n},\r\n\"backgroundFeature\": \"Criminal Contact\"\r\n}\r\n}")
                    }
                });

                var response = chat.Choices[0].Message;

                var json = JObject.Parse(response.Content);
                var character = _characterService.Create(json);

                return Ok(character);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
