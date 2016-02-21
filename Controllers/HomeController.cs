using System.Collections.Generic;
using career_trender.Classes;
using career_trender.Models;
using Microsoft.AspNet.Mvc;

namespace career_trender.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        
         public IActionResult Jobs()
        {
            ViewData["Message"] = "Your jobs page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }        
    }
}
