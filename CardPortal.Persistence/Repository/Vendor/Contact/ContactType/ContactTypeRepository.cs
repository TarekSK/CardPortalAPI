using CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ContactTypeModel = CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType.ContactType;

namespace CardPortal.Persistence.Repository.Vendor.Contact.ContactType
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private readonly AppDbContext _dataContext;

        public ContactTypeRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Contact Types - Get
        public async Task<ServiceResponse<List<ContactTypeModel>>> GetAllContactTypes()
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<ContactTypeModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.ContactTypes.ToListAsync();

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

        // Contact Type - Get
        public async Task<ServiceResponse<ContactTypeModel>> GetContactType(int contactTypeId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<ContactTypeModel>();

            try
            {
                // Get Data
                var result = await _dataContext.ContactTypes.FirstOrDefaultAsync(x => x.Id == contactTypeId);

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
        
        // Contact Type - Create
        public async Task<ServiceResponse<ContactTypeModel>> CreateContactType(ContactTypeModel contactType)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<ContactTypeModel>();

            try
            {
                // Create
                _dataContext.ContactTypes.Add(contactType);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = contactType;
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

        // Contact Type - Update
        public async Task<ServiceResponse<ContactTypeModel>> UpdateContactType(ContactTypeModel contactType)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<ContactTypeModel>();

            try
            {
                // Update
                _dataContext.ContactTypes.Update(contactType);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = contactType;
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

        // Contact Type - Delete
        public async Task<ServiceResponse> DeleteContactType(ContactTypeModel contactType)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.ContactTypes.Remove(contactType);
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
