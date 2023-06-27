namespace AiAdventure.Domain.Entities
{
    public class Proficiency
    {
        public int Id { get; private set; }
        public int CharacterId { get; private set; }
        public string Type { get; private set; }
        public string? List { get; private set; }

        internal Proficiency(int characterId, string type, string? list)
        {
            CharacterId = characterId;
            Type = type;
            List = list;
        }
    }
}
