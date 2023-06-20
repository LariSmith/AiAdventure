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
        private readonly string _key;

        public GameController(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = _configuration.GetSection("OpenAi")["Key"];
        }

        [HttpPost]
        [Route("new-game")]
        public async Task<string> NewGame()
        {
            var api = new OpenAIAPI(_key);

            var request = _configuration.GetSection("OpenAi")["NewGameRequest"];

            //var chat = api.Chat.CreateConversation();
            //chat.AppendUserInput(request);
            //string response = await chat.GetResponseFromChatbotAsync();

            var response = "{\r\n  \"status\": \"success\",\r\n  \"data\": {\r\n  \"name\": \"Eldranor\",\r\n  \"race\": \"Elf\",\r\n  \"gender\": \"Male\",\r\n  \"class\": \"Rogue\",\r\n  \"level\": 5,\r\n  \"strength\": 10,\r\n  \"dexterity\": 18,\r\n  \"constitution\": 12,\r\n  \"intelligence\": 14,\r\n  \"wisdom\": 13,\r\n  \"charisma\": 16,\r\n  \"background\": \"Charlatan\",\r\n  \"skills\": {\r\n  \"acrobatics\": 5,\r\n  \"deception\": 7,\r\n  \"insight\": 4,\r\n  \"perception\": 4,\r\n  \"persuasion\": 6,\r\n  \"sleightOfHand\": 7,\r\n  \"stealth\": 9\r\n  },\r\n  \"hitPoints\": 37,\r\n  \"armorClass\": 15,\r\n  \"proficiencies\": {\r\n  \"armor\": [],\r\n  \"weapons\": [\"Dagger\", \"Shortsword\", \"Shortbow\"],\r\n  \"tools\": [\"Thieves' Tools\", \"Disguise Kit\", \"Forgery Kit\"],\r\n  \"savingThrows\": [\"Dexterity\", \"Intelligence\"],\r\n  \"languages\": [\"Common\", \"Elvish\"]\r\n  },\r\n  \"classFeatures\": {\r\n  \"sneakAttack\": \"3d6\",\r\n  \"cunningAction\": true,\r\n  \"uncannyDodge\": true\r\n  },\r\n  \"inventory\": [\"Dagger (x2)\", \"Shortsword\", \"Shortbow\", \"Thieves' Tools\", \"Disguise Kit\", \"Forgery Kit\", \"Lockpicks\", \"Fine Clothes\"],\r\n  \"backgroundFeature\": \"False Identity\"\r\n  }\r\n  }";
            var json = JObject.Parse(response);

            return response;

        }
    }
}
