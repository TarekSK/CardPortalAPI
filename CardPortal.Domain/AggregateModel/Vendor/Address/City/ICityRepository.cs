using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Vendor.Address.City
{
    public interface ICityRepository
    {
        Task<ServiceResponse<List<City>>> GetAllCities();

        Task<ServiceResponse<City>> GetCity(int cityId);

        Task<ServiceResponse<City>> CreateCity(City city);

        Task<ServiceResponse<City>> UpdateCity(City city);

        Task<ServiceResponse> DeleteCity(City city);
    }
}
