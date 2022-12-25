using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Vendor.Contact.Contact
{
    public interface IContactRepository
    {
        Task<ServiceResponse<List<Contact>>> GetVendorContacts(int vendorId);

        Task<ServiceResponse<Contact>> GetContact(int contactId);

        Task<ServiceResponse<Contact>> CreateContact(Contact contact);

        Task<ServiceResponse<Contact>> UpdateContact(Contact contact);

        Task<ServiceResponse> DeleteContact(Contact contact);
    }
}
