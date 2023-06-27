namespace AiAdventure.Domain.Models
{
    public class CharacterModel
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Background { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public float Experience { get; set; }
        public float MaxExperience { get; set; }
        public int Level { get; set; }
    }
}
