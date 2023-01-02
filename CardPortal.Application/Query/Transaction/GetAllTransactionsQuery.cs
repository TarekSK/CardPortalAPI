using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Transaction;
using CardPortal.Domain.Dto.Transaction;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Transaction
{
    public record GetAllTransactionsQuery() : IRequest<ServiceResponse<List<TransactionReadDto>>>;

    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, ServiceResponse<List<TransactionReadDto>>>
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IMapper _mapper;

        public GetAllTransactionsQueryHandler(ITransactionRepository TransactionRepository, IMapper mapper)
        {
            _TransactionRepository = TransactionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<TransactionReadDto>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<TransactionReadDto>>();

            try
            {
                // All Transactions - Get
                var result = await _TransactionRepository.GetAllTransactions();

                // All Transactions - Map Transaction To Transaction Read Dto
                var AllTransactions = _mapper.Map<List<TransactionReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, AllTransactions, result.Errors);

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
