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

        public Character GenerateCharacter(string name, string gender, string race, string @class, string background, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health, int gold, float experience, float maxExperience, int level)
        {
            var character = new Character(Id, name, gender, race, @class, background, strength, dexterity, constitution, intelligence, wisdom, charisma, hitPoints, armorClass, health, gold , experience, maxExperience, level);
            _characters.Add(character);

            return character;
        }
    }
}
