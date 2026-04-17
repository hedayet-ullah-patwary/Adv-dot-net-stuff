using System.ComponentModel.DataAnnotations;

namespace IntroDTO.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int Did { get; set; }
    }
}
