using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Account;
using CardPortal.Domain.Dto.Account;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Account
{
    public record GetUserAccountsQuery(int userId) : IRequest<ServiceResponse<List<AccountReadDto>>>;

    public class GetUserAccountsQueryHandler : IRequestHandler<GetUserAccountsQuery, ServiceResponse<List<AccountReadDto>>>
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IMapper _mapper;

        public GetUserAccountsQueryHandler(IAccountRepository AccountRepository, IMapper mapper)
        {
            _AccountRepository = AccountRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AccountReadDto>>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<AccountReadDto>>();

            try
            {
                // User Accounts - Get
                var result = await _AccountRepository.GetUserAccounts(request.userId);

                // User Accounts - Map Account To Account Read Dto
                var userAccounts = _mapper.Map<List<AccountReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, userAccounts, result.Errors);

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
