using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Transaction;
using CardPortal.Domain.Dto.Transaction;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Transaction
{
    public record GetTransactionQuery(int accountId) : IRequest<ServiceResponse<TransactionReadDto>>;

    public class GetTransactionQueryHandler : IRequestHandler<GetTransactionQuery, ServiceResponse<TransactionReadDto>>
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionQueryHandler(ITransactionRepository TransactionRepository, IMapper mapper)
        {
            _TransactionRepository = TransactionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<TransactionReadDto>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<TransactionReadDto>();

            try
            {
                // Transaction - Get
                var result = await _TransactionRepository.GetTransaction(request.accountId);

                // Transaction - Map Transaction To Transaction Read Dto
                var account = _mapper.Map<TransactionReadDto>(result.Data);

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
