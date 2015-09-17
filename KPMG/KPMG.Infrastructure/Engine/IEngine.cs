using KPMG.Infrastructure.Adapter.IoC;

namespace KPMG.Infrastructure.Engine
{
    public interface IEngine
    {
        IDiContainer DiContainer { get; }
        void Initialize(IDiContainerFactory diContainerFactory);
    }
}
