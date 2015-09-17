using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using KPMG.Core.Command;
using KPMG.Core.Model;
using KPMG.Core.Services;
using KPMG.Infrastructure.Command;
using KPMG.Infrastructure.Data.Model;
using KPMG.Infrastructure.Data.Pagination;
using KPMG.Infrastructure.Helper;

namespace KPMG.WebAPI.Controllers
{
    [RoutePrefix("api/TransactionData")]
    public class TransactionDataController : ApiController
    {
        private readonly ITransactionDataService _transactionService;
        private readonly ICommandBus _commandBus;

        public TransactionDataController(ITransactionDataService transactionService, ICommandBus commandBus)
        {
            _transactionService = transactionService;
            _commandBus = commandBus;
        }

        [ResponseType(typeof(TransactionDataModel))]
        [HttpPost]
        [Route("Search")]
        public IHttpActionResult Search(TransactionDataSearchFilter searchFilter)
        {
            try
            {
                var model = new TransactionDataModel
                {
                    TransactionData = _transactionService.GetTransactionData(searchFilter).MapTo<TransactionDataDto>(),
                    Paging = new PaginationModel
                    {
                        TotalItems = _transactionService.GetTransactionDataCount(searchFilter),
                        ItemsPerPage = searchFilter.Filter.Paging.ItemsPerPage,
                        CurrentPage = searchFilter.Filter.Paging.CurrentPage
                    }
                };

                return Ok(model);
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

        [HttpPut]
        public async Task Put(int id, HttpRequestMessage request)
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new InvalidOperationException();

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);

            var file = provider.Contents.First();
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();
            var stream = new MemoryStream(buffer);

            using (var s = new StreamReader(stream))
            {
                var test = s;
            }
        }
    }
}
