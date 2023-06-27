namespace AiAdventure.Domain.Entities
{
    public class Creature
    {
        public int Id { get; set; }
        public int OriginalLocationId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }

        public Location OriginalLocation { get; set; }
    }
}
