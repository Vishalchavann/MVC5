using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class CUstomersController : ApiController
    {

        private ApplicationDbContext _context;
        public CUstomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET Api/Customers
        public IEnumerable<CUstomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customers, CUstomerDto>);
        }

        //GET Api/Customers
        public CUstomerDto GetCustomers(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.ID.Equals(id));

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customers, CUstomerDto>(customer);
        }

        //POST Api/Customers
        [HttpPost]
        public CUstomerDto CreateCustomer(CUstomerDto customersdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CUstomerDto, Customers>(customersdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customersdto;
        }

        //PUT /Api/Customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CUstomerDto customerdto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.ID.Equals(id));
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerdto, customerInDB);

            _context.SaveChanges();
        }


        //DELETE Api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.ID.Equals(id));
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();

        }

    }
}
