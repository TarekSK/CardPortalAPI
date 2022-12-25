using CardPortal.Domain.AggregateModel.Vendor.Address.City;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using CityModel = CardPortal.Domain.AggregateModel.Vendor.Address.City.City;

namespace CardPortal.Persistence.Repository.Vendor.Address.City
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _dataContext;

        public CityRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Cities - Get
        public async Task<ServiceResponse<List<CityModel>>> GetAllCities()
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<CityModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Cities.OrderBy(x => x.Id).ToListAsync();

                // Service Response - Data, OK
                serviceResponse.Data = result;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // City - Get
        public async Task<ServiceResponse<CityModel>> GetCity(int cityId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<CityModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Cities.FirstOrDefaultAsync(x => x.Id == cityId);

                // Service Response - Data, OK
                serviceResponse.Data = result!;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // City - Create
        public async Task<ServiceResponse<CityModel>> CreateCity(CityModel city)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<CityModel>();

            try
            {
                // Create
                _dataContext.Cities.Add(city);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = city;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // City - Update
        public async Task<ServiceResponse<CityModel>> UpdateCity(CityModel city)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<CityModel>();

            try
            {
                // Update
                _dataContext.Cities.Update(city);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - Data, OK
                serviceResponse.Data = city;
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }

        // City - Delete
        public async Task<ServiceResponse> DeleteCity(CityModel city)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.Cities.Remove(city);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                // Service Response - Error
                serviceResponse.StatusCode = HttpStatusCode.InternalServerError;
                serviceResponse.Errors.Add(ex.Message);
            }

            return serviceResponse;
        }
    }
}
