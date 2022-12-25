using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.Address;
using CardPortal.Domain.Dto.Vendor.Address.Address;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Address.Address
{
    public record GetVendorAddressesQuery(int vendorId) : IRequest<ServiceResponse<List<AddressReadDto>>>;

    public class GetVendorAddressesQueryHandler : IRequestHandler<GetVendorAddressesQuery, ServiceResponse<List<AddressReadDto>>>
    {
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _mapper;

        public GetVendorAddressesQueryHandler(IAddressRepository AddressRepository, IMapper mapper)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AddressReadDto>>> Handle(GetVendorAddressesQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<AddressReadDto>>();

            try
            {
                // Vendor Addresses - Get
                var result = await _AddressRepository.GetVendorAddresses(request.vendorId);

                // Vendor Addresses - Map Address To Address Read Dto
                var vendorAddresses = _mapper.Map<List<AddressReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, vendorAddresses, result.Errors);

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
