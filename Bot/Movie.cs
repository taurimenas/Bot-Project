namespace Bot
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string TopRating { get; set; }
        public string ImdbRating { get; set; }
        public string ReleaseYear { get; set; }

        public Movie()
        {

        }
        public void PrintMovie()
        {
            System.Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"Id: {MovieId} Rank: {TopRating} Title: {MovieTitle} Year: {ReleaseYear} Rating: {ImdbRating} ";
        }
    }

    }





