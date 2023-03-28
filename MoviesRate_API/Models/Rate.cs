﻿using System.ComponentModel.DataAnnotations;

namespace MoviesRate_API.Models
{
    public class Rate
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public int Score { get; set; }
        [Required]
        [StringLength(250)]
        public string Comments { get; set; }

        public Rate() { }
    }
}
