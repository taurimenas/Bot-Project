using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {
        static async Task Main()
        {
            DataExtractor dataExtractor = new DataExtractor();
            await dataExtractor.ExtractData();
            List<Movie> movie = dataExtractor.Movies;
            MovieDb movieDb = new MovieDb(movie);
        }
    }
}
