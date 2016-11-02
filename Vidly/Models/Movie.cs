using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity.Core.Objects.DataClasses;

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

        [Display(Name = "Relese Date")]
        [Required]
        [DefaultValue(typeof(DateTime), "DateTime.MinValue ")]
        public DateTime ReleseDate { get; set; }
        //[Required]

        public DateTime DateAdded { get; set; }
        [Display(Name = "Number In Stock")]
        [Required]
        [DefaultValue("0")]
        [Range(1,20,ErrorMessage ="The Field number in stock must be netween 1 to 20")]
        public int NumberInStock { get; set; }

        public MovieGenres MovieGenres { get; set; }
        [Display(Name = "Genere")]
        public byte MovieGenresID { get; set; }

    }
}