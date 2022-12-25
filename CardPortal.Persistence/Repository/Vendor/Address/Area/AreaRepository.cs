using CardPortal.Domain.AggregateModel.Vendor.Address.Area;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AreaModel = CardPortal.Domain.AggregateModel.Vendor.Address.Area.Area;

namespace CardPortal.Persistence.Repository.Vendor.Address.Area
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext _dataContext;

        public AreaRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Areas - Get
        public async Task<ServiceResponse<List<AreaModel>>> GetAllAreas()
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<AreaModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Areas.ToListAsync();

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

        // City Areas - Get
        public async Task<ServiceResponse<List<AreaModel>>> GetCityAreas(int cityId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<AreaModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Areas.Where(x => x.CityId == cityId).ToListAsync();

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

        // Area - Get
        public async Task<ServiceResponse<AreaModel>> GetArea(int areaId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AreaModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Areas.FirstOrDefaultAsync(x => x.Id == areaId);

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

        // Area - Create
        public async Task<ServiceResponse<AreaModel>> CreateArea(AreaModel area)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AreaModel>();

            try
            {
                // Create
                _dataContext.Areas.Add(area);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = area;
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

        // Area - Update
        public async Task<ServiceResponse<AreaModel>> UpdateArea(AreaModel area)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AreaModel>();

            try
            {
                // Update
                _dataContext.Areas.Update(area);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = area;
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

        // Area - Delete
        public async Task<ServiceResponse> DeleteArea(AreaModel area)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.Areas.Remove(area);
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
