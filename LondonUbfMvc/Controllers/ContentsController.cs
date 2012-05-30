using System;
using System.Web.Mvc;

namespace LondonUbfWeb.Controllers
{
    public class ContentsController : Controller
    {
        //
        // GET: /Contents/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resource()
        {
            return View();
        }

        public ActionResult Error()
        {
            var ex = HttpContext.Application[Request.UserHostAddress] as Exception;
            if (ex != null)
            {
                ViewData["Description"] = ex.Message;
            }
            else
            {
                ViewData["Description"] = "An error occurred.";
            }

            ViewData["Title"] = "Oops. We're sorry. An error occurred and we're on the case.";


            return View();
        }

    }
}
