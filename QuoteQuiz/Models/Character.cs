using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuoteQuiz.Models
{
    public class Character
    {
        public int CharacterID { get; set; }

        private List<Quote> quotes = new List<Quote>();

        public string Name { get; set; }

        public ICollection<Quote> Quotes { get { return quotes; } }
    }
}
