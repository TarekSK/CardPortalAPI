using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.Area;
using CardPortal.Domain.Dto.Vendor.Address.Area;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Address.Areas
{
    public record GetAllAreasQuery : IRequest<ServiceResponse<List<AreaReadDto>>>;

    public class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, ServiceResponse<List<AreaReadDto>>>
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IMapper _mapper;

        public GetAllAreasQueryHandler(IAreaRepository AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AreaReadDto>>> Handle(GetAllAreasQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<AreaReadDto>>();

            try
            {
                // Areas - Get
                var result = await _AreaRepository.GetAllAreas();

                // Areas - Map Area To Area Read Dto
                var Areas = _mapper.Map<List<AreaReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, Areas, result.Errors);

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
