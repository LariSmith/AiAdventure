using AiAdventure.Domain.Models;

namespace AiAdventure.Domain.Entities
{
    public class Player
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        public IReadOnlyCollection<Character> Characters => _characters;

        private readonly List<Character> _characters = new List<Character>();

        private Player(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }

        public static Player Create(string email, string password, string name)
        {
            return new Player(email, password, name);
        } 

        public Character GenerateCharacter(CharacterModel model)
        {
            var character = new Character(
                Id,
                model.Name,
                model.Gender,
                model.Race,
                model.Class,
                model.Background,
                model.Strength,
                model.Dexterity,
                model.Constitution,
                model.Intelligence,
                model.Wisdom,
                model.Charisma,
                model.HitPoints,
                model.ArmorClass,
                model.Health,
                model.Gold,
                model.Experience,
                model.MaxExperience,
                model.Level,
                model.Json);

            _characters.Add(character);

            return character;
        }
    }
}
