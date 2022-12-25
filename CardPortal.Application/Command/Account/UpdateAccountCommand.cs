using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Account;
using CardPortal.Domain.Dto.Account;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using AccountModel = CardPortal.Domain.AggregateModel.Account.Account;

namespace CardPortal.Application.Command.Account
{
    public record UpdateAccountCommand(AccountWriteDto Account) : IRequest<ServiceResponse>;

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, ServiceResponse>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Account - From Account Write Dto - Map
                var account = _mapper.Map<AccountModel>(request.Account);

                // Account - Update
                var result = await _accountRepository.UpdateAccount(account);

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
