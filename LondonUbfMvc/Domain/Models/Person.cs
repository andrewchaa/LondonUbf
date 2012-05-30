using Norm;

namespace LondonUbfWeb.Domain.Models
{
    public class Person
    {
        [MongoIdentifier]
        public ObjectId Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Name 
        { 
            get { return Firstname + " " + Lastname; }
        }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}