using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Vendor.Address.Area
{
    public interface IAreaRepository
    {
        Task<ServiceResponse<List<Area>>> GetAllAreas();

        Task<ServiceResponse<List<Area>>> GetCityAreas(int cityId);

        Task<ServiceResponse<Area>> GetArea(int areaId);

        Task<ServiceResponse<Area>> CreateArea(Area area);

        Task<ServiceResponse<Area>> UpdateArea(Area area);

        Task<ServiceResponse> DeleteArea(Area area);
    }
}
