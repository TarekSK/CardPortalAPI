using System.ComponentModel.DataAnnotations;
using AreaModel = CardPortal.Domain.AggregateModel.Vendor.Address.Area.Area;

namespace CardPortal.Domain.AggregateModel.Vendor.Address.Address
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string StreetAddress { get; set; } = string.Empty;

        [Required]
        public int AreaId { get; set; }

        [Required]
        public int VendorId { get; set; }

        #region ModelInit

        // Address - Set
        public Address(string streetAddress, int areaId)
        {
            StreetAddress = streetAddress;
            AreaId = areaId;
        }

        // Address - Init
        public Address()
        {

        }

        #endregion ModelInit
    }
}
