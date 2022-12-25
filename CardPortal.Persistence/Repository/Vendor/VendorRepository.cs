using CardPortal.Domain.AggregateModel.Vendor;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VendorModel = CardPortal.Domain.AggregateModel.Vendor.Vendor;

namespace CardPortal.Persistence.Repository.Vendor
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _dataContext;

        public VendorRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Vendors - Create
        public async Task<ServiceResponse<List<VendorModel>>> GetAllVendors()
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<VendorModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Vendors.ToListAsync();

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

        // Vendor - Get
        public async Task<ServiceResponse<VendorModel>> GetVendor(int vendorId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<VendorModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Vendors.FirstOrDefaultAsync(x => x.Id == vendorId);

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

        // Vendor - Get
        public async Task<ServiceResponse<VendorModel>> CreateVendor(VendorModel vendor)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<VendorModel>();

            try
            {
                // Create
                _dataContext.Vendors.Add(vendor);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = vendor;
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

        // Vendor - Update
        public async Task<ServiceResponse<VendorModel>> UpdateVendor(VendorModel vendor)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<VendorModel>();

            try
            {
                // Update
                _dataContext.Vendors.Update(vendor);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = vendor;
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

        // Vendor - Delete
        public async Task<ServiceResponse> DeleteVendor(VendorModel vendor)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.Vendors.Remove(vendor);
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
