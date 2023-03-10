using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Address.Address;
using CardPortal.Domain.Dto.Vendor.Address.Address;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using AddressModel = CardPortal.Domain.AggregateModel.Vendor.Address.Address.Address;

namespace CardPortal.Application.Command.Vendor.Address.Address
{
    public record DeleteAddressCommand(AddressWriteDto Address) : IRequest<ServiceResponse>;

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, ServiceResponse>
    {
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _mapper;

        public DeleteAddressCommandHandler(IAddressRepository AddressRepository, IMapper mapper)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Address - From Address Write Dto - Map
                var Address = _mapper.Map<AddressModel>(request.Address);

                // Address - Delete
                var result = await _AddressRepository.DeleteAddress(Address);

                return result;
            }
            catch (Exception ex)
            {
                return new ServiceResponse(
                    HttpStatusCode.InternalServerError, new List<string>() { GenericError.GenericErrorMessage, ex.Message });
            }
        }
    }
}
