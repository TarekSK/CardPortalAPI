using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType;
using CardPortal.Domain.Dto.Vendor.Contact.ContactType;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Contact.ContactType
{
    public record GetAllContactTypesQuery : IRequest<ServiceResponse<List<ContactTypeReadDto>>>;

    public class GetAllContactTypesQueryHandler : IRequestHandler<GetAllContactTypesQuery, ServiceResponse<List<ContactTypeReadDto>>>
    {
        private readonly IContactTypeRepository _ContactTypeRepository;
        private readonly IMapper _mapper;

        public GetAllContactTypesQueryHandler(IContactTypeRepository ContactTypeRepository, IMapper mapper)
        {
            _ContactTypeRepository = ContactTypeRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ContactTypeReadDto>>> Handle(GetAllContactTypesQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<List<ContactTypeReadDto>>();

            try
            {
                // ContactTypes - Get
                var result = await _ContactTypeRepository.GetAllContactTypes();

                // ContactTypes - Map ContactType To ContactType Read Dto
                var contactTypes = _mapper.Map<List<ContactTypeReadDto>>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, contactTypes, result.Errors);

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
