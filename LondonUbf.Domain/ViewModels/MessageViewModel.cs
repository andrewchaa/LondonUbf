using System.Collections.Generic;

namespace LondonUbf.Domain.ViewModels
{
    public class MessageViewModel
    {
        public IEnumerable<ServiceMessage> Messages { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}