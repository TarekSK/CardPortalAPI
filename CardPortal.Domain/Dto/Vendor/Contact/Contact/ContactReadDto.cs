using CardPortal.Domain.Dto.Vendor.Contact.ContactType;

namespace CardPortal.Domain.Dto.Vendor.Contact.Contact
{
    public class ContactReadDto
    {
        public int Id { get; set; }

        public ContactTypeReadDto Type { get; set; }

        public string Value { get; set; }

        public int VendorId { get; set; }
    }
}
