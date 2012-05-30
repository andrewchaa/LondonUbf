using System.Linq;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Domain.Interfaces
{
    public interface IRepositoryFile
    {
        ServerFile GetItem();
        IQueryable<ServerFile> ListItems();
    }
}
