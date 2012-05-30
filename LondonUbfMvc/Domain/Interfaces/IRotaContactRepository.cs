using System.Linq;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Domain.Interfaces
{
    public interface IRotaContactRepository
    {
        IQueryable<Rota> ListRotas();
        Rota GetRota(long id);
        Rota AddRota(Rota rota);
        Rota UpdateRota(Rota rota);
        void DeleteRota(long rota);

        IQueryable<Contact> ListContacts();
        Contact GetContact(long id);
        Contact AddContact(Contact contact);
        Contact UpdateContact(Contact contact);
        void DeleteContact(Contact contact);

    }
}
