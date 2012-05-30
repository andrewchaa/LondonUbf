using System.Collections.Generic;

namespace Web.Domain.Models
{
    public class PersonIndexViewModel
    {
        public IEnumerable<PersonListViewModel> ListViewModels { get; set; }
        public PersonInput Input { get; set; }
    }
}