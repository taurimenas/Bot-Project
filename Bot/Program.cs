using System;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataExtractor dataExtractor = new DataExtractor();
            await dataExtractor.ExtractData();
            Db db = new Db(dataExtractor.Titles, dataExtractor.TopRatings, dataExtractor.ImdbRatings, dataExtractor.Dates);

        }
    }
}
