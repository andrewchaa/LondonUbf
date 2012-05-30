using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LondonUbfWeb.Helpers;
using LondonUbfWeb.Infrastructure;

namespace LondonUbfWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRouteLowercase(
                "LectureBook",
                "lecture/index/{book}/{page}",
                new { controller = "Lecture", action = "Index", book = "all", page = UrlParameter.Optional }
            );

            routes.MapRouteLowercase(
                "LectureView",
                "{controller}/{action}/{book}/{title}/{id}",
                new { controller = "lecture", action = "view" }
            );

            routes.MapRouteLowercase(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "contents", action = "index", id = UrlParameter.Optional }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            AutoMapperConfiguration.Configure();
            AppHelper.SiteAbsolutePath = Server.MapPath("/");
            AppHelper.TemplateAbsolutePath = Server.MapPath("/content/template");

            //Thread emailThread = new Thread(EmailRota);
            //emailThread.Start();

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            string url = Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                HttpContext.Current.Request.Url.AbsolutePath;

            if (Regex.IsMatch(url, @"[A-Z]"))
            {
                var lowercaseUrl = url.ToLower() + HttpContext.Current.Request.Url.Query;

                Response.Clear();
                Response.Status = "301 Moved Permanently";
                Response.AddHeader("Location", lowercaseUrl);
                Response.End();
            }

            if (string.Compare(url, "http://londonubf.org.uk", true) == 0)
            {
                Response.Clear();
                Response.Status = "301 Moved Permanently";
                Response.AddHeader("Domain", "http://www.londonubf.org.uk");
                Response.End();
            }
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            Application[HttpContext.Current.Request.UserHostAddress] = ex;
        }

        private void EmailRota()
        {
            //RotaService rotaService = new RotaService();
            //List<Rota> rotas = rotaService.ListRotasToMail().ToList();

            //rotaService.SendMail(rotas);
        }

    }
}