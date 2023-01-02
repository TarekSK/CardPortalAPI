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
    public record ChangeNameCommand(ChangeNameDto changeName) : IRequest<ServiceResponse>;

    public class ChangeNameCommandHandler : IRequestHandler<ChangeNameCommand, ServiceResponse>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public ChangeNameCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _UserRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(ChangeNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Change Name Model - From Change Name Dto - Map
                var changeNameModel = _mapper.Map<ChangeName>(request.changeName);

                // User - Change Name
                var result = await _UserRepository.ChangeName(changeName: changeNameModel);

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
