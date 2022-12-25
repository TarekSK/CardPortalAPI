using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Account;
using CardPortal.Domain.Dto.Account;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using AccountModel = CardPortal.Domain.AggregateModel.Account.Account;

namespace CardPortal.Application.Query.Account
{
    public record GetAccountQuery(int accountId) : IRequest<ServiceResponse<AccountReadDto>>;

    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, ServiceResponse<AccountReadDto>>
    {
        private readonly IAccountRepository _AccountRepository;
        private readonly IMapper _mapper;

        public GetAccountQueryHandler(IAccountRepository AccountRepository, IMapper mapper)
        {
            _AccountRepository = AccountRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AccountReadDto>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<AccountReadDto>();

            try
            {
                // Account - Get
                var result =  await _AccountRepository.GetAccount(request.accountId);

                // Account - Map Account To Account Read Dto
                var account = _mapper.Map<AccountReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, account, result.Errors);

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
