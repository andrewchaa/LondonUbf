using System.Collections.Generic;
using LondonUbf.Domain;

namespace LondonUbf.Models
{
    public class MessageViewModel
    {
        public IEnumerable<ServiceMessage> Messages { get; set; }
    }
}