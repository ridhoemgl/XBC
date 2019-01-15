using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XBC.MVC.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
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

        public ActionResult Test(int id)
        {
            ViewBag.Name = "Atur Aritonang";
            ViewBag.OtherName = "Andra Backbone";
            ViewBag.Id = id;
            return View();
        }

        public ActionResult Logic(int id)
        {
            ViewBag.Nilai = id;
            return View();
        }
    }
}