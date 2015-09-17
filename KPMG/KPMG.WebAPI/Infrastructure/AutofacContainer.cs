
using System.Web.Http;
using Autofac;
using KPMG.Core.Command;
using KPMG.Infrastructure.Adapter.IoC;
using KPMG.Infrastructure.Command;

namespace KPMG.WebAPI.Infrastructure
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
            //return (TService)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICommandHandler<TransactionDataCreateCommand>));
            using (var scope = _container.BeginLifetimeScope())
            {
                return scope.Resolve<TService>();
            }
        }

    }
}
