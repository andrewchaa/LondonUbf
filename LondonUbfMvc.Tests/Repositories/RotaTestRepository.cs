using System;
using System.Collections.Generic;
using System.Linq;
using LondonUbfWeb.Domain.Interfaces;
using LondonUbfWeb.Domain.Models;

namespace LondonUbfWeb.Test.Repositories
{
    public class RotaTestRepository : IRotaRepository
    {
        public IQueryable<Rota> List()
        {
            var testRotas = new List<Rota>();
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

            for (int i = 0; i < 5; i++)
            {
                testRotas.Add(new Rota()
                {
                    ContactId = 20,
                    Date = DateTime.Today.AddDays(i * -1),
                    FirstName = "Jon" + i,
                    LastName = "Doe",
                    Responsibility = "Presider"
                });
            }

            return testRotas.OrderByDescending(r => r.Date).AsQueryable();
        }

        public Rota Update(Rota rota)
        {
            return rota;
        }

    }
}
