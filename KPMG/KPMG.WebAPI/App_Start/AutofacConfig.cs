using KPMG.Infrastructure.Engine;
using KPMG.WebAPI.Infrastructure;

namespace KPMG.WebAPI
{
    public class AutofacConfig
    {
        public static void RegisterBinding()
        {
            // Dependancy Injection initialize
            EngineContext.Instance.Initialize(new AutofacFacotry());
        }
    }
}
