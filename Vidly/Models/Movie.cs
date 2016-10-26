using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        //[Required]
        //public string Genre { get; set; }
        
        [Display (Name="Relese Date")]
        [Required]
        public DateTime ReleseDate { get; set; }
        //[Required]
        public DateTime DateAdded { get; set; }
        [Display(Name ="Number In Stock")]
        [Required]
        public int NumberInStock { get; set; }

        public MovieGenres MovieGenres { get; set; }
        [Display(Name = "Genere")]
        public byte MovieGenresID { get; set; }

    }
}