using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.AggregateModel.User.Profile;
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
        public async Task<ServiceResponse<int>> Login(Login login)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<int>();

            try
            {
                // Get User
                var user = await GetUserByUsername(login.Username);

                // Check User
                if (user.Data != null)
                {
                    // Check Password
                    if (user.Data.Password == login.Password)
                    {
                        // Change Last Login Time
                        user.Data.LastLoginTime = DateTime.Now;
                        // Update User
                        var result = await UpdateUser(user.Data);

                        // Service Response - OK
                        serviceResponse.Data = user.Data.Id;
                        serviceResponse.StatusCode = HttpStatusCode.OK;
                        serviceResponse.StatusCode = result.StatusCode;
                    }
                    else
                    {
                        // Service Response - Unauthorized
                        serviceResponse.Data = 0;
                        serviceResponse.StatusCode = HttpStatusCode.Unauthorized;
                        serviceResponse.Errors.Add("Wrong Credentials");
                    }
                }
                else
                {
                    // Service Response - NotFound
                    serviceResponse.Data = 0;
                    serviceResponse.StatusCode = HttpStatusCode.NotFound;
                    serviceResponse.Errors.Add("Wrong Credentials");
                }
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.Data = 0;
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
        public async Task<ServiceResponse> ChangeName(ChangeName changeName)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Get User
                var user = await GetUser(changeName.Id);

                // Change Last Name
                user.Data.LastName = changeName.LastName;
                // Change First Name
                user.Data.FirstName = changeName.FirstName;

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
        public async Task<ServiceResponse> ChangePassword(ChangePassword changePassword)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Get User
                var user = await GetUser(changePassword.Id);

                // Change Password
                user.Data.Password = changePassword.Password;

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

                if (user.StatusCode == HttpStatusCode.OK)
                {
                    // New Password - Generate
                    var newPassword = NewPasswordGenerate();

                    // Change Password By Requested Password
                    user.Data.Password = newPassword;

                    // Update User
                    var result = await UpdateUser(user.Data);


                    // Email Content - Get
                    string emailContent = NewPasswordEmailContent(user.Data.FirstName, newPassword);

                    // Send New Password
                    var emailSend = 
                        EmailSender.EmailSend(
                            emailTo: user.Data.Username, 
                            subject: "Your Requested Password", 
                            content: emailContent);

                    // Service Response - OK
                    serviceResponse.StatusCode = emailSend.StatusCode;
                }
                else
                {
                    // Service Response - Error
                    serviceResponse.StatusCode = HttpStatusCode.NotFound;
                }
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

        // New Password Email Content
        private string NewPasswordEmailContent(string userFirstName, string newPassword)
        {
            return $"Hello, {userFirstName}" + "\n" + "Your Requested Password is ready: " + "\n" + newPassword;
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
                var result = await _dataContext.Users.OrderBy(x => x.Id).ToListAsync();

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

                if (result != null)
                {
                    // Service Response - Data, OK
                    serviceResponse.Data = result!;
                    serviceResponse.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    // Service Response - Not Found
                    serviceResponse.StatusCode = HttpStatusCode.NotFound;
                }
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
