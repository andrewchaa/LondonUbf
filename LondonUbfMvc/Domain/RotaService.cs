using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LondonUbfMvc.Models
{
    public class RotaService
    {
        IRotaRepository _repository;

        public RotaService() : this(new RotaRepository()) { }
        public RotaService(IRotaRepository repository) 
        {
            _repository = repository;
        }
        
        public IQueryable<Rota> ListRotas()
        {
            return _repository.ListRotas();
        }

        public IQueryable<Rota> ListRotasToMail()
        {
            IQueryable<Rota> rotas = ListRotas();
            return (
                from r in rotas
                where r.Date < DateTime.Today.AddDays(3)
                select r
                );
        }

    }
}
