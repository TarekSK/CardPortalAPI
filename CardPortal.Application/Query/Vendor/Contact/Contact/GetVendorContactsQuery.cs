using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Contact.Contact;
using CardPortal.Domain.Dto.Vendor.Contact.Contact;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Contact.Contact
{
    public record GetVendorContactsQuery(int vendorId) : IRequest<ServiceResponse<List<ContactReadDto>>>;

    public class GetVendorContactsQueryHandler : IRequestHandler<GetVendorContactsQuery, ServiceResponse<List<ContactReadDto>>>
    {
        private readonly IContactRepository _ContactRepository;
        private readonly IMapper _mapper;

        public GetVendorContactsQueryHandler(IContactRepository ContactRepository, IMapper mapper)
        {
            _ContactRepository = ContactRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ContactReadDto>>> Handle(GetVendorContactsQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<ContactReadDto>>();

            try
            {
                // Vendor Contacts - Get
                var result = await _ContactRepository.GetVendorContacts(request.vendorId);

                // Vendor Contacts - Map Contact To Contact Read Dto
                var vendorContacts = _mapper.Map<List<ContactReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, vendorContacts, result.Errors);

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
