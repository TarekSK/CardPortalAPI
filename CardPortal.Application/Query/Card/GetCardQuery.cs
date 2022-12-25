using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Card;
using CardPortal.Domain.Dto.Card;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Card
{
    public record GetCardQuery(int cardId) : IRequest<ServiceResponse<CardReadDto>>;

    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, ServiceResponse<CardReadDto>>
    {
        private readonly ICardRepository _CardRepository;
        private readonly IMapper _mapper;

        public GetCardQueryHandler(ICardRepository CardRepository, IMapper mapper)
        {
            _CardRepository = CardRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CardReadDto>> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<CardReadDto>();

            try
            {
                // Card - Get
                var result = await _CardRepository.GetCard(request.cardId);

                // Card - Map Card To Card Read Dto
                var card = _mapper.Map<CardReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, card, result.Errors);

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
