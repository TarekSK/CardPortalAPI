using CardPortal.Domain.AggregateModel.Vendor.Contact.Contact;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ContactModel = CardPortal.Domain.AggregateModel.Vendor.Contact.Contact.Contact;

namespace CardPortal.Persistence.Repository.Vendor.Contact.Contact
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _dataContext;

        public ContactRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Vendor Contacts - Get
        public async Task<ServiceResponse<List<ContactModel>>> GetVendorContacts(int vendorId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<ContactModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Contacts.Where(x => x.VendorId == vendorId).OrderBy(x => x.Id).ToListAsync();

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

        // Contact - Get
        public async Task<ServiceResponse<ContactModel>> GetContact(int contactId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<ContactModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Contacts.FirstOrDefaultAsync(x => x.Id == contactId);

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

        // Contact - Create
        public async Task<ServiceResponse<ContactModel>> CreateContact(ContactModel contact)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<ContactModel>();

            try
            {
                // Create
                _dataContext.Contacts.Add(contact);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = contact;
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

        // Contact - Update
        public async Task<ServiceResponse<ContactModel>> UpdateContact(ContactModel contact)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<ContactModel>();

            try
            {
                // Update
                _dataContext.Contacts.Update(contact);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = contact;
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

        // Contact - Delete
        public async Task<ServiceResponse> DeleteContact(ContactModel contact)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.Contacts.Remove(contact);
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
