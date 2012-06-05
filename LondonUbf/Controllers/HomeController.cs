using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LondonUbf.Domain;
using LondonUbf.Models;

namespace LondonUbf.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
