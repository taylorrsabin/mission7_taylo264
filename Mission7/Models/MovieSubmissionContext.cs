using System;
using Microsoft.EntityFrameworkCore;

namespace Mission7.Models
{
	public class MovieSubmissionContext : DbContext
	{
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options)
        {

        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Mystery" },
                new Category { CategoryId = 3, CategoryName = "Horror" },
                new Category { CategoryId = 4, CategoryName = "Comedy" },
                new Category { CategoryId = 5, CategoryName = "Family" },
                new Category { CategoryId = 6, CategoryName = "Drama" },
                new Category { CategoryId = 7, CategoryName = "Television" }
                );

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    CategoryId = 1,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Bill Nye",
                    Notes = ""
                },

                new ApplicationResponse
                {
                    MovieId = 2,
                    Title = "Iron Man",
                    Year = 2008,
                    CategoryId = 1,
                    Director = "Jon Favreau",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "",
                    Notes = "Super awesome movie"
                },

                new ApplicationResponse
                {
                    MovieId = 3,
                    Title = "Ocean's Eleven",
                    Year = 2001,
                    CategoryId = 2,
                    Director = "Steven Soderbergh",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }

            );
        }
    }
}

