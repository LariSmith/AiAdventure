namespace AiAdventure.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public Player(Guid id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public ICollection<Character> Characters { get; private set; }
    }
}
