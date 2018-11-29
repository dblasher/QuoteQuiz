using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuoteQuiz.Models;

namespace QuoteQuiz.Repositories
{
    /// <summary>
    /// Used for accessing the Quote Model
    /// </summary>
    public interface IQuoteRepository
    {
        IQueryable<Quote> Quotes { get; }

        void AddQuote(Quote quote);

        Quote GetQuoteByText(string text);
    }
}
