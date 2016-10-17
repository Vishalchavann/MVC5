using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult GetCustomer()
        {
            var objCustomer = _context.Customers.Include(c => c.MemberShipType).ToList();

            return View(objCustomer);
        }
        //private IEnumerable<Customers> GetCustomerList()
        //{

        //    return new List<Customers>
        //    {
        //        new Customers{ ID=0,Name = "Customer 1"},
        //        new Customers{ ID=1, Name = "Customer 2"},
        //        new Customers{ ID=2,Name = "Customer 3"},
        //        new Customers{ ID=3,Name = "Customer 4"},
        //        new Customers{ ID=4,Name = "Customer 5"},
        //        new Customers{ ID=5,Name = "Customer 6"},
        //        new Customers{ ID=6,Name = "Customer 7"},
        //        new Customers{ ID=7,Name = "Customer 8"}

        //    };
        //}

        public ActionResult Details(int ID)
        {
            //var customerDet = _context.Customers.SingleOrDefault(c => c.ID.Equals(ID));
            var customerDet = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.ID.Equals(ID));
            return View(customerDet);
        }
    }
}