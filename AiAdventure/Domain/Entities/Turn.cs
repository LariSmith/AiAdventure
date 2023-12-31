﻿namespace AiAdventure.Domain.Entities
{
    public class Turn
    {
        public int Id { get; private set; }
        public int CharacterId { get; private set; }
        public int Number { get; private set; }
        public string Weather { get; private set; }
        public string Scene { get; private set; }
        public int CurrentDay { get; private set; }
        public string PeriodDay { get; private set; }
        public string Commands { get; private set; }
        public string Json { get; private set; }

        public IReadOnlyCollection<Location> Locations => _locations;

        private HashSet<Location> _locations = new HashSet<Location>();

        internal Turn(int characterId, int number, string weather, string scene, int currentDay, string periodDay, string commands, string json)
        {
            CharacterId = characterId;
            Number = number;
            Weather = weather;
            Scene = scene;
            CurrentDay = currentDay;
            PeriodDay = periodDay;
            Commands = commands;
            Json = json;
        }

        public Location AddLocation(string name, int turnId, int? parentId)
        {
            var location = new Location(name, turnId, parentId);
            _locations.Add(location);
            return location;
        }


    }
}
