using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Domain.Services;
using AutoMapper;
using Norm;

namespace LondonUbfWeb.Controllers
{
    [HandleError]
    [Authorize]
    public class RotaController : Controller
    {
        private const int PAGESIZE = 30;
        private readonly DataService _dataService;

        public RotaController()
        {
            _dataService = new DataService();
        }

        public ActionResult Index()
        {
            var jobs = _dataService.FindJobsForService();

            return View(jobs);
        }

        public ActionResult AddService()
        {
            var viewModel = new JobAddViewModel();
            var todayjobs = _dataService.FindJobsByCreateDate(DateTime.Today);

            viewModel.ListViewModels = Mapper.Map<IEnumerable<Job>, IEnumerable<JobListViewModel>>(todayjobs);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddService(JobInput input)
        {
            var job = new Job
                          {
                              JobType = JobType.Service,
                              Messenger = _dataService.FindPerson(input.Messenger),
                              Presider = _dataService.FindPerson(input.Presider),
                              Reader = _dataService.FindPerson(input.Reader),
                              PrayerServantMan = _dataService.FindPerson(input.PrayerServantMan),
                              PrayerServantWoman = _dataService.FindPerson(input.PrayerServantWoman),
                          };
            _dataService.AddJob(job);

            if (Request.IsAjaxRequest())
            {
                var todayjobs = _dataService.FindJobsByCreateDate(DateTime.Today);
                var viewModels = Mapper.Map<IEnumerable<Job>, IEnumerable<JobListViewModel>>(todayjobs);

                return View("_JobResult", viewModels);
            }

            return RedirectToAction("AddService");
        }

        public ActionResult AddOthers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ObjectId id)
        {
            _dataService.DeleteJob(id);

            if (Request.IsAjaxRequest())
            {
                var todayjobs = _dataService.FindJobsByCreateDate(DateTime.Today);
                var viewModels = Mapper.Map<IEnumerable<Job>, IEnumerable<JobListViewModel>>(todayjobs);

                return View("_JobResult", viewModels);
            }

            return Json(string.Empty);
        }
    }
}
