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
    public record DeleteContactCommand(ContactWriteDto Contact) : IRequest<ServiceResponse>;

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ServiceResponse>
    {
        private readonly IContactRepository _ContactRepository;
        private readonly IMapper _mapper;

        public DeleteContactCommandHandler(IContactRepository ContactRepository, IMapper mapper)
        {
            _ContactRepository = ContactRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Contact - From Contact Write Dto - Map
                var Contact = _mapper.Map<ContactModel>(request.Contact);

                // Contact - Delete
                var result = await _ContactRepository.DeleteContact(Contact);

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
