using System.Linq;
using System.Web.Mvc;
using Castle.Core.Logging;
using LondonUbf.Domain;
using LondonUbf.Domain.Repositories;
using LondonUbf.Domain.ViewModels;
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

        public ActionResult Index(string id = "")
        {
            var viewModel = new MessageViewModel
                                {
                                    Messages = string.IsNullOrEmpty(id) ? _messageRepository.FindAllMessages() : _messageRepository.FindMessagesBy(id),
                                    Books = _messageRepository.FindAllBooks().ToList()
                                };

            return View(viewModel);
        }

        public ActionResult Read(string id)
        {
            string fileName = id.Replace('_', ' ');
            var message = _messageRepository.Find(fileName);
           
            return View(message);
        }
    }
}
