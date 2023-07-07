namespace AiAdventure.Domain.Entities
{
    public class GameLog
    {
        public int Id { get; private set; }
        public string Action { get; private set; }
        public int CharacterId { get; private set; }

        internal GameLog(string action,int characterId)
        {
            Action = action;
            CharacterId = characterId;
        }
    }
}
