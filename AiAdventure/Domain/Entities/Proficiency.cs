namespace AiAdventure.Domain.Entities
{
    public class Proficiency
    {
        public Guid Id { get; private set; }
        public Guid CharacterId { get; private set; }
        public string Type { get; private set; }
        public string List { get; private set; }

        public Character? Character { get; private set; }

        internal Proficiency(Guid id, Guid characterId, string type, string list)
        {
            Id = id;
            CharacterId = characterId;
            Type = type;
            List = list;
        }
    }
}
