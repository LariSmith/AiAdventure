namespace AiAdventure.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public IReadOnlyCollection<Character> Characters => _characters;

        private readonly List<Character> _characters = new List<Character>();

        private Player(Guid id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public static Player Create(Guid id, string email, string password)
        {
            return new Player(id, email, password);
        } 

        public Character GenerateCharacter(Guid id, string name, string gender, string race, string @class, string background, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health, int gold, float experience, float maxExperience, int level)
        {
            var character = new Character(id, Id, name, gender, race, @class, background, strength, dexterity, constitution, intelligence, wisdom, charisma, hitPoints, armorClass, health, gold , experience, maxExperience, level);
            _characters.Add(character);

            return character;
        }
    }
}
