using Autofac;
using KPMG.Data.Infrastructure;
using KPMG.Infrastructure.Adapter.IoC;
using KPMG.Infrastructure.Adapter.Mapping;
using KPMG.Infrastructure.Data.Infrasructure;

namespace KPMG.WebAPI.Infrastructure.AutoFacRegister
{
    public class CommonRegister : BaseRegister, IDiRegister
    {
        public CommonRegister(ContainerBuilder builder)
            : base(builder)
        {
        }

        public void Register()
        {
            Builder.RegisterType<AutoMapperAdapterFactory>().As<IMapperAdapterFactory>().SingleInstance();

            Builder.RegisterType<ContentContext>().As<IContentContext>().InstancePerLifetimeScope();
            Builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
        }
    }

}
