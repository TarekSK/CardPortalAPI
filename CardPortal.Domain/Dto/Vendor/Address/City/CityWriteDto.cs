using CardPortal.Domain.Dto.Vendor.Address.Area;

namespace CardPortal.Domain.Dto.Vendor.Address.City
{
    public class CityWriteDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<AreaWriteDto> Area { get; set; } = new List<AreaWriteDto> { };
    }
}
