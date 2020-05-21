using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Microsoft.Ajax.Utilities;

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

        public ActionResult New() 
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel{ 
                Genres = genres                
            };

            return View("MovieForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie) 
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }            
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.Stock = movie.Stock;
            }

            _context.SaveChanges();

            return RedirectToAction("List","Movies");
        }

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

        //public ActionResult Edit(int id) {
        //    return Content("id= " + id);
        //}

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult List() 
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id) 
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

    }
}