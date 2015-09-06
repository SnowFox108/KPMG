using KPMG.Infrasructure.Adapter.IoC;

namespace KPMG.Infrasructure.Engine
{
    public interface IEngine
    {
        IDiContainer DiContainer { get; }
        void Initialize(IDiContainerFactory diContainerFactory);
    }
}
