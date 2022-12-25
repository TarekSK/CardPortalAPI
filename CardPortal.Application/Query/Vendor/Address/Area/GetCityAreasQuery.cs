using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.Area;
using CardPortal.Domain.Dto.Vendor.Address.Area;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Address.Area
{
    public record GetCityAreasQuery(int CityId) : IRequest<ServiceResponse<List<AreaReadDto>>>;

    public class GetCityAreasQueryHandler : IRequestHandler<GetCityAreasQuery, ServiceResponse<List<AreaReadDto>>>
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IMapper _mapper;

        public GetCityAreasQueryHandler(IAreaRepository AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AreaReadDto>>> Handle(GetCityAreasQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<AreaReadDto>>();

            try
            {
                // City Areas - Get
                var result = await _AreaRepository.GetCityAreas(request.CityId);

                // City Areas - Map Area To Area Read Dto
                var cityAreas = _mapper.Map<List<AreaReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, cityAreas, result.Errors);

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
