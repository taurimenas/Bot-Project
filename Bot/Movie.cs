using System;
using System.ComponentModel.DataAnnotations;

namespace Bot
{
    public class Movie
    {
        [Key]
        public string TopRating { get; set; }
        public string MovieTitle { get; set; }
        public string ImdbRating { get; set; }
        public string ReleaseYear { get; set; }
        public static DateTime Now { get; }




        public Movie()
        {

        }
        public void PrintMovie()
        {
            System.Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"Rank: {TopRating} Title: {MovieTitle} Year: {ReleaseYear} Rating: {ImdbRating} Date: {Now}";
        }
    }

    }





