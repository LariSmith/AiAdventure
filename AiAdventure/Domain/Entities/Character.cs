namespace AiAdventure.Domain.Entities
{
    public class Character
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public string Class { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Health { get; set; }
        public float Experience { get; set; }
        public int Level { get; set; }
    }
}
