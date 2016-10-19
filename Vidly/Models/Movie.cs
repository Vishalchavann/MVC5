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
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        //[Required]
        //public string Genre { get; set; }
        [Required]
        public DateTime ReleseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int NumberInStock { get; set; }


        public MovieGenres MovieGenres { get; set; }
        //public byte MovieGenresID { get; set; }

    }
}