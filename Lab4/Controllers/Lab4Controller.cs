using System;
using Microsoft.AspNetCore.Mvc;
using WaffleGenerator;

namespace Lab4.Controllers
{
    public class Lab4Controller : Controller
    {
        public IActionResult Index()
        {
            DateTime date = DateTime.Now;
            DateTime noon = new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
            DateTime evening = new DateTime(date.Year, date.Month, date.Day, 18, 0, 0);
            DateTime nextYear = new DateTime(date.Year + 1, 1, 1, 0, 0, 0);
            TimeSpan time = nextYear - date;
            ViewData["time"] = date.ToShortTimeString();
            ViewData["date"] = date.ToLongDateString();
            ViewData["year"] = date.Year;
            ViewData["hour"] = date.Hour;
            ViewData["days"] = time.Days;
            return View();
        }

        public IActionResult Waffles()
        {
            var html = WaffleEngine.Html(paragraphs: 2, includeHeading: true, includeHeadAndBody: false);
            ViewData["waffle"] = html;
            return View();
        }
    }
}