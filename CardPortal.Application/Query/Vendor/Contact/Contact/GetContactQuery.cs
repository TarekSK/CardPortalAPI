using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Contact.Contact;
using CardPortal.Domain.Dto.Vendor.Contact.Contact;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Contact.Contact
{
    public record GetContactQuery(int ContactId) : IRequest<ServiceResponse<ContactReadDto>>;

    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ServiceResponse<ContactReadDto>>
    {
        private readonly IContactRepository _ContactRepository;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(IContactRepository ContactRepository, IMapper mapper)
        {
            _ContactRepository = ContactRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ContactReadDto>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<ContactReadDto>();

            try
            {
                // Contact - Get
                var result = await _ContactRepository.GetContact(request.ContactId);

                // Contact - Map Contact To Contact Read Dto
                var contact = _mapper.Map<ContactReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, contact, result.Errors);

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
