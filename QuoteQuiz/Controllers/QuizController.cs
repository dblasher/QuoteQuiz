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

        public static Random rng = new Random();

        public QuizController(IQuoteRepository r)
        {
            repo = r;
        }
        //helper function for randomizing the list of quote answers
        public static void Shuffle( List<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        /// <summary>
        /// Quiz Controller function for selecting a random quote as the answer and three random options to display to the user
        /// </summary>
        /// <returns></returns>
        public IActionResult TakeQuiz()
        {
            //need a list of quotes to randomly pull from
            List<Quote> quotes = repo.Quotes.ToList();

            //establish answer's location
            int key = rng.Next(quotes.Count);

            //grab the answer quote based on our key
            Quote answer = quotes[key];

            //Lists for holding quiz options, need to be shuffled once filled with four items, one of is the correct name and title
            List<string> titles = new List<string>();
            List<string> names = new List<string>();
            titles.Add(answer.Movie.Title);
            names.Add(answer.Character.Name);

            //remove the answer from quotes so it doesn't show up twice as an option
            quotes.RemoveAt(key);

            //track how many options we have, can change to make the quiz harder/easier
            int options = 0;

            //add random quote movie titles and character names to the list of respective options
            do
            {
                int i = rng.Next(quotes.Count);
                titles.Add(quotes[i].Movie.Title);
                names.Add(quotes[i].Character.Name);
                quotes.RemoveAt(i);
                options++;
            } while (options < 3);

            //shuffle my list of options before passing to the view
            Shuffle(titles);
            Shuffle(names);

            //now the ugly part of populating ViewBag with all our options
            ViewBag.t1 = titles[0];
            ViewBag.t2 = titles[1];
            ViewBag.t3 = titles[2];
            ViewBag.t4 = titles[3];
            ViewBag.n1 = names[0];
            ViewBag.n2 = names[1];
            ViewBag.n3 = names[2];
            ViewBag.n4 = names[3];
            //hidden quote Id that will be needed for evaluting the quiz
            ViewBag.answerId = answer.QuoteID;
            return View(answer);
        } //end of method for populating the quiz

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
            Quote answer = (from q in repo.Quotes
                           where q.QuoteID == answerId
                           select q).FirstOrDefault();
            //should always succeed, but may want to use a try catch here 
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
        public RedirectToActionResult AddQuote(string text, string character, string movie, string link)
        {
            //use LINQ to check there are no quotes already in the db with the same text
            bool exists = (from quotes in repo.Quotes
                           where quotes.Text == text
                           select quotes).Any();
            if (exists)
                //notify user their quote is already in, verbatim!
                ViewBag.message = " Sorry, that quote has already been added";
            else
            {
                Character name = new Character() { Name = character };
                Movie title = new Movie() { Title = movie };
                //truncate link, removes everything before the unique video Id
                //Or just let Results.chtml do the truncating so the database has full youtube links
                //int i = link.IndexOf("=");
                //string subLink = link.Remove(0, i + 1);
                Quote quote = new Quote()
                {
                    Text = text,
                    Character = name,
                    Movie = title,
                    Link = link
                };
                repo.AddQuote(quote);
                //notify user of successful submission
                ViewBag.message = "Thank you for adding a quote!";
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
