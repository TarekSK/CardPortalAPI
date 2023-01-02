using CardPortal.Domain.AggregateModel.User.Profile;
using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.User
{
    public interface IUserRepository
    {
        #region UserActions

        Task<ServiceResponse<int>> Login(Login login);

        #endregion UserActions

        #region ProfileActions

        Task<ServiceResponse> ChangeUsername(int userId, string newUsername);

        Task<ServiceResponse> ChangeName(ChangeName changeName);

        Task<ServiceResponse> ChangePassword(ChangePassword changePassword);

        Task<ServiceResponse<string>> RequestNewPassword(string username);

        #endregion ProfileActions

        #region AdminActions

        Task<ServiceResponse<List<User>>> GetAllUsers();

        Task<ServiceResponse<User>> GetUser(int userId);

        Task<ServiceResponse<User>> GetUserByUsername(string username);

        Task<ServiceResponse<User>> CreateUser(User user);

        Task<ServiceResponse<User>> UpdateUser(User user);

        Task<ServiceResponse> DeleteUser(User user);

        #endregion AdminActions
    }
}
