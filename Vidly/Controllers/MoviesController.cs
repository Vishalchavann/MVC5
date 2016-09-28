using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index(int? pageIndex, string SortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";

            return Content(string.Format("pageIndex:- {0}SOrtBy:-{1}", pageIndex, SortBy));
            //return View();
        }

        public ActionResult Random()
        {
            var movies = new Movie() { Name = "Shrek!!!" };

            ViewData["Movies"] = movies;
            return View();
            //return Content("This is Content From COntroller");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home",new { page=1,SortBy="Name"});
        }

        public ActionResult Edit(int ID)
        {
            return Content("ID passes is :- " + ID);
        }

        [Route("Movies/relesed/{year}/{month : regex(\\d{4}:range(1,12))}")]
        public ActionResult ByRelesedDate(int year,int month)
        {
            return Content(year +" / " + month);
        }
    }
}