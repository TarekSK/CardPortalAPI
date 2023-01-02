using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Account;
using CardPortal.Application.Query.Account;
using CardPortal.Domain.Dto.Account;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class AccountController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllAccounts()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllAccountsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserAccounts(int userId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetUserAccountsQuery(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAccount(int accountId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetAccountQuery(accountId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(AccountWriteDto account)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateAccountCommand(account)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAccount(AccountWriteDto account)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateAccountCommand(account)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAccount(AccountWriteDto account)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteAccountCommand(account)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
