using System.ComponentModel.DataAnnotations;

namespace MoviesRate_API.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public User() { }
        
    }
}
