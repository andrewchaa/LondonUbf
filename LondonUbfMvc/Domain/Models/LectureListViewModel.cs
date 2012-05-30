using System.Collections.Generic;
using LondonUbfWeb.Helpers;

namespace LondonUbfWeb.Domain.Models
{
    public class LectureListViewModel : ViewModel
    {
        public PagedList<LectureViewModel> PagedList { get; set; }
        public IEnumerable<string> Books { get; set; }
        public string CurrentBook { get; set; }
        public bool IsAdmin { get; set; }
    }
}