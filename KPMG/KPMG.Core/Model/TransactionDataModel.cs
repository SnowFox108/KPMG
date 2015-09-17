using System.Collections.Generic;
using KPMG.Infrastructure.Data.Model;
using KPMG.Infrastructure.Data.Pagination;

namespace KPMG.Core.Model
{
    public class TransactionDataModel
    {
        public IEnumerable<TransactionDataDto> TransactionData { get; set; }
        public PaginationModel Paging { get; set; }
    }
}
