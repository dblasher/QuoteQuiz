using QuoteQuiz.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteQuiz.Repositories
{
    public class SeedData
    {
        //setup on DB connection
        //Service Provider connnects Entity Framework to whatever Database the app uses
        //Have to use IApplicationBuilder in order to call this class in Startup.cs in the Configure method
        public static void Seed(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices.GetRequiredService<AppDbContext>();
            context.Database.EnsureCreated();

            //If there are no stories in the DB, we'll add some
            if (!context.Quotes.Any())
            {
                //create a character
                Character c1 = new Character { Name = "Maximus" };
                context.Characters.Add(c1);

                //create a movie
                Movie m1 = new Movie { Title = "Gladiator" };
                context.Movies.Add(m1);

                //create a story by that user, add that user's comment to the story
                Quote q1 = new Quote
                {
                    Text = "Are you not entertained!?",
                    Character = c1,
                    Movie = m1,
                    Link = "https://www.youtube.com/watch?v=7DDxe8FvpPI"
                };
                context.Quotes.Add(q1);

                //save all the added seed data to the database
                context.SaveChanges();
            }
        }
    }
}
