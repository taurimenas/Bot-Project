using System;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Bot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("https://www.amazon.com/");

            var searchBox = await page.WaitForSelectorAsync("#twotabsearchtextbox");
            await searchBox.TypeAsync("smartphone");
            var searchBtn = await page.WaitForSelectorAsync("#nav-search > form > div.nav-right > div > input");
            await searchBtn.ClickAsync();

            var fElementText = await page.WaitForSelectorAsync("#search > div.s-desktop-width-max.s-desktop-content.sg-row > div.sg-col-20-of-24.sg-col-28-of-32.sg-col-16-of-20.sg-col.sg-col-32-of-36.sg-col-8-of-12.sg-col-12-of-16.sg-col-24-of-28 > div > span:nth-child(6) > div.s-result-list.s-search-results.sg-row > div:nth-child(1) > div > span > div > div > div > div > div:nth-child(2) > div.sg-col-4-of-12.sg-col-8-of-16.sg-col-16-of-24.sg-col-12-of-20.sg-col-24-of-32.sg-col.sg-col-28-of-36.sg-col-20-of-28 > div > div:nth-child(1) > div > div > div:nth-child(1) > h2 > a > span");
            var txt1 = (await fElementText.GetPropertyAsync("textContent")).ToString();
            var txt2 = await fElementText.EvaluateFunctionAsync<string>("t => t.textContent", fElementText);
            //Console.WriteLine(txt1);
            //Console.WriteLine(txt2);

            //TODO 1

            //TEST DB
            Db dataBase = new Db(txt2);
            Console.WriteLine(dataBase.testNumber);

            //-------

        }
    }
}
