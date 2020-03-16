using System;
using System.Collections.Generic;
using System.Text;

namespace Bot
{
    class Db
    {
        public int testNumber = 5;
        
        public Db()
        {

        }
        public Db(List<string> titles, List<string> topRatings, List<string> imdbRatings, List<string> dates)
        {

            Console.WriteLine(titles[0]);
            Console.WriteLine(topRatings[0]);
            Console.WriteLine(imdbRatings[0]);
            Console.WriteLine(dates[0]);
        }
    }
}
