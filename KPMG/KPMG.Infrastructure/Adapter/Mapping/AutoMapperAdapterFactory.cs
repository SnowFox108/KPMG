using System;
using System.Linq;
using AutoMapper;

namespace KPMG.Infrastructure.Adapter.Mapping
{
    public class AutoMapperAdapterFactory : IMapperAdapterFactory
    {
        public AutoMapperAdapterFactory()
        {
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.BaseType == typeof(Profile));

            Mapper.Initialize(cfg =>
            {
                foreach (var item in profiles)
                {
                    if (item.FullName != "AutoMapper.SelfProfiler`2")
                        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
                }
            });

#if DEBUG
            Mapper.AssertConfigurationIsValid();
#endif
        }

        public IMapperAdapter Create()
        {
            return new AutoMapperAdapter();
        }
    }
}
