using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Vendor
{
    public interface IVendorRepository
    {
        Task<ServiceResponse<List<Vendor>>> GetAllVendors();

        Task<ServiceResponse<Vendor>> GetVendor(int vendorId);

        Task<ServiceResponse<Vendor>> CreateVendor(Vendor vendor);

        Task<ServiceResponse<Vendor>> UpdateVendor(Vendor vendor);

        Task<ServiceResponse> DeleteVendor(Vendor vendor);
    }
}
