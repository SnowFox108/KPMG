using Autofac;
using KPMG.Data.Infrastructure;
using KPMG.Infrasructure.Adapter.IoC;
using KPMG.Infrasructure.Adapter.Mapping;
using KPMG.Infrasructure.Data.Infrasructure;

namespace KPMG.WebAPI.Infrasructure.AutoFacRegister
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
