using System.Web.Mvc;
using Castle.Core.Logging;
using LondonUbf.Domain;
using LondonUbf.Models;

namespace LondonUbf.Controllers
{
    public class MessagesController : Controller
    {
        public ILogger Logger { get; set; }
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public ActionResult Index()
        {
            var viewModel = new MessageViewModel { Messages = _messageRepository.FindAll() };

            return View(viewModel);
        }

        public ActionResult Read(string id)
        {
            var message = _messageRepository.Find(id);
           
            return View(message);
        }
    }
}
