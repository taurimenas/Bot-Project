using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Bot
{
    class DataExtractor
    {
        private static readonly List<Movie> movies = new List<Movie>();

        public static async Task<List<Movie>> ExtractData()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://www.imdb.com/chart/moviemeter/?ref_=nv_mv_mpm");
            var imdbCard = await page.WaitForSelectorAsync("#main > div > span > div > div > div.lister > table");
            var extractedData = await imdbCard.EvaluateFunctionAsync<string>("t => t.textContent", imdbCard);
            var bigString = Regex.Replace(extractedData, @"\s+", string.Empty);
            var movieStrings = bigString.Split(new string[] { "Seen" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var movieString in movieStrings)
            {
                var propertyList = movieString.Split(new string[] { "(", ")", "12345678910NOTYETRELEASED" }, StringSplitOptions.None);
                var movie = new Movie
                {
                    MovieTitle = propertyList[0],
                    ReleaseYear = propertyList[1],
                    TopRating = propertyList[2],
                    ImdbRating = propertyList[4]
                };
                movies.Add(movie);
            }
            return movies;
        }
    }
}
