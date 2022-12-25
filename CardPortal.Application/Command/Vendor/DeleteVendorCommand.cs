using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor;
using CardPortal.Domain.Dto.Vendor;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using VendorModel = CardPortal.Domain.AggregateModel.Vendor.Vendor;

namespace CardPortal.Application.Command.Vendor
{
    public record DeleteVendorCommand(VendorWriteDto Vendor) : IRequest<ServiceResponse>;

    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, ServiceResponse>
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IMapper _mapper;

        public DeleteVendorCommandHandler(IVendorRepository VendorRepository, IMapper mapper)
        {
            _VendorRepository = VendorRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Vendor - From Vendor Write Dto - Map
                var Vendor = _mapper.Map<VendorModel>(request.Vendor);

                // Vendor - Delete
                var result = await _VendorRepository.DeleteVendor(Vendor);

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
