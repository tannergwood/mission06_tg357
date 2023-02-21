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

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Horror/Suspense"
                },
                new Category
                {
                    CategoryID = 6,
                    CategoryName = "Miscellaneous"
                },
                new Category
                {
                    CategoryID = 7,
                    CategoryName = "Television"
                },
                new Category
                {
                    CategoryID = 8,
                    CategoryName = "VHS"
                }
                );

            mb.Entity<MovieInput>().HasData(
                
                new MovieInput
                {
                    MovieID = 1,
                    Title = "The Sandlot",
                    CategoryID = 4,
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
                    CategoryID = 2,
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
                    CategoryID = 3,
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
