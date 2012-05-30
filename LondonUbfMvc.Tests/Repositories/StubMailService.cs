using System;
using LondonUbfWeb.Domain.Models;
using LondonUbfWeb.Domain.Services;

namespace LondonUbfWeb.Test.Repositories
{
    public class StubMailService : IMailService
    {
        #region IMailService Members

        public bool SendMail(Rota rota)
        {
            return true;
        }

        #endregion

    }
}
