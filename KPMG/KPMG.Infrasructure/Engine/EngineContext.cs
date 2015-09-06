using System;
using KPMG.Infrasructure.Adapter.IoC;

namespace KPMG.Infrasructure.Engine
{
    public class EngineContext : IEngine
    {
        private EngineContext()
        {
        }

        public static EngineContext Instance
        {
            get { return Nested.instance; }
        }

        private class Nested
        {
            static Nested()
            {                
            }

            internal static readonly EngineContext instance = new EngineContext();
        }

        private IDiContainer _diContainer;
        public IDiContainer DiContainer
        {
            get
            {
                if (null == _diContainer)
                    throw new Exception("DI container has not been intialized, have you called Initialize()?");                    
                return _diContainer;                
            }
        }

        public void Initialize(IDiContainerFactory diContainerFactory)
        {
            _diContainer = diContainerFactory.Create();
        }
    }
}
