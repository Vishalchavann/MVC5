﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.Entity.Core.Objects.DataClasses;

namespace Vidly.Models
{
    public class Movie1
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        //[Required]
        //public string Genre { get; set; }

        [Display(Name = "Relese Date")]
        [Required]
        public DateTime ReleseDate { get; set; }
        //[Required]

        public DateTime? DateAdded { get; set; }
        [Display(Name = "Number In Stock")]
        [Required]
        public int NumberInStock { get; set; }

        public MovieGenres MovieGenres { get; set; }
    }
}