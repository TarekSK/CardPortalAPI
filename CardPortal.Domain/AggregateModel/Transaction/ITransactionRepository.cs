using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Transaction
{
    public interface ITransactionRepository
    {
        Task<ServiceResponse<List<Transaction>>> GetAllTransactions();

        Task<ServiceResponse<List<Transaction>>> GetUserTransactions(int userId);

        Task<ServiceResponse<Transaction>> GetTransaction(int transactionId);

        Task<ServiceResponse<Transaction>> CreateTransaction(Transaction transaction);
    }
}
