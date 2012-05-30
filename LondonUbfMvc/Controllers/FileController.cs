using System.Linq;
using System.Web.Mvc;
using System.Configuration;
using LondonUbfWeb.Domain.Interfaces;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Domain.Repositories;
using LondonUbfWeb.Helpers;

namespace LondonUbfWeb.Controllers
{
    public class FileController : Controller
    {
        private IRepositoryFile _repository;
        private readonly string _messageDir;
        private readonly string _fileDir;

        public FileController() 
        {
            _messageDir = ConfigurationManager.AppSettings["MessageDir"];
            _fileDir = ConfigurationManager.AppSettings["FileDir"];
        }

        [Authorize]
        public ActionResult RecentMessage(string searchword, int? page)
        {
            _repository = new MessageRepository(_messageDir, searchword);

            var messageList = _repository.ListItems().OrderByDescending(s => s.Date);
            var list = new PagedList<ServerFile>(messageList, page ?? 0, 20);
            var viewModel = new FileViewModel
                                {
                                    List = list,
                                    SearchWord = searchword
                                };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Browse(string searchword, int? page, string path)
        {
            _repository = new FileRepository(_fileDir, path ?? string.Empty, searchword ?? string.Empty);

            var item = _repository.GetItem();
            var fileList = _repository.ListItems();
            var list = new PagedList<ServerFile>(fileList, page ?? 0, 20);
            var viewModel = new FileViewModel
                                {
                                    Item = item,
                                    List = list,
                                    SearchWord = searchword
                                };

            return View(viewModel);
        }

        [Authorize]
        public ActionResult Download(int type, string name, string path)
        {
            string root = type == 1 ? _fileDir : _messageDir;
            return new DownloadResult(root, name, path);
        }

    }
}
