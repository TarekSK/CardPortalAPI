using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.User;
using CardPortal.Domain.Dto.User;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.User
{
    public record GetAllUsersQuery : IRequest<ServiceResponse<List<UserReadDto>>>;

    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ServiceResponse<List<UserReadDto>>>
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<UserReadDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<UserReadDto>>();

            try
            {
                // Users - Get
                var result = await _UserRepository.GetAllUsers();

                // Users - Map User To User Read Dto
                var users = _mapper.Map<List<UserReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, users, result.Errors);

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
