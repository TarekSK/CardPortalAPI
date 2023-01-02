using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Account
{
    public interface IAccountRepository
    {
        Task<ServiceResponse<List<Account>>> GetAllAccounts();

        Task<ServiceResponse<List<Account>>> GetUserAccounts(int userId);

        Task<ServiceResponse<Account>> GetAccount(int accountId);

        Task<ServiceResponse<Account>> CreateAccount(Account account);

        Task<ServiceResponse<Account>> UpdateAccount(Account account);

        Task<ServiceResponse> DeleteAccount(Account account);
    }
}
