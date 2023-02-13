using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mission6try2.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<MovieInput> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieInput>().HasData(
                
                new MovieInput
                {
                    MovieID = 1,
                    Title = "The Sandlot",
                    Category = "Family",
                    Year = 1993,
                    Director = "David Mickey Evans",
                    Rating = "PG", 
                    Edited = false,
                    LentTo = "",
                    Notes = "Great Movie"
                },
                new MovieInput
                {
                    MovieID = 2,
                    Title = "Cool Runnings",
                    Category = "Comedy",
                    Year = 1993,
                    Director = "Jon Turteltaub",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = "Good Movie"
                },
                new MovieInput
                {
                    MovieID = 3,
                    Title = "42",
                    Category = "Drama",
                    Year = 2013,
                    Director = "Brian Helgeland",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Super Movie"
                }

                );
        }
    }
}
