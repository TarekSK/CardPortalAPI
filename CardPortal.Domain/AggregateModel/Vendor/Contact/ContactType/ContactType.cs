using System.ComponentModel.DataAnnotations;

namespace CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType
{
    public class ContactType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        #region ModelInit

        // Contact Type - Set
        public ContactType(string name)
        {
            Name = name;
        }

        // Contact Type - Init
        public ContactType()
        {

        }

        #endregion ModelInit
    }
}
