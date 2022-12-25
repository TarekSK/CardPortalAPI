using CardPortal.Domain.AggregateModel.Account;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AccountModel = CardPortal.Domain.AggregateModel.Account.Account;

namespace CardPortal.Persistence.Repository.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _dataContext;

        public AccountRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // User Account - Get
        public async Task<ServiceResponse<List<AccountModel>>> GetUserAccounts(int userId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<AccountModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Accounts.Where(x => x.UserId == userId).ToListAsync();

                // Service Response - Data, OK
                serviceResponse.Data = result!;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // Account - Get
        public async Task<ServiceResponse<AccountModel>> GetAccount(int accountId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AccountModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);

                // Service Response - Data, OK
                serviceResponse.Data = result!;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // Account - Create
        public async Task<ServiceResponse<AccountModel>> CreateAccount(AccountModel account)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AccountModel>();

            try
            {
                // Create
                _dataContext.Accounts.Add(account);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = account;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // Account - Update
        public async Task<ServiceResponse<AccountModel>> UpdateAccount(AccountModel account)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AccountModel>();

            try
            {
                // Update
                _dataContext.Accounts.Update(account);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = account;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // Account - Delete
        public async Task<ServiceResponse> DeleteAccount(AccountModel account)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.Accounts.Remove(account);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }
    }
}
