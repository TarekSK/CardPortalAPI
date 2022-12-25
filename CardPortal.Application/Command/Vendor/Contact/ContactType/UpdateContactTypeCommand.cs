using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType;
using CardPortal.Domain.Dto.Vendor.Contact.ContactType;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;
using ContactTypeModel = CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType.ContactType;

namespace CardPortal.Application.Command.Vendor.Contact.ContactType
{
    public record UpdateContactTypeCommand(ContactTypeWriteDto ContactType) : IRequest<ServiceResponse>;

    public class UpdateContactTypeCommandHandler : IRequestHandler<UpdateContactTypeCommand, ServiceResponse>
    {
        private readonly IContactTypeRepository _ContactTypeRepository;
        private readonly IMapper _mapper;

        public UpdateContactTypeCommandHandler(IContactTypeRepository ContactTypeRepository, IMapper mapper)
        {
            _ContactTypeRepository = ContactTypeRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(UpdateContactTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Contact Type - From Contact Type Write Dto - Map
                var ContactType = _mapper.Map<ContactTypeModel>(request.ContactType);

                // Contact Type - Update
                var result = await _ContactTypeRepository.UpdateContactType(ContactType);

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
