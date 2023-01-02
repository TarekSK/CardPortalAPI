using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Account;
using CardPortal.Domain.Dto.Account;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Account
{
    public record GetAllAccountsQuery() : IRequest<ServiceResponse<List<AccountReadDto>>>;

    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, ServiceResponse<List<AccountReadDto>>>
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IMapper _mapper;

        public GetAllAccountsQueryHandler(IAccountRepository AccountRepository, IMapper mapper)
        {
            _AccountRepository = AccountRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AccountReadDto>>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<AccountReadDto>>();

            try
            {
                // All Accounts - Get
                var result = await _AccountRepository.GetAllAccounts();

                // All Accounts - Map Account To Account Read Dto
                var AllAccounts = _mapper.Map<List<AccountReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, AllAccounts, result.Errors);

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
