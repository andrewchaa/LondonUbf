using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LondonUbfMvc.Models;

namespace LondonUbfMvc.Tests.Models
{
    public class RotaRepositoryStub : IRotaRepository
    {
        #region IRotaRepository Members

        public IQueryable<Rota> ListRotas()
        {
            List<Rota> testRotas = new List<Rota>();
            for (int i = 0; i < 5; i++)
            {
                testRotas.Add(new Rota()
                {
                    ContactId = 20,
                    Date = DateTime.Today.AddDays(i),
                    FirstName = "Jon" + i,
                    LastName = "Doe",
                    Responsibility = "Presider"
                });
            }
            return testRotas.AsQueryable<Rota>();
        }

        #endregion
    }
}
