using System.ComponentModel.DataAnnotations;

namespace RegistrationUsingSession.DTOs
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Pass { get; set; } = null!;
    }
}
