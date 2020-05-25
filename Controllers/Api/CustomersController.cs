using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        //GET /api/Customers
        public IHttpActionResult GetCustomers() 
        {
            var customerDtos = _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        //GET /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();//throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(); //throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);//customerDto;
        }

        //PUT /api/Customers
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto) 
        {
            if (!ModelState.IsValid)
                return BadRequest();//throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInBb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInBb == null)
                return NotFound();//throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInBb);
            //customerInBb.Name = customerDto.Name;
            //customerInBb.BirthDate = customerDto.BirthDate;
            //customerInBb.IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter;
            //customerInBb.MemberShipTypeId = customerDto.MemberShipTypeId;

            _context.SaveChanges();

            return Ok();

        }

        //DELETE/api/Customers
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) 
        {
            var customerInBb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInBb == null)
                return NotFound();//throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInBb);
            _context.SaveChanges();
            return Ok();
        }


    }
}
