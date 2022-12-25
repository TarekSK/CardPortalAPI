using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.Area;
using CardPortal.Domain.Dto.Vendor.Address.Area;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Address.Area
{
    public record GetAreaQuery(int AreaId) : IRequest<ServiceResponse<AreaReadDto>>;

    public class GetAreaQueryHandler : IRequestHandler<GetAreaQuery, ServiceResponse<AreaReadDto>>
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IMapper _mapper;

        public GetAreaQueryHandler(IAreaRepository AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AreaReadDto>> Handle(GetAreaQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<AreaReadDto>();

            try
            {
                // Area - Get
                var result = await _AreaRepository.GetArea(request.AreaId);

                // Area - Map Area To Area Read Dto
                var area = _mapper.Map<AreaReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, area, result.Errors);

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
