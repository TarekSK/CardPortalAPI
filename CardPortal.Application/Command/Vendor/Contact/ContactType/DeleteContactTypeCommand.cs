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
    public record DeleteContactTypeCommand(ContactTypeWriteDto ContactType) : IRequest<ServiceResponse>;

    public class DeleteContactTypeCommandHandler : IRequestHandler<DeleteContactTypeCommand, ServiceResponse>
    {
        private readonly IContactTypeRepository _ContactTypeRepository;
        private readonly IMapper _mapper;

        public DeleteContactTypeCommandHandler(IContactTypeRepository ContactTypeRepository, IMapper mapper)
        {
            _ContactTypeRepository = ContactTypeRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Handle(DeleteContactTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ContactType - From ContactType Write Dto - Map
                var ContactType = _mapper.Map<ContactTypeModel>(request.ContactType);

                // ContactType - Delete
                var result = await _ContactTypeRepository.DeleteContactType(ContactType);

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
