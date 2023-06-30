namespace AiAdventure.Domain.Entities
{
    public class NPC
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Race { get; private set; }
        public bool IsPartyMember { get; private set; }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Constitution { get; private set; }
        public int Intelligence { get; private set; }
        public int Wisdom { get; private set; }
        public int Charisma { get; private set; }
        public int HitPoints { get; private set; }
        public int ArmorClass { get; private set; }
        public int Health { get; private set; }
        public float Experience { get; private set; }
        public int Level { get; private set; }
        public int OriginalLocationId { get; private set; }

        internal NPC(string name, string race, bool isPartyMember, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int hitPoints, int armorClass, int health, float experience, int level, int originalLocationId)
        {
            Name = name;
            Race = race;
            IsPartyMember = isPartyMember;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            HitPoints = hitPoints;
            ArmorClass = armorClass;
            Health = health;
            Experience = experience;
            Level = level;
            OriginalLocationId = originalLocationId;
        }
    }
}
