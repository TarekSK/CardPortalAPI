using AutoMapper;
using CardPortal.Application.Helper;
using CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType;
using CardPortal.Domain.Dto.Vendor.Contact.ContactType;
using CardPortal.Domain.Helper.ServiceResponse;
using MediatR;
using System.Net;

namespace CardPortal.Application.Query.Vendor.Contact.ContactType
{
    public record GetContactTypeQuery(int ContactTypeId) : IRequest<ServiceResponse<ContactTypeReadDto>>;

    public class GetContactTypeQueryHandler : IRequestHandler<GetContactTypeQuery, ServiceResponse<ContactTypeReadDto>>
    {
        private readonly IContactTypeRepository _ContactTypeRepository;
        private readonly IMapper _mapper;

        public GetContactTypeQueryHandler(IContactTypeRepository ContactTypeRepository, IMapper mapper)
        {
            _ContactTypeRepository = ContactTypeRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ContactTypeReadDto>> Handle(GetContactTypeQuery request, CancellationToken cancellationToken)
        {
            // Services Respose - Set
            var serviceResponse = new ServiceResponse<ContactTypeReadDto>();

            try
            {
                // ContactType - Get
                var result = await _ContactTypeRepository.GetContactType(request.ContactTypeId);

                // ContactType - Map ContactType To ContactType Read Dto
                var contactType = _mapper.Map<ContactTypeReadDto>(result.Data);

                // Service Response - Set
                serviceResponse.SetServiceResponse(result.StatusCode, contactType, result.Errors);

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
