using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Bot
{
    public class MovieDb
    {
        public List<Movie> Movies = new List<Movie>();
        public MovieDb(List<Movie> movies)
        {
            Movies = movies;
        }
        public void AddData()
        {
            using (var db = new MovieContext())
            {
                for (int i = 0; i < 100; i++)
                {
                    var movie = new Movie { MovieTitle = Movies[i].MovieTitle, ImdbRating = Movies[i].ImdbRating, ReleaseYear = Movies[i].ReleaseYear, TopRating = Movies[i].TopRating };
                    db.Movies.Add(movie);
                    db.SaveChanges();
                }
            }
        }
    }
}





