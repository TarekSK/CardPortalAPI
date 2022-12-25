using System.ComponentModel.DataAnnotations;
using AreaModel = CardPortal.Domain.AggregateModel.Vendor.Address.Area.Area;

namespace CardPortal.Domain.AggregateModel.Vendor.Address.City
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<AreaModel> Area { get; set; } = new List<AreaModel> { };

        #region ModelInit

        // City - Set
        public City(string name, List<AreaModel> area)
        {
            Name = name;
            Area = area;
        }

        // City - Init
        public City()
        {

        }

        #endregion ModelInit
    }
}
