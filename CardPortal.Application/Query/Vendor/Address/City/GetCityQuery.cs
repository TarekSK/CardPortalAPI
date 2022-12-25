using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.City;
using CardPortal.Domain.Dto.Vendor.Address.City;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;


namespace CardPortal.Application.Query.Vendor.Address.City
{
    public record GetCityQuery(int CityId) : IRequest<ServiceResponse<CityReadDto>>;

    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, ServiceResponse<CityReadDto>>
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;

        public GetCityQueryHandler(ICityRepository CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CityReadDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<CityReadDto>();

            try
            {
                // City - Get
                var result = await _CityRepository.GetCity(request.CityId);

                // City - Map City To City Read Dto
                var city = _mapper.Map<CityReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, city, result.Errors);

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
