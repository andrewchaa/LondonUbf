using LondonUbfWeb.Domain.Interfaces;
using LondonUbfWeb.Test.Repositories;
using Ninject.Modules;

namespace LondonUbfWeb.Test.Infrastructure
{
    public class TestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRotaRepository>().To<RotaTestRepository>();
        }
    }
}
