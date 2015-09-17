using KPMG.Infrastructure.Command;

namespace KPMG.Core.Command
{
    public class TransactionDataCreateCommand : ICommand
    {
        public TransactionDataCreateCommand(string account, string description, string currencyCode, decimal amount)
        {
            Account = account;
            Description = description;
            CurrencyCode = currencyCode;
            Amount = amount;
        }
        public string Account { get; private set; }
        public string Description { get; private set; }
        public string CurrencyCode { get; private set; }
        public decimal Amount { get; private set; }

    }
}
