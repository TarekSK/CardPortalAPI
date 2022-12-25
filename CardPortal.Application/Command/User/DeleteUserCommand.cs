using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Dto.User;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using UserModel = CardPortal.Domain.AggregateModel.User.User;

namespace CardPortal.Application.Command.User
{
    public record DeleteUserCommand(UserWriteDto User) : IRequest<ServiceResponse>;

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // User - From User Write Dto - Map
                var User = _mapper.Map<UserModel>(request.User);

                // User - Delete
                var result = await _UserRepository.DeleteUser(User);

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
