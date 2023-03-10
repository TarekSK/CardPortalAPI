using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.AggregateModel.User.Profile;
using CardPortal.Domain.Dto.User.Profile;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Command.User
{
    public record ChangePasswordCommand(ChangePasswordDto changePassword) : IRequest<ServiceResponse>;

    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public ChangePasswordCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _UserRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Change Password Model - From Change Password Dto - Map
                var changePasswordModel = _mapper.Map<ChangePassword>(request.changePassword);

                // User - Change Password
                var result = await _UserRepository.ChangePassword(changePassword: changePasswordModel);

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
