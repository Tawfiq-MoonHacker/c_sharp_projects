using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models.Movie;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult GetMovies()
        {
            Movie obj = new Movie();

            List<Movie> movies = obj.GetAllMovies();
            var vm = new MovieViewModel();
            vm.MoviesDetails = new List<MovieDetailsViewModel>();

            foreach(Movie movie in movies)
            {
                var movievm = new MovieDetailsViewModel();
                movievm.Name = movie.Name;
                movievm.Rating = movie.Rating;
                movievm.Genera = movie.Genera;
                movievm.Id = movie.Id;
                vm.MoviesDetails.Add(movievm);

            }

            return View("AllMovies",vm);

        }
    }
}