using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult GetMovie()
        {
            var objMovie = _context.Movies.Include(c => c.MovieGenres).ToList();
            return View(objMovie);
        }

        public ActionResult Details(int ID)
        {
            var customerDet = _context.Movies.Include(c => c.MovieGenres).SingleOrDefault(c => c.ID.Equals(ID));


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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult EditMovie(int ID)
        {
            var objMovie = _context.Movies.SingleOrDefault(c => c.ID.Equals(ID));

            if (objMovie == null)
            {
                return HttpNotFound();
            }

            var viewmodel = new MovieFormViewModel
            {
                Movie = objMovie,
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewmodel);
        }
        
        public ActionResult NewMovie()
        {
            var MovieGenres = _context.MovieGenres.ToList();
            var viewmodel = new MovieFormViewModel
            {
                MovieGenres = MovieGenres
            };
            return View("MovieForm", viewmodel);
        }

        [HttpPost]
        public ActionResult Save( Movie Movie)
        {
            if (!Movie.ID.Equals(0) && !ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel
                {
                    Movie = Movie,
                    MovieGenres = _context.MovieGenres.ToList()
                };

                return View("MovieForm", viewmodel);
            }

                if (Movie.ID == 0)
            {
                _context.Movies.Add(Movie);
                
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.ID.Equals(Movie.ID));

                movieInDb.Name = Movie.Name;
                movieInDb.ReleseDate = Movie.ReleseDate;
                movieInDb.MovieGenresID = Movie.MovieGenresID;
                movieInDb.NumberInStock = Movie.NumberInStock;
              
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                throw e;
            }
            return RedirectToAction("GetMovie", "Movies");
        }


    }


}