using System.Linq;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Domain.Interfaces
{
    public interface IService
    {
        IQueryable<Rota> ListRotas();
        Rota GetRota(int id);
        bool UpdateRota(Rota rota);
        bool AddRota(Rota rota);
        bool DeleteRota(Rota rota);
    }
}
