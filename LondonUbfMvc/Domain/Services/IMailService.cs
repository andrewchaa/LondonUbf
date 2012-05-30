using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Domain.Services
{
    public interface IMailService
    {
        bool SendMail(Rota rota);
    }
}
