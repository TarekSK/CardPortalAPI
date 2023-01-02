using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Card;
using CardPortal.Domain.Dto.Card;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Card
{
    public record GetAllCardsQuery() : IRequest<ServiceResponse<List<CardReadDto>>>;

    public class GetAllCardsQueryHandler : IRequestHandler<GetAllCardsQuery, ServiceResponse<List<CardReadDto>>>
    {
        private readonly ICardRepository _CardRepository;
        private readonly IMapper _mapper;

        public GetAllCardsQueryHandler(ICardRepository CardRepository, IMapper mapper)
        {
            _CardRepository = CardRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CardReadDto>>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<CardReadDto>>();

            try
            {
                // User Cards - Get
                var result = await _CardRepository.GetAllCards();

                // User Cards - Map Card To Card Read Dto
                var userCards = _mapper.Map<List<CardReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, userCards, result.Errors);

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
