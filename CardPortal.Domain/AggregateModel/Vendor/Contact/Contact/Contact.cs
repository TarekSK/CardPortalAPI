using System.ComponentModel.DataAnnotations;
using ContactTypeModel = CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType.ContactType;

namespace CardPortal.Domain.AggregateModel.Vendor.Contact.Contact
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ContactTypeId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Value { get; set; } = string.Empty;

        [Required]
        public int VendorId { get; set; }

        #region ModelInit

        // Contact - Set
        public Contact(int contactTypeId, string value)
        {
            ContactTypeId = contactTypeId;
            Value = value;
        }

        // Contact - Init
        public Contact()
        {

        }

        #endregion ModelInit
    }
}
