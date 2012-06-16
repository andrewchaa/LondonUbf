using System.Web.Mvc;
using Castle.Core.Logging;
using LondonUbf.Domain;
using LondonUbf.Models;

namespace LondonUbf.Controllers
{
    public class MessagesController : Controller
    {
        public ILogger Logger { get; set; }


        private MessageRepository _messageRepository;

        public ActionResult Index()
        {
            _messageRepository = new MessageRepository(new FileNameParser(), Server.MapPath("/Content/messages"));
            var viewModel = new MessageViewModel { Messages = _messageRepository.FindAll() };

            return View(viewModel);
        }

        public ActionResult Read(string id)
        {
            _messageRepository = new MessageRepository(new FileNameParser(), Server.MapPath("/Content/messages"));
            var message = _messageRepository.Find(id);
           
            return View(message);
        }
    }
}
