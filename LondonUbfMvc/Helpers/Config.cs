using System.Configuration;

namespace LondonUbfWeb.Helpers
{
    public class Config
    {
        public static string MongoDbConnection
        {
            get { return ConfigurationManager.ConnectionStrings["LondonUbfMongo"].ConnectionString; }
        }
    }
}