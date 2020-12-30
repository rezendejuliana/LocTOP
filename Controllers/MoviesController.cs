using Sitecore.FakeDb;
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
        // GET: Movies
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.Movies.ToList();
            var ListOfMovies = new RandomMovieViewModel() { Movie = movies };
           
           return View(ListOfMovies);
        }


        public ViewResult Details(int id)
        {
            var MovieDetail = new Movie();
            var movies = _context.Movies;
            foreach (var movie in movies)
            {
                if (movie.Id == id)
                {
                    MovieDetail = movie;
                }
            }
            return View(MovieDetail);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id); //GET
            if (movie == null)
                HttpNotFound();
            var viewModel = new MovieFormViewModel 
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieinDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieinDb.Name = movie.Name;
                movieinDb.ReleaseDate = movie.ReleaseDate;
                movieinDb.GenreId = movie.GenreId;
                movieinDb.NumberInStock = movie.NumberInStock;
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel{ Genre =genre };
            return View("MovieForm", viewModel);
        }

    }
}