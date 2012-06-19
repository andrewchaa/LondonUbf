using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LondonUbf.Controllers
{
    public class LogController : Controller
    {
        //
        // GET: /Log/

        public ActionResult Index()
        {
            string path = string.Format("{0}\\error.html", Server.MapPath("~/app_data"));
            string result = System.IO.File.ReadAllText(path);

            ViewData["Log"] = result;
            return View();
        }

    }
}
