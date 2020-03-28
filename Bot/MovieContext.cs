using System.Data.Entity;

namespace Bot
{
    public class MovieContext : DbContext
        {
            public DbSet<Movie> Movies { get; set; }

        }

    }





