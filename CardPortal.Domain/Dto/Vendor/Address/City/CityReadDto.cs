using CardPortal.Domain.Dto.Vendor.Address.Area;

namespace CardPortal.Domain.Dto.Vendor.Address.City
{
    public class CityReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<AreaReadDto> Area { get; set; } = new List<AreaReadDto> { };
    }
}
