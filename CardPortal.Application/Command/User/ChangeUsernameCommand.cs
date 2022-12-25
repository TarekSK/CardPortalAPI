using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Command.User
{
    public record ChangeUsernameCommand(int userId, string newUsername) : IRequest<ServiceResponse>;

    public class ChangeUsernameCommandHandler : IRequestHandler<ChangeUsernameCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;

        public ChangeUsernameCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<ServiceResponse> Handle(ChangeUsernameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // User - Change Username
                var result = await _UserRepository.ChangeUsername(
                    userId: request.userId,
                    newUsername: request.newUsername);

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
