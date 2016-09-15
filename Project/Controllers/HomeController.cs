using Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET Home/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET Home/About
        public ActionResult About()
        {
            return View();
        }

        // GET Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}