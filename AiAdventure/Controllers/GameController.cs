using AiAdventure.Domain.Entities;
using AiAdventure.Interfaces;
using Azure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using System.Data;

namespace AiAdventure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Player")]
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
                var playerId = int.Parse(User.FindFirst("sid")?.Value);
                var api = new OpenAIAPI(_key);

                string expectedResponse1 = @"{
                                    ""status"": ""success"",
                                    ""data"": {
                                        ""name"": ""Eldred Moonshadow"",
                                        ""race"": ""Elf"",
                                        ""gender"": ""Male"",
                                        ""class"": ""Rogue"",
                                        ""level"": 5,
                                        ""health"": 42,
                                        ""experience"": 3450.00,
                                        ""maxExperience"": 5000.00,
                                        ""strength"": 10,
                                        ""dexterity"": 18,
                                        ""Constitution"": 14,
                                        ""Intelligence"": 14,
                                        ""Wisdom"": 12,
                                        ""Charisma"": 16,
                                        ""background"": ""Criminal"",
                                        ""skills"": {
                                            ""Acrobatics"": 7,
                                            ""Stealth"": 10,
                                            ""Sleight of Hand"": 8,
                                            ""Investigation"": 4,
                                            ""Perception"": 5,
                                            ""Deception"": 7
                                        },
                                        ""hitPoints"": 31,
                                        ""armorClass"": 15,
                                        ""proficiencies"": {
                                            ""armor"": [],
                                            ""weapons"": [""Dagger"", ""Shortbow"", ""Rapier""],
                                            ""tools"": [""Thieves' Tools""],
                                            ""savingThrows"": [""Dexterity"", ""Intelligence""],
                                            ""languages"": [""Common"", ""Elvish"", ""Thieves' Cant""]
                                        },
                                        ""classFeatures"": {
                                            ""Sneak Attack"": ""1d6"",
                                            ""Cunning Action"": true,
                                            ""Uncanny Dodge"": true
                                        },
                                        ""inventory"": {
                                            ""Dagger"": 3,
                                            ""Shortbow"": 1,
                                            ""Arrows"": 20,
                                            ""Thieves' Tools"": 1,
                                            ""Potion of Healing"": 2
                                        },
                                        ""backgroundFeature"": ""Criminal Contact""
                                    }
                                }";
                string expectedResponse2 = @"{
                                                ""status"": ""success"",
                                                ""data"": {
                                                    ""name"": ""Alistair"",
                                                    ""race"": ""Human"",
                                                    ""gender"": ""Male"",
                                                    ""class"": ""Rogue"",
                                                    ""level"": 3,
                                                    ""health"": 24,
                                                    ""gold"": 50,
                                                    ""experience"": 1250.00,
                                                    ""maxExperience"": 3000.00,
                                                    ""strength"": 10,
                                                    ""dexterity"": 18,
                                                    ""Constitution"": 12,
                                                    ""Intelligence"": 14,
                                                    ""Wisdom"": 13,
                                                    ""Charisma"": 16,
                                                    ""background"": ""Criminal"",
                                                    ""skills"": {
                                                        ""Acrobatics"": 5,
                                                        ""Sleight of Hand"": 4,
                                                        ""Stealth"": 6,
                                                        ""Deception"": 5,
                                                        ""Insight"": 3,
                                                        ""Perception"": 5
                                                    },
                                                    ""hitPoints"": 24,
                                                    ""armorClass"": 15,
                                                    ""proficiencies"": {
                                                        ""armor"": [],
                                                        ""weapons"": [""Daggers"", ""Shortsword"", ""Rapier""],
                                                        ""tools"": [""Thieves' Tools""],
                                                        ""savingThrows"": [""Dexterity"", ""Intelligence""],
                                                        ""languages"": [""Common"", ""Thieves' Cant""]
                                                    },
                                                    ""classFeatures"": {
                                                        ""Sneak Attack"": ""1d6"",
                                                        ""Cunning Action"": ""Dash, Disengage, or Hide as a bonus action"",
                                                        ""Roguish Archetype"": ""Assassin""
                                                    },
                                                    ""inventory"": {
                                                        ""Dagger"": 2,
                                                        ""Shortsword"": 1,
                                                        ""Thieves' Tools"": 1,
                                                        ""Potion of Healing"": 2
                                                    },
                                                    ""backgroundFeature"": ""Criminal Contact""
                                                }
                                            }";

                var chat = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
                {
                    Model = Model.ChatGPTTurbo,
                    Temperature = 0.1,
                    MaxTokens = 1100,
                    Messages = new ChatMessage[]
                    {
                        new ChatMessage(ChatMessageRole.System, _configuration.GetSection("OpenAi")["rules"]),
                        new ChatMessage(ChatMessageRole.User,  "Generate Character"),
                        new ChatMessage(ChatMessageRole.Assistant, expectedResponse1),
                        new ChatMessage(ChatMessageRole.User, "Generate Character"),
                        new ChatMessage(ChatMessageRole.Assistant, expectedResponse2),
                        new ChatMessage(ChatMessageRole.User, "Generate Character")
                    }
                });

                var response = chat.Choices[0].Message;
                var json = JObject.Parse(response.Content);

                var character = await _characterService.CreateCharacter(json, playerId);

                return Ok(character);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
