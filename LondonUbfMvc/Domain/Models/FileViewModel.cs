using LondonUbfWeb.Helpers;

namespace LondonUbfWeb.Domain.Models
{
    public class FileViewModel
    {
        public ServerFile Item { get; set; }
        public PagedList<ServerFile> List { get; set; }
        public string SearchWord { get; set; }
    }
}
