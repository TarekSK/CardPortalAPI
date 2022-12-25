using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType
{
    public interface IContactTypeRepository
    {
        Task<ServiceResponse<List<ContactType>>> GetAllContactTypes();

        Task<ServiceResponse<ContactType>> GetContactType(int contactTypeId);

        Task<ServiceResponse<ContactType>> CreateContactType(ContactType contactType);

        Task<ServiceResponse<ContactType>> UpdateContactType(ContactType contactType);

        Task<ServiceResponse> DeleteContactType(ContactType contactType);
    }
}
