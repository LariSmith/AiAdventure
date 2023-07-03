using AiAdventure.Interfaces.Services;
using Newtonsoft.Json.Linq;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace AiAdventure.Services
{
    public class ChatService : IChatService
    {
        private readonly IConfiguration _configuration;
        private readonly string _key;

        public ChatService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = _configuration.GetSection("OpenAi")["Key"];
        }

        public async Task<JObject> GenerateCharacterJson()
        {
            var api = new OpenAIAPI(_key);

            string expectedResponseCharacter1 = @"{
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
            string expectedResponseCharacter2 = @"{
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

            var chatCharacter = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 1100,
                Messages = new ChatMessage[]
                {
                        new ChatMessage(ChatMessageRole.System, _configuration.GetSection("OpenAi")["rulesNewCharacter"]),
                        new ChatMessage(ChatMessageRole.User,  "Generate Character"),
                        new ChatMessage(ChatMessageRole.Assistant, expectedResponseCharacter1),
                        new ChatMessage(ChatMessageRole.User, "Generate Character"),
                        new ChatMessage(ChatMessageRole.Assistant, expectedResponseCharacter2),
                        new ChatMessage(ChatMessageRole.User, "Generate Character")
                }
            });

            var CharacterResponse = chatCharacter.Choices[0].Message.Content;
            var characterJson = JObject.Parse(CharacterResponse);

            return characterJson;
        }

        public async Task<JObject> GenerateTurnJson(string character)
        {
            var api = new OpenAIAPI(_key);

            string expectedResponseTurn1 = @"{
                                              ""status"": ""success"",
                                              ""data"": {
                                                ""turn_number"": 1,
                                                ""time_period"": ""Morning"",
                                                ""day_number"": 1,
                                                ""weather"": ""Clear"",
                                                ""location"": ""The Village of Oakmere"",
                                                ""gold"": 10,
                                                ""quests"": [],
                                                ""npcs"": [],
                                                ""creatures"": [],
                                                ""game_scene_description"": ""You stand in the peaceful village of Oakmere. The quaint cottages and blooming gardens create a serene atmosphere. The soft rays of the morning sun filter through the leaves of ancient oak trees."",
                                                ""commands"": [""Explore the village"", ""Talk to villagers"", ""Visit the local tavern"", ""Check your inventory""]
                                              }
                                            }";
            string expectedResponseTurn2 = @"{
                                              ""status"": ""success"",
                                              ""data"": {
                                                ""turn_number"": 12,
                                                ""time_period"": ""Morning"",
                                                ""day_number"": 3,
                                                ""weather"": ""Sunny"",
                                                ""location"": ""The City of Eldoria"",
                                                ""gold"": 150,
                                                ""quests"": [
                                                  {
                                                    ""name"": ""The Lost Artifact"",
                                                    ""description"": ""Retrieve the ancient artifact from the ruins of the Forbidden Temple.""
                                                  },
                                                  {
                                                    ""name"": ""The Missing Heir"",
                                                    ""description"": ""Find and rescue the missing heir of the noble family.""
                                                  }
                                                ],
                                                ""npcs"": [
                                                  {
                                                    ""name"": ""Captain Marcus"",
                                                    ""description"": ""A seasoned captain of the city guard. He has an important task for you.""
                                                  },
                                                  {
                                                    ""name"": ""Lena the Alchemist"",
                                                    ""description"": ""A knowledgeable alchemist who sells potions and magical ingredients.""
                                                  }
                                                ],
                                                ""creatures"": [
                                                  {
                                                    ""name"": ""Goblin"",
                                                    ""description"": ""Small, green-skinned humanoid creatures known for their mischief and thievery.""
                                                  },
                                                  {
                                                    ""name"": ""Dire Wolf"",
                                                    ""description"": ""A large and aggressive wolf with enhanced strength and size.""
                                                  }
                                                ],
                                                ""game_scene_description"": ""You find yourself in the bustling city of Eldoria. The streets are filled with merchants, adventurers, and city guards going about their daily routines. The sun shines brightly overhead, casting a warm glow on the cobblestone streets."",
                                                ""commands"": [""Talk to Captain Marcus"", ""Visit Lena's Alchemy Shop"", ""Check inventory"", ""Continue exploring""]
                                              }
                                            }";

            var chatFirstTurn = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.1,
                MaxTokens = 1100,
                Messages = new ChatMessage[]
                {
                        new ChatMessage(ChatMessageRole.System, _configuration.GetSection("OpenAi")["rulesNewGame"]),
                        new ChatMessage(ChatMessageRole.System, $"This is the character: {character}"),
                        new ChatMessage(ChatMessageRole.User,  "Generate Turn"),
                        new ChatMessage(ChatMessageRole.Assistant, expectedResponseTurn1),
                        new ChatMessage(ChatMessageRole.User, "Generate Turn"),
                        new ChatMessage(ChatMessageRole.Assistant, expectedResponseTurn2),
                        new ChatMessage(ChatMessageRole.User, "Generate Turn")
                }
            });

            var turnResponse = chatFirstTurn.Choices[0].Message.Content;
            var turnJson = JObject.Parse(turnResponse);

            return turnJson;
        }
    }
}
