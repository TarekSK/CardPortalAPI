using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Card;
using CardPortal.Domain.Dto.Card;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using CardModel = CardPortal.Domain.AggregateModel.Card.Card;

namespace CardPortal.Application.Command.Card
{
    public record DeleteCardCommand(CardWriteDto Card) : IRequest<ServiceResponse>;

    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand, ServiceResponse>
    {
        private readonly ICardRepository _CardRepository;
        private readonly IMapper _mapper;

        public DeleteCardCommandHandler(ICardRepository CardRepository, IMapper mapper)
        {
            _CardRepository = CardRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Card - From Card Write Dto - Map
                var Card = _mapper.Map<CardModel>(request.Card);

                // Card - Delete
                var result = await _CardRepository.DeleteCard(Card);

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
