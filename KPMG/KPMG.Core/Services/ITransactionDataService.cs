using System.Collections.Generic;
using KPMG.Infrasructure.Data.Entity;
using KPMG.Infrasructure.Data.Model;

namespace KPMG.Core.Services
{
    public interface ITransactionDataService
    {
        IEnumerable<TransactionData> GetTransactionData(TransactionDataSearchFilter filter);
    }
}
