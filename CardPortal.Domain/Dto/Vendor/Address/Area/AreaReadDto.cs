namespace CardPortal.Domain.Dto.Vendor.Address.Area
{
    public class AreaReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CityId { get; set; }
    }
}
