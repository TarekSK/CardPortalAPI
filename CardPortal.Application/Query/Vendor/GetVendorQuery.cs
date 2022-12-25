using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor;
using CardPortal.Domain.Dto.Vendor;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor
{
    public record GetVendorQuery(int VendorId) : IRequest<ServiceResponse<VendorReadDto>>;

    public class GetVendorQueryHandler : IRequestHandler<GetVendorQuery, ServiceResponse<VendorReadDto>>
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IMapper _mapper;

        public GetVendorQueryHandler(IVendorRepository VendorRepository, IMapper mapper)
        {
            _VendorRepository = VendorRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<VendorReadDto>> Handle(GetVendorQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<VendorReadDto>();

            try
            {
                // Vendor - Get
                var result = await _VendorRepository.GetVendor(request.VendorId);

                // Vendor - Map Vendor To Vendor Read Dto
                var vendor = _mapper.Map<VendorReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, vendor, result.Errors);

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
