using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        //Represents a state or a behavior
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual Genre Genre { get; set; } 
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        
        public int NumberInStock { get; set; }
        [Required]
        [Display(Name = "Release Date")]

        public DateTime? ReleaseDate { get; set; }
        
        public DateTime? DateAdded { get; set; }
    }
}