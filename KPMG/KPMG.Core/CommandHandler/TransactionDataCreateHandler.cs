using KPMG.Core.Command;
using KPMG.Infrasructure.Command;
using KPMG.Infrasructure.Data.Entity;
using KPMG.Infrasructure.Data.Infrasructure;

namespace KPMG.Core.CommandHandler
{
    public class TransactionDataCreateHandler : ICommandHandler<TransactionDataCreateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionDataCreateHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(TransactionDataCreateCommand command)
        {
            var model = new TransactionData
            {
                Account = command.Account,
                Description = command.Description,
                CurrencyCode = command.CurrencyCode,
                Amount = command.Amount
            };
            _unitOfWork.Repository<TransactionData>().Insert(model);
            _unitOfWork.SaveChanges();
            return new CommandResult(true);
        }
    }
}
