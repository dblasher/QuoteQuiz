using System;
using System.Collections.Generic;
using QuoteQuiz.Repositories;
using System.Linq;
using System.Threading.Tasks;
using QuoteQuiz.Models;
using Microsoft.EntityFrameworkCore;

namespace QuoteQuiz.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        //dependecy injection service will define this property
        private AppDbContext context;

        //Use IQueryable isntead of List so users aren't given the entire DB of stories, rather the ability to search the DB
        public IQueryable<Quote> Quotes
        {
            get
            {
                //need to include the other DB tables so we can display data related to each story, ie their user and comments
                return context.Quotes.Include(Quotes => Quotes.Character).Include(Quotes => Quotes.Movie);
            }
        }

        public QuoteRepository(AppDbContext appContext)
        {
            context = appContext;
        }

        public void AddQuote(Quote quote)
        {
            context.Quotes.Add(quote);
            context.SaveChanges();
        }

        public Quote GetQuoteByText(string text)
        {
            Quote quote = context.Quotes.First(s => s.Text == text);
            return quote;
        }
    }
}
