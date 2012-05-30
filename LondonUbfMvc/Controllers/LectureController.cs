using System.Collections.Generic;
using System.Web.Mvc;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Domain.Repositories;
using LondonUbfWeb.Domain.Services;
using LondonUbfWeb.Helpers;
using Norm;
using AutoMapper;

namespace LondonUbfWeb.Controllers
{
    public class LectureController : Controller
    {
        const int PageSize = 25;

        private readonly DataService _dataService;
        private readonly ILectureRepository _repository;

        public LectureController()
        {
            _dataService = new DataService();
            _repository = new LectureRepository();
        }

        [Authorize]
        public ActionResult Add(string bookName, string deliveryDate, string isoDeliveryDate)
        {
            var input = new LectureInput
                              {
                                  BookName = bookName, 
                                  DeliveryDate = deliveryDate,
                                  IsoDeliveryDate = isoDeliveryDate,
                                  SubmitButtonText = "Add"
                              };

            return View(input);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Add(LectureInput input)
        {
            if (!ModelState.IsValid)
                return View(input);

            var lecture = input.ToLecture();
            _repository.Add(lecture);
            TempData["TempMessage"] = "A lecture is successfully added";

            if (Request.IsAjaxRequest())
                return new EmptyResult();

            return RedirectToAction("Add", new
                                               {
                                                   bookName = input.BookName, 
                                                   deliveryDate = input.DeliveryDate,
                                                   isoDeliveryDate = lecture.DeliveryDate.ToString("yyyy-MM-dd")
                                               });
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(ObjectId id)
        {
            _repository.Delete(id);

            return new EmptyResult();
        }

        [Authorize]
        public ActionResult Edit(ObjectId id)
        {
            var lecture = _repository.Find(id);
            var input = Mapper.Map<Lecture, LectureInput>(lecture);
            input.SubmitButtonText = "Edit";

            return View("Add", input);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(LectureInput input)
        {
            if (!ModelState.IsValid)
                return View("Add", input);

            var lecture = input.ToLecture();
            lecture.Id = new ObjectId(input.Id);

            _repository.Add(lecture);

            return RedirectToAction("View", new {id = lecture.Id});
        }

        public ActionResult Index(string book, int? page)
        {
            string currentBook = book == "all" ? string.Empty : book;
            var lectures = _repository.FindByBook(currentBook);
            var lectureViewModels = Mapper.Map<IEnumerable<Lecture>, IEnumerable<LectureViewModel>>(lectures);
            var pagedList = new PagedList<LectureViewModel>(lectureViewModels, page ?? 0, PageSize);
            var books = _repository.FindAllAvailableBooks();

            var viewModel = new LectureListViewModel
                                {
                                    Books = books,
                                    PagedList = pagedList,
                                    CurrentBook = currentBook,
                                    IsAdmin = User.Identity.Name.ToLower().Contains("andrew") ||
                                        User.Identity.Name.ToLower().Contains("achaa")
                                };

            return View(viewModel);
        }

        public ActionResult View(ObjectId id)
        {
            var lecture = _repository.Find(id);
            var viewModel = Mapper.Map<Lecture, LectureViewModel>(lecture);
            viewModel.IsAdmin = User.Identity.Name.ToLower().Contains("andrew") ||
                                User.Identity.Name.ToLower().Contains("achaa");

            return View(viewModel);
        }

    }
}
