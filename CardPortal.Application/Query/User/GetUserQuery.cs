using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Dto.User;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.User
{
    public record GetUserQuery(int userId) : IRequest<ServiceResponse<UserReadDto>>;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ServiceResponse<UserReadDto>>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserReadDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<UserReadDto>();

            try
            {
                // User - Get
                var result = await _UserRepository.GetUser(request.userId);

                // User - Map User To User Read Dto
                var user = _mapper.Map<UserReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, user, result.Errors);

            }
            catch (Exception ex)
            {
                // Service Response - Set
                serviceResponse.SetServiceResponse(
                    HttpStatusCode.InternalServerError,
                    new List<string>() { GenericError.GenericErrorMessage, ex.Message });
            }

            return serviceResponse;
        }
    }
}
