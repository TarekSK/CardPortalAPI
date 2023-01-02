using CardPortal.Domain.Dto.Vendor.Contact.ContactType;

namespace CardPortal.Domain.Dto.Vendor.Contact.Contact
{
    public class ContactWriteDto
    {
        public int Id { get; set; }

        public int ContactTypeId { get; set; }

        public string Value { get; set; }

        public int VendorId { get; set; }
    }
}
