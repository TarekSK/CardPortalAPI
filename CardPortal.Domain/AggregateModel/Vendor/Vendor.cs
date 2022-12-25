using System.ComponentModel.DataAnnotations;
using AddressModel = CardPortal.Domain.AggregateModel.Vendor.Address.Address.Address;
using ContactModel = CardPortal.Domain.AggregateModel.Vendor.Contact.Contact.Contact;

namespace CardPortal.Domain.AggregateModel.Vendor
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<AddressModel> Addresses { get; set; } = new List<AddressModel>() { };

        public List<ContactModel> Contacts { get; set; } = new List<ContactModel>() { };

        #region ModelInit

        // Vendor - Set
        public Vendor(string name, List<AddressModel> addresses, List<ContactModel> contacts)
        {
            Name = name;
            Addresses = addresses;
            Contacts = contacts;
        }

        // Vendor - Init
        public Vendor()
        {

        }

        #endregion ModelInit
    }
}
