using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteQuiz.Models;
using QuoteQuiz.Repositories;

namespace QuoteQuiz.Controllers
{
    public class QuizController : Controller
    {
        IQuoteRepository repo;
        public QuizController(IQuoteRepository r)
        {
            repo = r;
        }

        public IActionResult TakeQuiz()
        {
            //need to pass a random quote for scoring
            List<Quote> quotes = repo.Quotes.ToList();
            //for now it only has one quote, so I'll take the quote at index 0
            //next iteration I'll need a random number from 0 to quotes.Count
            Quote answer = quotes[0];
            //can I pass viewbag or viewdata from view to controller?
            ViewBag.answerId = answer.QuoteID;
            return View(answer);
        }

        /// <summary>
        /// Quiz Controller function that evaluates user quiz responses as correct or incorrect
        /// </summary>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="answerLocation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TakeQuiz(string name, string title, int answerId)
        {
            //I really don't like this forced list shenanigans, but this is how I was shown
            List<Quote> quotes = (from q in repo.Quotes
                           where q.QuoteID == answerId
                           select q).ToList();
            //should always succeed, but may want to use a try catch here 
            Quote answer = quotes[0];
            if (answer.Character.Name == name && answer.Movie.Title == title)
                ViewBag.result = "CORRECT!";
            else
                ViewBag.result = "INCORRECT!";

            ViewBag.text = answer.Text;
            ViewBag.character = answer.Character.Name;
            ViewBag.movie = answer.Movie.Title;
            ViewBag.link = answer.Link;

            return View("Results");
        }

        public IActionResult Results(Quote answer)
        {
            //correct or incorrect status passed?
            return View(answer);
        }

        public IActionResult AddQuote()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult AddQuote(string text, string character, string title, string link)
        {
            //use LINQ to check there are no quotes already in the db with the same text
            //create charater
            //create movie
            //create quote using the charater, movie, and link
            //save to DB
            //send user back to Home page
            //viewBag.message = "Thank you for adding a quote!
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
