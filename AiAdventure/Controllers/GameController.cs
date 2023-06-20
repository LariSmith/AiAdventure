using AiAdventure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OpenAI_API;

namespace AiAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController
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
        [Route("new-character")]
        public async Task<string> CreateCharacter()
        {
            //var api = new OpenAIAPI(_key);

            var request = "Generate a D&D character information. Start level 1 and 0 experience. Use this return:{\r\n  \"status\": \"success\",\r\n  \"data\": {\r\n    \"name\": \"\",\r\n    \"race\": \"\",\r\n    \"gender\": \"\",\r\n    \"class\": \"\",\r\n    \"level\": 0,\r\n    \"health\": 0,\r\n    \"experience\": 0.00,\r\n    \"maxExperience\": 0.00,\r\n    \"strength\": 0,\r\n    \"dexterity\": 0,\r\n    \"Constitution\": 0,\r\n    \"Intelligence\": 0,\r\n    \"Wisdom\": 0,\r\n    \"Charisma\": 0,\r\n    \"background\": \"\",\r\n    \"skills\": {},\r\n    \"hitPoints\": 0,\r\n    \"armorClass\": 0,\r\n    \"proficiencies\": {\r\n      \"armor\": [],\r\n      \"weapons\": [],\r\n      \"tools\": [],\r\n      \"savingThrows\": [],\r\n      \"languages\": []\r\n    },\r\n    \"classFeatures\": {},\r\n    \"inventory\": {\r\n      \"itemN\" : 0,\r\n      \"itemN+1\": 0\r\n    },\r\n    \"backgroundFeature\": \"\"\r\n  }\r\n}";
            //var chat = api.Chat.CreateConversation();
            //chat.AppendUserInput(request);
            //string response = await chat.GetResponseFromChatbotAsync();

            var response = "{\r\n\"status\": \"success\",\r\n\"data\": {\r\n\"name\": \"Eldred Moonshadow\",\r\n\"race\": \"Elf\",\r\n\"gender\": \"Male\",\r\n\"class\": \"Rogue\",\r\n\"level\": 5,\r\n\"health\": 42,\r\n\"experience\": 3450.00,\r\n\"maxExperience\": 5000.00,\r\n\"strength\": 10,\r\n\"dexterity\": 18,\r\n\"Constitution\": 14,\r\n\"Intelligence\": 14,\r\n\"Wisdom\": 12,\r\n\"Charisma\": 16,\r\n\"background\": \"Criminal\",\r\n\"skills\": {\r\n\"Acrobatics\": 7,\r\n\"Stealth\": 10,\r\n\"Sleight of Hand\": 8,\r\n\"Investigation\": 4,\r\n\"Perception\": 5,\r\n\"Deception\": 7\r\n},\r\n\"hitPoints\": 31,\r\n\"armorClass\": 15,\r\n\"proficiencies\": {\r\n\"armor\": [],\r\n\"weapons\": [\"Dagger\", \"Shortbow\", \"Rapier\"],\r\n\"tools\": [\"Thieves' Tools\"],\r\n\"savingThrows\": [\"Dexterity\", \"Intelligence\"],\r\n\"languages\": [\"Common\", \"Elvish\", \"Thieves' Cant\"]\r\n},\r\n\"classFeatures\": {\r\n\"Sneak Attack\": \"1d6\",\r\n\"Cunning Action\": true,\r\n\"Uncanny Dodge\": true\r\n},\r\n\"inventory\": {\r\n\"Dagger\": 3,\r\n\"Shortbow\": 1,\r\n\"Arrows\": 20,\r\n\"Thieves' Tools\": 1,\r\n\"Potion of Healing\": 2\r\n},\r\n\"backgroundFeature\": \"Criminal Contact\"\r\n}\r\n}";
            var json = JObject.Parse(response);
            var character = _characterService.Create(json);

            return response;

        }
    }
}
