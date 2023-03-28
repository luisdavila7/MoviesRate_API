using System.ComponentModel.DataAnnotations;

namespace MoviesRate_API.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [Required]
        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public string Year { get; set;}
        [Required]
        public string Director { get; set; }

        public Movie() { }


    }
}
