using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models.Movie
{
    public class Movie
    {
        public int Rating { get; set; }
        public int Id { get; set; }
        public string Genera { get; set; }
        public string Name { get; set; }
        public List<Movie> GetAllMovies()
        {
            var batman = CreateMovie(1, 8, "Action", "Batman");
            var shrek = CreateMovie(2, 9, "Drama", "Shrek");
            var superman = CreateMovie(3, 10, "Action", "Superman");
            var movies = new List<Movie>();
            movies.Add(batman);
            movies.Add(superman);
            movies.Add(shrek);
            return movies;

        }
        public static Movie CreateMovie(int id,int rating,string genera,string name)
        {
            var movie = new Movie();
            movie.Id = id;
            movie.Rating = rating;
            movie.Genera = genera;
            movie.Name = name;
            return movie;
        }

    }
}