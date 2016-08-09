using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise_2.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Blog()
        {
            ViewBag.Title = "Ha-Blog Shel Shauli";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}