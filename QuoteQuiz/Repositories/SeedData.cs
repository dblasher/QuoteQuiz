using QuoteQuiz.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
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

            //Should always have atleast 4 quotes, otherwise the TakeQuiz method won't have enough data to work properly
            if (context.Quotes.Count() < 4)
            {
                //create 4 characters
                Character c1 = new Character { Name = "Maximus" };
                Character c2 = new Character { Name = "Nacho" };
                Character c3 = new Character { Name = "Bruce Banner" };
                Character c4 = new Character { Name = "Yoda" };
                context.Characters.Add(c1);
                context.Characters.Add(c2);
                context.Characters.Add(c3);
                context.Characters.Add(c4);

                //create 4 movies
                Movie m1 = new Movie { Title = "Gladiator" };
                Movie m2 = new Movie { Title = "Nacho Libre" };
                Movie m3 = new Movie { Title = "The Avengers" };
                Movie m4 = new Movie { Title = "The Empire Strikes Back" };
                context.Movies.Add(m1);
                context.Movies.Add(m2);
                context.Movies.Add(m3);
                context.Movies.Add(m4);

                //create quotes by that character, from that movie
                Quote q1 = new Quote
                {
                    Text = "Are you not entertained!?",
                    Character = c1,
                    Movie = m1,
                    Link = "https://www.youtube.com/watch?v=7DDxe8FvpPI"
                };
                context.Quotes.Add(q1);

                Quote q2 = new Quote
                {
                    Text = "Don't you want a little taste of the glory? See what it tastes like?",
                    Character = c2,
                    Movie = m2,
                    Link = "https://www.youtube.com/watch?v=ck2DLjDHuYo"
                };
                context.Quotes.Add(q2);

                Quote q3 = new Quote
                {
                    Text = "That's my secret Cap, I'm always angry",
                    Character = c3,
                    Movie = m3,
                    Link = "https://www.youtube.com/watch?v=MpBmPgQkHf0"
                };
                context.Quotes.Add(q3);

                Quote q4 = new Quote
                {
                    Text = "Do or do not. There is no try",
                    Character = c4,
                    Movie = m4,
                    Link = "https://www.youtube.com/watch?v=h5SNAluOj6U"
                };
                context.Quotes.Add(q4);

                //save all the added seed data to the database
                context.SaveChanges();
            }
        }
    }
}
