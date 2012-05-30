using System;

namespace LondonUbfWeb.Domain.Models
{
    public class ServerFile
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string PartialPath { get; set; }
        public bool IsFolder { get; set; }
        public string ParentDirectory { get; set; }
    }
}
