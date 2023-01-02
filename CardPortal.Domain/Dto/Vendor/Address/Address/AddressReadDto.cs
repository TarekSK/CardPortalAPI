using CardPortal.Domain.Dto.Vendor.Address.Area;

namespace CardPortal.Domain.Dto.Vendor.Address.Address
{
    public class AddressReadDto
    {
        public int Id { get; set; }

        public string StreetAddress { get; set; } = string.Empty;

        public int AreaId { get; set; }

        public int VendorId { get; set; }
    }
}
