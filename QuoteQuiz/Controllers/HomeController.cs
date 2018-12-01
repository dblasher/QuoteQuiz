using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteQuiz.Models;

namespace QuoteQuiz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //might need to pass a string model or something coming from the AddQuote post method 
            //indicating the user's submission has been successful
            return View();
        }
    }
}
