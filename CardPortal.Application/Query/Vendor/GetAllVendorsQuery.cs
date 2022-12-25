using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor;
using CardPortal.Domain.Dto.Vendor;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor
{
    public record GetAllVendorsQuery : IRequest<ServiceResponse<List<VendorReadDto>>>;

    public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, ServiceResponse<List<VendorReadDto>>>
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IMapper _mapper;

        public GetAllVendorsQueryHandler(IVendorRepository VendorRepository, IMapper mapper)
        {
            _VendorRepository = VendorRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<VendorReadDto>>> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<VendorReadDto>>();

            try
            {
                // Vendors - Get
                var result = await _VendorRepository.GetAllVendors();

                // Vendors - Map Vendor To Vendor Read Dto
                var vendors = _mapper.Map<List<VendorReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, vendors, result.Errors);

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
