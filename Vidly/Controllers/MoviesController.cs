using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult New()
        {
            var viewModel = new MovieViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }


        public ActionResult Edit(int id)
        {
            // Uneccessary call for database
            //Solution is to update Movie class "Genre" attribute to be nullable and add GenreId attribute to be Required
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm",viewModel);
        }


        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            // Uneccessary call for database
            //Solution is to update Movie class "Genre" attribute to be nullable and add GenreId attribute to be Required
            //movie.Genre=_context.Genres.SingleOrDefault(g =>g.Id==movie.Genre.Id);

            //FOR VALIDATION
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            //IF NOT existed in Database
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.StockNumber = movie.StockNumber;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

    }
}