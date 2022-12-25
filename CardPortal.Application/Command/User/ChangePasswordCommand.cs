using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Command.User
{
    public record ChangePasswordCommand(int userId, string newPassword) : IRequest<ServiceResponse>;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;

        public ChangePasswordCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<ServiceResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // User - Change Password
                var result = await _UserRepository.ChangePassword(
                    userId: request.userId, 
                    newPassword: request.newPassword);

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
