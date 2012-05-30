using System.ComponentModel;

namespace LondonUbfWeb.Domain.Models
{
    public class PersonInput
    {
        public string Id { get; set; }

        [DisplayName("First name:")]
        public string Firstname { get; set; }

        [DisplayName("Last name:")]
        public string Lastname { get; set; }

        [DisplayName("Email:")]
        public string Email { get; set; }

        [DisplayName("Mobile no.:")]
        public string Mobile { get; set; }
    }
}