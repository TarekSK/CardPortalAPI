using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Contact.Contact;
using CardPortal.Domain.Dto.Vendor.Contact.Contact;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using ContactModel = CardPortal.Domain.AggregateModel.Vendor.Contact.Contact.Contact;

namespace CardPortal.Application.Command.Vendor.Contact.Contact
{
    public record UpdateContactCommand(ContactWriteDto Contact) : IRequest<ServiceResponse>;

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ServiceResponse>
    {
        private readonly IContactRepository _ContactRepository;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IContactRepository ContactRepository, IMapper mapper)
        {
            _ContactRepository = ContactRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Contact - From Contact Write Dto - Map
                var Contact = _mapper.Map<ContactModel>(request.Contact);

                // Contact - Update
                var result = await _ContactRepository.UpdateContact(Contact);

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
