using KPMG.Infrasructure.Data.Infrasructure;

namespace KPMG.Core.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

    }
}
