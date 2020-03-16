using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bot
    {
        public class MovieDb
        {
            static void Main(string[] args)
            {
            using (var db = new MovieContext())
                {
                    var movie = new Movie { MovieTitle = "Harry Potter" };
                    db.Movies.Add(movie);
                    db.SaveChanges();
                }
            }
        }
        public class Movie
        {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string TopRating { get; set; }
        public string ImdbRating { get; set; }
        public string ReleaseYear { get; set; }
         
             
    }
        public class MovieContext : DbContext
        {
            public DbSet<Movie> Movies { get; set; }

        }
    }





