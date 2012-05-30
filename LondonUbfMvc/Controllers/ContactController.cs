using System.Collections.Generic;
using System.Web.Mvc;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Domain.Services;
using Norm;
using AutoMapper;

namespace LondonUbfWeb.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly DataService _dataService;

        public ContactController()
        {
            _dataService = new DataService();
        }

        public ActionResult Index()
        {
            var persons = _dataService.FindPersons();
            var viewModels = Mapper.Map<IEnumerable<Person>, IEnumerable<PersonListViewModel>>(persons);

            return View(viewModels);
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            _dataService.AddPerson(person);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(ObjectId id)
        {
            _dataService.DeletePerson(id);

            return new EmptyResult();
        }

        public ActionResult Edit(ObjectId id)
        {
            var person = _dataService.FindPerson(id);
            var viewModel = Mapper.Map<Person, PersonInput>(person);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(PersonInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var person = new Person
                             {
                                 Email = input.Email,
                                 Firstname = input.Firstname,
                                 Id = input.Id,
                                 Lastname = input.Lastname,
                                 Mobile = input.Mobile
                             };

            _dataService.UpdatePerson(person);

            return RedirectToAction("Index");
        }
    }
}
