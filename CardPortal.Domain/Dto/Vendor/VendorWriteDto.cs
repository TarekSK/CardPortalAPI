using CardPortal.Domain.Dto.Vendor.Address.Address;
using CardPortal.Domain.Dto.Vendor.Contact.Contact;

namespace CardPortal.Domain.Dto.Vendor
{
    public class VendorWriteDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<AddressWriteDto>? Addresses { get; set; }

        public List<ContactWriteDto>? Contacts { get; set; }
    }
}
