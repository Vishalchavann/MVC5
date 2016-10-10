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
            var objMovie = GetMovie();
            return View(objMovie);
        }

        private IEnumerable<Movie> GetMovie()
        {

            return new List<Movie>
            {
                new Movie {ID=0, Name="Movie 1"},
                new Movie {ID=1, Name="Movie 2"},
                new Movie {ID=2, Name="Movie 3"},
                new Movie {ID=3, Name="Movie 4"},
                new Movie {ID=4,Name="Movie 5"},
                new Movie {ID=5,Name="Movie 6"}

            };
        }

        public ActionResult Details(int ID)
        {
            var customerDet = GetMovie().SingleOrDefault(c => c.ID.Equals(ID));
            

            if (customerDet != null)
            {
                return View(customerDet);
               
            }
            else
            {
                ModelState.AddModelError("Error", "Specified row does not exist.");
                return Content("Not Exist!!!");
            }
        }

    }
}