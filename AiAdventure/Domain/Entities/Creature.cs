namespace AiAdventure.Domain.Entities
{
    public class Creature
    {
        public int Id { get; private set; }
        public int OriginalLocationId { get; private set; }
        public string Name { get; private set; }
        public string Race { get; private set; }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }
        public int HitPoints { get; private set; }
        public int ArmorClass { get; private set; }
        public int Health { get; private set; }
        public int Level { get; private set; }

        internal Creature(int originalLocationId, string name, string race, int strength, int dexterity, int constitution, int intelligence, int wisdom, int hitPoints, int armorClass, int health, int level)
        {
            OriginalLocationId = originalLocationId;
            Name = name;
            Race = race;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
            Health = health;
            Level = level;
        }
    }
}
