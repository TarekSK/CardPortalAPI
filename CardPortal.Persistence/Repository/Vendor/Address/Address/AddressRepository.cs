using CardPortal.Domain.AggregateModel.Vendor.Address.Address;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using AddressModel = CardPortal.Domain.AggregateModel.Vendor.Address.Address.Address;

namespace CardPortal.Persistence.Repository.Vendor.Address.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dataContext;

        public AddressRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Vendor Addresses - Get
        public async Task<ServiceResponse<List<AddressModel>>> GetVendorAddresses(int vendorId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<AddressModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Addresses.Where(x => x.VendorId == vendorId).ToListAsync();

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

        // Address - Get
        public async Task<ServiceResponse<AddressModel>> GetAddress(int addressId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AddressModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);

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

        // Address - Create
        public async Task<ServiceResponse<AddressModel>> CreateAddress(AddressModel address)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AddressModel>();

            try
            {
                // Create
                _dataContext.Addresses.Add(address);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = address;
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

        // Address - Update
        public async Task<ServiceResponse<AddressModel>> UpdateAddress(AddressModel address)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<AddressModel>();

            try
            {
                // Update
                _dataContext.Addresses.Update(address);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = address;
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

        // Address - Delete
        public async Task<ServiceResponse> DeleteAddress(AddressModel address)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.Addresses.Remove(address);
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
