using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CityModel = CardPortal.Domain.AggregateModel.Vendor.Address.City.City;

namespace CardPortal.Domain.AggregateModel.Vendor.Address.Area
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CityId { get; set; }

        #region ModelInit

        // Area - Set
        public Area(string name, int cityId)
        {
            Name = name;
            CityId = cityId;
        }

        // Area - Init
        public Area()
        {

        }

        #endregion ModelInit
    }
}
