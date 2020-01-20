using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Exchange { get; set; }

        [Required]
        public string Ticker { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]{2}.+$", ErrorMessage = "The first two chars must be letters")]
        //[Remote("IsIsinExist", "Validation", ErrorMessage = "ISIN is already exist.")]
        public string Isin { get; set; }
        
        public string Website { get; set; }
    }
}
