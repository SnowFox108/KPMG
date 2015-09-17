using Autofac;
using KPMG.Core.Services;
using KPMG.Infrastructure.Adapter.IoC;

namespace KPMG.WebAPI.Infrastructure.AutoFacRegister
{
    public class ServiceRegister : BaseRegister, IDiRegister
    {
        public ServiceRegister(ContainerBuilder builder) : base(builder)
        {
        }

        public void Register()
        {
            // shared service
            Builder.RegisterType<TransactionDataService>().As<ITransactionDataService>().InstancePerLifetimeScope();
        }
    }
}
