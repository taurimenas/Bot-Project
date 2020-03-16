using System;
using System.Threading.Tasks;
using PuppeteerSharp;
using System.Threading;
using System.Collections.Generic;

namespace Bot
{
    class DataExtractor
    {
        public List<string> Titles { get; set; }
        public List<string> TopRatings { get; set; }
        public List<string> ImdbRatings { get; set; }
        public List<string> Dates { get; set; }

        public async Task ExtractData()
        {
            Titles = new List<string>();
            TopRatings = new List<string>();
            ImdbRatings = new List<string>();
            Dates = new List<string>();

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://www.imdb.com/chart/top/?ref_=nv_mv_250");


            for (int i = 1; i <= 250; i++)
            {
                var imdbCard2 = await page.WaitForXPathAsync($"//*[@id=\"main\"]/div/span/div/div/div[3]/table/tbody/tr[{i}]/td[2]/text()");
                var extractedData2 = await imdbCard2.EvaluateFunctionAsync<string>("t => t.textContent", imdbCard2);
                TopRatings.Add(extractedData2);
                //Console.WriteLine(topRatings[i - 1]);

                var imdbCard4 = await page.WaitForSelectorAsync($"#main > div > span > div > div > div.lister > table > tbody > tr:nth-child({i}) > td.titleColumn > a");
                var extractedData4 = await imdbCard4.EvaluateFunctionAsync<string>("t => t.textContent", imdbCard4);
                Titles.Add(extractedData4);
                //Console.WriteLine(Titles[i - 1]);

                var imdbCard1 = await page.WaitForSelectorAsync($"#main > div > span > div > div > div.lister > table > tbody > tr:nth-child({i}) > td.titleColumn > span");
                var extractedData1 = await imdbCard1.EvaluateFunctionAsync<string>("t => t.textContent", imdbCard1);
                Dates.Add(extractedData1);
                //Console.WriteLine(dates[i - 1]);

                var imdbCard3 = await page.WaitForSelectorAsync($"#main > div > span > div > div > div.lister > table > tbody > tr:nth-child({i}) > td.ratingColumn.imdbRating > strong");
                var extractedData3 = await imdbCard3.EvaluateFunctionAsync<string>("t => t.textContent", imdbCard3);
                ImdbRatings.Add(extractedData3);
                //Console.WriteLine(imdbRatings[i - 1]);
            }
        }
    }
}
