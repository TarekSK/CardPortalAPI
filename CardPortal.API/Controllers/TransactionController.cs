using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Transaction;
using CardPortal.Application.Query.Transaction;
using CardPortal.Domain.Dto.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class TransactionController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllTransactions()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllTransactionsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserTransactions(int userId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetUserTransactionsQuery(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetTransaction(int transactionId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetTransactionQuery(transactionId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction(TransactionWriteDto transaction)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateTransactionCommand(transaction)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
