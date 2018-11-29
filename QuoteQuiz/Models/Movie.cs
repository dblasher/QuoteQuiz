using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuoteQuiz.Models
{
    public class Movie
    {

        public int MovieID { get; set; }

        private List<Quote> quotes = new List<Quote>();

        public string Title { get; set; }

        public ICollection<Quote> Quotes { get { return quotes; } }

    }
}
