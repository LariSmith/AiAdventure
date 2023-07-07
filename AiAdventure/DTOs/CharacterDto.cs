using Microsoft.VisualBasic;

namespace AiAdventure.DTOs
{
    public class CharacterDto
    {
        public int Id { get; set; }
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

        public ICollection<SkillDto> Skills { get; set; }
        public ICollection<ItemDto> Items { get; set; }
        public ICollection<FeatureDto> Features { get; set; }
        public ICollection<ProficiencyDto> Proficiencies { get; set; }
        public ICollection<TurnDto> Turns { get; set; }
    }
}
