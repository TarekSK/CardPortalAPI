using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Transaction;
using CardPortal.Domain.Dto.Transaction;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Transaction
{
    public record GetUserTransactionsQuery(int userId) : IRequest<ServiceResponse<List<TransactionReadDto>>>;

    public class GetUserTransactionsQueryHandler : IRequestHandler<GetUserTransactionsQuery, ServiceResponse<List<TransactionReadDto>>>
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IMapper _mapper;

        public GetUserTransactionsQueryHandler(ITransactionRepository TransactionRepository, IMapper mapper)
        {
            _TransactionRepository = TransactionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<TransactionReadDto>>> Handle(GetUserTransactionsQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<TransactionReadDto>>();

            try
            {
                // User Transactions - Get
                var result = await _TransactionRepository.GetUserTransactions(request.userId);

                // User Transactions - Map Transaction To Transaction Read Dto
                var userTransactions = _mapper.Map<List<TransactionReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, userTransactions, result.Errors);

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
