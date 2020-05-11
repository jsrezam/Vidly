using System;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //[Route("Customers/Index")]
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();         
            return View(customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id) 
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

    }
}