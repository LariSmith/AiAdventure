namespace AiAdventure.Domain.Entities
{
    public class Turn
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int Number { get; set; }
        public string Weather { get; set; }
        public string Scene { get; set; }
        public int CurrentDay { get; set; }
        public string PeriodDay { get; set; }

        public Character Character { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
