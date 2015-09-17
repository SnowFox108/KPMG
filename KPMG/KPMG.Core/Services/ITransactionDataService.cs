using System.Collections.Generic;
using KPMG.Infrastructure.Data.Entity;
using KPMG.Infrastructure.Data.Model;

namespace KPMG.Core.Services
{
    public interface ITransactionDataService
    {
        IEnumerable<TransactionData> GetTransactionData(TransactionDataSearchFilter filter);
        int GetTransactionDataCount(TransactionDataSearchFilter filter);
    }
}
