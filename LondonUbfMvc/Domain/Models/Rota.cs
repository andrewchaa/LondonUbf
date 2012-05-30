using System;

namespace LondonUbfWeb.Domain.Models
{
    public class Rota
    {
        public DateTime Date { get; set; }
        public string Responsibility { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        public string Email { get; set; }

        public long ContactId { get; set; }
        public bool IsMailSent { get; set; }
        public long RotaId { get; set; }

        public Rota()
        {}

    }
}
