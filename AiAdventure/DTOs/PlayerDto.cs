namespace AiAdventure.DTOs
{
    public class PlayerDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public ICollection<CharacterDto> Characters { get; set; }
    }
}