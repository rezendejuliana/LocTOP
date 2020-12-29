﻿using System;
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

    }
}