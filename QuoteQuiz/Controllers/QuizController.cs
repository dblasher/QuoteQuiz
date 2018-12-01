using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteQuiz.Models;

namespace QuoteQuiz.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult TakeQuiz()
        {
            //need to pass a random quote for scoring
            //can I pass viewbag or viewdata from view to controller?
            return View();
        }

        [HttpPost]
        public RedirectToActionResult TakeQuiz(string character, string title, Quote quote)
        {
            //if(quote.character == character && quote.title ==title)
            //show correct
            //else
            //show incorrect
            return RedirectToAction("Results");
        }

        public IActionResult Results()
        {
            //correct or incorrect status passed?
            return View();
        }

        public IActionResult AddQuote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuote(string text, string character, string title, string link)
        {
            //use LINQ to check there are no quotes already in the db with the same text
            //create charater
            //create movie
            //create quote using the charater, movie, and link
            //save to DB
            //send user back to Home page
            //viewBag.message = "Thank you for adding a quote!
            return View();
        }

    }
}
