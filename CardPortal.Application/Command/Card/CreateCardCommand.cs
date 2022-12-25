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
    public record CreateCardCommand(CardWriteDto Card) : IRequest<ServiceResponse>;

    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, ServiceResponse>
    {
        private readonly ICardRepository _CardRepository;
        private readonly IMapper _mapper;

        public CreateCardCommandHandler(ICardRepository CardRepository, IMapper mapper)
        {
            _CardRepository = CardRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Card - From Card Write Dto - Map
                var Card = _mapper.Map<CardModel>(request.Card);

                // Card - Save
                var result = await _CardRepository.CreateCard(Card);

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
