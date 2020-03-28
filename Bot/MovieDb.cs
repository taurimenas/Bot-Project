using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Bot
{
    public class MovieDb
        {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string TopRating { get; set; }
        public string ImdbRating { get; set; }
        public string ReleaseYear { get; set; }
        

        public MovieDb(string MovieTitle, string TopRating, string ImdbRating, string ReleaseYear)
        {
            this.MovieTitle = MovieTitle;
            this.TopRating = TopRating;
            this.ImdbRating = ImdbRating;
            this.ReleaseYear = ReleaseYear;
        }
        public MovieDb(int MovieId, string MovieTitle, string TopRating, string ImdbRating, string ReleaseYear)
        {
            this.MovieId = MovieId;
            this.MovieTitle = MovieTitle;
            this.TopRating = TopRating;
            this.ImdbRating = ImdbRating;
            this.ReleaseYear = ReleaseYear;
        }
        public void AddData()
        {
            using (var db = new MovieContext())
            {
                var movie = new Movie { MovieTitle = this.MovieTitle, ImdbRating = this.ImdbRating, ReleaseYear = this.ReleaseYear, TopRating = this.ReleaseYear};
                db.Movies.Add(movie);
                db.SaveChanges();

            }
        }
    }

    }





