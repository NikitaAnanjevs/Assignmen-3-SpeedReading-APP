using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using SpeedReading_5x5.Models;
using SpeedReading_5x5.Models.ViewModels;

namespace SpeedReading_5x5.Controllers
{
    public class ReadingController : Controller
    {
        private Models.ApplicationDbContext db = new Models.ApplicationDbContext();
        // GET: Reading


        public ActionResult Index()
        {
            ReadingPageViewModel model = new ReadingPageViewModel();
            
            //  model.Bookses = db.Books.ToList();
              model.Bookses = db.Books.Where(a => a.Bodytext.Contains("Lorem")).ToList();
           //odel.Bookses = db.Books.Where(a => a.Id.Equals(2).ToList();
            return View(model);
            
        }
        public ActionResult CountingWords()
        {
            ReadingPageViewModel model = new ReadingPageViewModel();
            model.Bookses = db.Books.Where(a => a.Bodytext.Contains("Lorem")).ToList();

            return View(model);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public int CountingWords(string countWords)
        {
            string pattern = "\\w+";
            Regex regex = new Regex(pattern);

            int CountedWords = regex.Matches(countWords).Count;
            int finalCount;
            if (CountedWords >= 5)
            {
                 finalCount = (CountedWords / 5);
            }
            else
            {
                
                finalCount = CountedWords;
            }
         
         return finalCount;

        }


    }
}