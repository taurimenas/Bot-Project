using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {
        static async Task Main()
        {
            List<Movie> Movies = await DataExtractor.ExtractData();
            MovieDb movieDb = new MovieDb(Movies);
            movieDb.AddData();
            var orderByRating = Movies.OrderBy(x => x.ImdbRating);
            var orderByYearAndRatingMovies = orderByRating.OrderBy(x => x.ReleaseYear);
            
            foreach (var item in orderByYearAndRatingMovies)
            {
                item.PrintMovie();
            }
        }
    }
}
