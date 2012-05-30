using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LondonUbfWeb.Domain.Services;
using LondonUbfWeb.Helpers;
using Norm;

namespace LondonUbfWeb.Domain.Models
{
    public class JobAddViewModel
    {
        private readonly DataService _dataService;

        public JobAddViewModel()
        {
            _dataService = new DataService();
            Input = new JobInput { Date = DateTime.Today.ToString("dd/MM/yyyy") };
        }

        public JobInput Input { get; set; }
        public IEnumerable<JobListViewModel> ListViewModels { get; set; }

        public SelectList PersonList  
        {
            get
            {
                var persons = _dataService.FindPersons().ToList();
                persons.Insert(0, new Person{Id = ObjectId.Empty, Firstname = string.Empty});
                
                return persons.ToSelectList("Id", "Firstname");
            }
        }
    }
}