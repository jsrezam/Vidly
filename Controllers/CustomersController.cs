using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        public List<Customer> customers = new List<Customer>
            {
                new Customer{ id= 1 , Name="Sebastian Reza"},
                new Customer{ id= 2 , Name="Sarah Ramires"}
            };


        //[Route("Customers/Index")]
        public ActionResult Index()
        {
            

            var viewModel = new RandomMovieViewModel {
                Customers = customers,
                Movie = null
            
            };
            
            return View(viewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id,string name) 
        {
            var customer = customers.FindLast(c => c.id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

    }
}