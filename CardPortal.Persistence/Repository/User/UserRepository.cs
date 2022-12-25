using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UserModel = CardPortal.Domain.AggregateModel.User.User;

namespace CardPortal.Persistence.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dataContext;

        public UserRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region UserActions

        // User - Login
        public async Task<ServiceResponse<bool>> Login(string username, string password)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                // Get User
                var user = await GetUserByUsername(username);
                // Change Last Login Time
                user.Data.LastLoginTime = DateTime.Now;
                // Update User
                var result = await UpdateUser(user.Data);

                // Service Response - Data, OK
                serviceResponse.Data = true;
                serviceResponse.StatusCode = result.StatusCode;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        #endregion UserActions

        #region ProfileActions

        // User - Change Username
        public async Task<ServiceResponse> ChangeUsername(int userId, string newUsername)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Get User
                var user = await GetUser(userId);
                // Change Username
                user.Data.Username = newUsername;
                // Update User
                var result = await UpdateUser(user.Data);

                // Service Response - OK
                serviceResponse.StatusCode = result.StatusCode;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // User - Change Password
        public async Task<ServiceResponse> ChangePassword(int userId, string newPassword)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Get User
                var user = await GetUser(userId);
                // Change Password
                user.Data.Password = newPassword;
                // Update User
                var result = await UpdateUser(user.Data);

                // Service Response - OK
                serviceResponse.StatusCode = result.StatusCode;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // User - Request New Password
        public async Task<ServiceResponse<string>> RequestNewPassword(string username)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<string>();

            try
            {
                // Get User
                var user = await GetUserByUsername(username);
                // Change Password By Requested Password
                user.Data.Password = NewPasswordGenerate();
                // Update User
                var result = await UpdateUser(user.Data);

                // Service Response - OK
                serviceResponse.StatusCode = result.StatusCode;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        #region NewPasswordGenerate

        // New Password - Generate
        private string NewPasswordGenerate()
        {
            // All Posibile Chars
            const string chars = "abcefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            // To Restore Chars
            var stringChars = new char[8];

            // Random - To Be Used In Fetching
            var random = new Random();

            for (int i = 0; i < 8; i++)
            {
                // Setting Current Char as [Possible Char Of [Random Of Possible Chars]]
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        #endregion NewPasswordGenerate

        #endregion ProfileActions

        #region AdminActions

        // Users - Get
        public async Task<ServiceResponse<List<UserModel>>> GetAllUsers()
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<UserModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Users.ToListAsync();

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

        // User - Get
        public async Task<ServiceResponse<UserModel>> GetUser(int userId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

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

        // User - Get By Username
        public async Task<ServiceResponse<UserModel>> GetUserByUsername(string username)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == username);

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

        // User - Create
        public async Task<ServiceResponse<UserModel>> CreateUser(UserModel user)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                // Create
                _dataContext.Users.Add(user);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = user;
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

        // User - Update
        public async Task<ServiceResponse<UserModel>> UpdateUser(UserModel user)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                // Update
                _dataContext.Users.Update(user);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = user;
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

        // User - Delete
        public async Task<ServiceResponse> DeleteUser(UserModel user)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                // Delete
                _dataContext.Users.Remove(user);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = user;
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

        #endregion AdminActions
    }
}
