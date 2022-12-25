using CardPortal.Domain.Dto.Vendor.Address.Address;
using CardPortal.Domain.Dto.Vendor.Contact.Contact;

namespace CardPortal.Domain.Dto.Vendor
{
    public class VendorReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<AddressReadDto> Addresses { get; set; }

        public List<ContactReadDto> Contacts { get; set; }
    }
}
