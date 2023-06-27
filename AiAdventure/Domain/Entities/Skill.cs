namespace AiAdventure.Domain.Entities
{
    public class Skill
    {
        public int Id { get; private set; }
        public int CharacterId { get; private set; }
        public string Description { get; private set; }
        public int Points { get; private set; }

        internal Skill(int characterId, string description, int points)
        {
            CharacterId = characterId;
            Description = description;
            Points = points;
        }
    }
}
