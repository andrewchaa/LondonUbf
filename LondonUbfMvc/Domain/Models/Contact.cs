namespace LondonUbfWeb.Domain.Models
{
    public class Contact
    {
        public long ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string ContactName { get; set; }
        public string Email { get; set; }
    }
}
