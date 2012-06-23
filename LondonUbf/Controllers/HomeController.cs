using System.Web.Mvc;
using LondonUbf.Domain.Repositories;
using LondonUbf.Domain.ViewModels;

namespace LondonUbf.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageRepository _repository;

        public HomeController(IMessageRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Sitemap()
        {
            var messageViewModel = new MessageViewModel
                                       {
                                           Messages = _repository.FindAllMessages(),
                                           Books = _repository.FindAllBooks()
                                       };

            return View(messageViewModel);
        }

    }
}
