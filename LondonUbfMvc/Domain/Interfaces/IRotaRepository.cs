using System.Linq;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Domain.Interfaces
{
    public interface IRotaRepository
    {
        IQueryable<Rota> List();
        Rota Update(Rota rota);
    }
}
