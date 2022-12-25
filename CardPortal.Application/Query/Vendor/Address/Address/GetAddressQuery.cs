using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.Address;
using CardPortal.Domain.Dto.Vendor.Address.Address;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Address.Address
{
    public record GetAddressQuery(int AddressId) : IRequest<ServiceResponse<AddressReadDto>>;

    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, ServiceResponse<AddressReadDto>>
    {
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IAddressRepository AddressRepository, IMapper mapper)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AddressReadDto>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<AddressReadDto>();

            try
            {
                // Address - Get
                var result = await _AddressRepository.GetAddress(request.AddressId);

                // Address - Map Address To Address Read Dto
                var address = _mapper.Map<AddressReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, address, result.Errors);

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
