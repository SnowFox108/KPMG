
using Autofac;
using KPMG.Infrasructure.Adapter.IoC;

namespace KPMG.WebAPI.Infrasructure
{
    public class AutofacContainer : IDiContainer
    {
        private readonly IContainer _container;

        public AutofacContainer(IContainer container)
        {
            _container = container;
        }

        public TService GetInstance<TService>() where TService : class
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                return scope.Resolve<TService>();
            }
        }

    }
}
