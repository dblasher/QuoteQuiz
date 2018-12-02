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
        public ActionResult Index()
        {
           
            //might need to pass a string model or something coming from the AddQuote post method 

            return View();
        }
    }
}
