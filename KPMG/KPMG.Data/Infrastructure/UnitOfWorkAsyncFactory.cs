using KPMG.Infrasructure.Data.Infrasructure;

namespace KPMG.Data.Infrastructure
{
    public class UnitOfWorkAsyncFactory : IUnitOfWorkAsyncFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new ContentContext());
        }
    }
}
