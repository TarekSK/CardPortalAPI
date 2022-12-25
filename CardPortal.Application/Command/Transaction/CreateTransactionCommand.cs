using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Transaction;
using CardPortal.Domain.Dto.Transaction;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using TransactionModel = CardPortal.Domain.AggregateModel.Transaction.Transaction;

namespace CardPortal.Application.Command.Transaction
{
    public record CreateTransactionCommand(TransactionWriteDto Transaction) : IRequest<ServiceResponse>;

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ServiceResponse>
    {
        private readonly ITransactionRepository _TransactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(ITransactionRepository TransactionRepository, IMapper mapper)
        {
            _TransactionRepository = TransactionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Transaction - From Transaction Write Dto - Map
                var Transaction = _mapper.Map<TransactionModel>(request.Transaction);

                // Transaction - Save
                var result = await _TransactionRepository.CreateTransaction(Transaction);

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
