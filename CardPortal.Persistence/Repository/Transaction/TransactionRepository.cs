using CardPortal.Domain.AggregateModel.Transaction;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TransactionModel = CardPortal.Domain.AggregateModel.Transaction.Transaction;

namespace CardPortal.Persistence.Repository.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _dataContext;

        public TransactionRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Transactions - Get
        public async Task<ServiceResponse<List<TransactionModel>>> GetAllTransactions()
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<TransactionModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Transactions.OrderBy(x => x.Id).ToListAsync();

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

        // User Transactions - Get
        public async Task<ServiceResponse<List<TransactionModel>>> GetUserTransactions(int userId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<TransactionModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Transactions.Where(x => x.UserId == userId).OrderBy(x => x.Id).ToListAsync();

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

        // Transaction - Get
        public async Task<ServiceResponse<TransactionModel>> GetTransaction(int transactionId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<TransactionModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Transactions.FirstOrDefaultAsync(x => x.Id == transactionId);

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

        // Transaction - Create
        public async Task<ServiceResponse<TransactionModel>> CreateTransaction(TransactionModel transaction)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<TransactionModel>();

            try
            {
                // Create
                _dataContext.Transactions.Add(transaction);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = transaction;
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
