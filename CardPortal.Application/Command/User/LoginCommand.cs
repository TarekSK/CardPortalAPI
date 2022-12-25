using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Command.User
{
    public record LoginCommand(string username, string password) : IRequest<ServiceResponse>;

    public class LoginCommandHandler : IRequestHandler<LoginCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;

        public LoginCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<ServiceResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // User - Login
                var result = await _UserRepository.Login(
                    username: request.username,
                    password: request.password);

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResponse(
                    HttpStatusCode.InternalServerError, new List<string>() { GenericError.GenericErrorMessage, ex.Message });
            }
        }
    }
}
