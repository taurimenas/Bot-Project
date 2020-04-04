using System;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {
        static async Task Main()
        {
            DataExtractor dataExtractor = new DataExtractor();
            await dataExtractor.ExtractData();
            //Db db = new Db(dataExtractor.Titles, dataExtractor.TopRatings, dataExtractor.ImdbRatings, dataExtractor.Dates);
            for (int i = 0; i < 250; i++)
            {
                //MovieDb movieDb = new MovieDb(dataExtractor.Titles[i], dataExtractor.TopRatings[i], dataExtractor.ImdbRatings[i], dataExtractor.Dates[i]);
                //MovieDb movieDb = new MovieDb();
                //movieDb.AddData();
            }
            
           
        }
    }
}
