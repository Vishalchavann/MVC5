using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Shrek!!!" };

            var Customers = new List<Customers>
            {
                new Customers { Name = "Customer 1"},
                new Customers { Name = "Customer 2"},
                new Customers { Name = "Customer 3"},
                new Customers { Name = "Customer 4"}
            };


            var MovieViewModel = new RandomMovieViewModel
            {
                Movie = movies,
                Customers = Customers
            };

            return View(movies);

        }


    }
}