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

        public List<Movie> movies = new List<Movie>
        {
            new Movie{ Id =1,Name ="Sherk"},
            new Movie{ Id =2,Name ="Toy Story"},
        };
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name ="Sherk!" };
            //return View(movie); 
            //return Content("Hellow Word");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy="name"});
            var customers = new List<Customer>
            {
                new Customer{ Name="Costomer 1"},
                new Customer{ Name="Costomer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers,
                Movie = movie
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id) {
            return Content("id= " + id);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult List() 
        {
           var viewModel = new RandomMovieViewModel
            {
                Movies = movies,
                Customers = null,
                Movie = null
            };
            
            return View(viewModel);
        }

        public ActionResult Details(int id) 
        {
            var movie = movies.FindLast(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


    }
}