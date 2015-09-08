using KPMG.Infrasructure.Engine;
using KPMG.WebAPI.Infrasructure;

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
