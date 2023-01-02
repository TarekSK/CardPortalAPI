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
    public record CreateUserCommand(UserWriteDto User) : IRequest<ServiceResponse>;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IUserRepository UserRepository, IMapper mapper, IMediator mediator)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ServiceResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // User - From User Write Dto - Map
                var User = _mapper.Map<UserModel>(request.User);

                // User - Created Date - Set
                User.CreatedDate = DateTime.Now.Date.ToUniversalTime();

                // User - Save
                var result = await _UserRepository.CreateUser(User);

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
