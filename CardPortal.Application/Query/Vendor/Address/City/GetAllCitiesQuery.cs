using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.City;
using CardPortal.Domain.Dto.Vendor.Address.City;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Address.City
{
    public record GetAllCitiesQuery : IRequest<ServiceResponse<List<CityReadDto>>>;

    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, ServiceResponse<List<CityReadDto>>>
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _mapper;

        public GetAllCitiesQueryHandler(ICityRepository CityRepository, IMapper mapper)
        {
            _CityRepository = CityRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<CityReadDto>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<CityReadDto>>();

            try
            {
                // Cities - Get
                var result = await _CityRepository.GetAllCities();

                // Cities - Map City To City Read Dto
                var cities = _mapper.Map<List<CityReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, cities, result.Errors);

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
