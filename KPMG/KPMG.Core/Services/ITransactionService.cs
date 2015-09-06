using System.Collections.Generic;
using KPMG.Infrasructure.Data.Entity;
using KPMG.Infrasructure.Data.Model;

namespace KPMG.Core.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionData> GetTransactionData(TransactionDataSearchFilter filter);
    }
}
