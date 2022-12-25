using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Command.User
{
    public record RequestNewPasswordCommand(string userName) : IRequest<ServiceResponse>;

    public class RequestNewPasswordCommandHandler : IRequestHandler<RequestNewPasswordCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;

        public RequestNewPasswordCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<ServiceResponse> Handle(RequestNewPasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // User - Request New Password
                var result = await _UserRepository.RequestNewPassword(
                    username: request.userName);

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
