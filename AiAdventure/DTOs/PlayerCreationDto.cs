using System.ComponentModel.DataAnnotations;

namespace AiAdventure.DTOs
{
    public class PlayerCreationDto
    {
        [Required(ErrorMessage = "Enter your email.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Player Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your Password.")]
        [Display(Name = "Player Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your Name.")]
        [Display(Name = "Player Name")]
        public string Name { get; set; }
    }
}
