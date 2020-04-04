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
        public List<Movie> Movies { get; private set; } = new List<Movie>();

        public async Task ExtractData()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://www.imdb.com/chart/moviemeter/?ref_=nv_mv_mpm");

            for (int i = 1; i <= 100; i++)
            {
                Movie movie = new Movie
                {
                    MovieId = i
                };
                Movies.Add(movie);
            }
            await GetDataFromWeb(page, "> td.titleColumn > a", MovieParameter.MovieTitle);
            await GetDataFromWeb(page, "> td.titleColumn > div", MovieParameter.TopRating);
            await GetDataFromWeb(page, "> td.titleColumn > span", MovieParameter.ReleaseYear);
                await GetDataFromWeb(page, "> td.ratingColumn.imdbRating > strong", MovieParameter.ImdbRating);
                //await GetDataFromWeb(page, "", MovieParameter.TopRating);

            foreach (var item in Movies)
            {
                item.PrintMovie();
            }
        }
        private async Task GetDataFromWeb(Page page, string selectorEnding, MovieParameter parameter)
        {
            string result = "";
            for (int i = 1; i <= 100; i++)
            {
                if (parameter == MovieParameter.TopRating)
                {
                    try
                    {
                        var imdbCard = await page.WaitForXPathAsync($"//*[@id=\"main\"]/div/span/div/div/div[3]/table/tbody/tr[{i}]/td[2]/text()");
                        var extractedData = await imdbCard.EvaluateFunctionAsync<string>("t => t.textContent", imdbCard);
                        result = Regex.Replace(extractedData, @"\s+", string.Empty);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"No {parameter}.");
                    }
                }
                else
                {
                    try
                    {
                        var imdbCard = await page.WaitForSelectorAsync($"#main > div > span > div > div > div.lister > table > tbody > tr:nth-child({i}){selectorEnding}");
                        var extractedData = await imdbCard.EvaluateFunctionAsync<string>("t => t.textContent", imdbCard);
                        result = extractedData.Replace("(", "").Replace(")", "");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"No {parameter}.");
                    }
                    
                }
                switch (parameter)
                {
                    case MovieParameter.ImdbRating:
                        Movies[i-1].ImdbRating = result;
                        break;
                    case MovieParameter.MovieTitle:
                        Movies[i-1].MovieTitle = result;
                        break;
                    case MovieParameter.ReleaseYear:
                        Movies[i-1].ReleaseYear = result;
                        break;
                    case MovieParameter.TopRating:
                        Movies[i-1].TopRating = result;
                        break;
                }
            }
        }
        public enum MovieParameter
        {
            MovieId,
            MovieTitle,
            TopRating,
            ImdbRating,
            ReleaseYear
        }
    }
}
