using System.ComponentModel.DataAnnotations;

namespace MoviesRate_API.Models
{
    public class Movie
    {
        [Key]
        public string MovieId { get; set; }
        [Required]
        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }
        [Required]
        public string Year { get; set;}
        [Required]
        public string Director { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(250)]
        [Required]
        public string Poster { get; set; }

        public Movie() { }


    }
}
