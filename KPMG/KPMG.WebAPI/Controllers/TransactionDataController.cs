using System;
using System.Web.Http;
using System.Web.Http.Description;
using KPMG.Core.Command;
using KPMG.Core.Services;
using KPMG.Infrasructure.Command;
using KPMG.Infrasructure.Data.Model;
using KPMG.Infrasructure.Helper;

namespace KPMG.WebAPI.Controllers
{
    public class TransactionDataController : ApiController
    {
        private readonly ITransactionDataService _transactionService;
        private readonly ICommandBus _commandBus;

        public TransactionDataController(ITransactionDataService transactionService, ICommandBus commandBus)
        {
            _transactionService = transactionService;
            _commandBus = commandBus;
        }

        [ResponseType(typeof(TransactionDataDto))]
        public IHttpActionResult Get(TransactionDataSearchFilter searchFilter)
        {
            try
            {
                return Ok(_transactionService.GetTransactionData(searchFilter).MapTo<TransactionDataDto>());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(TransactionDataDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var command = new TransactionDataCreateCommand(model.Account, model.Description, model.CurrencyCode,
                    model.Amount);
                var result = _commandBus.Submit(command);
                return Ok(result.Success);
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }
    }
}
