using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Vendor.Address.Address
{
    public interface IAddressRepository
    {
        Task<ServiceResponse<List<Address>>> GetVendorAddresses(int vendorId);

        Task<ServiceResponse<Address>> GetAddress(int addressId);

        Task<ServiceResponse<Address>> CreateAddress(Address address);

        Task<ServiceResponse<Address>> UpdateAddress(Address address);

        Task<ServiceResponse> DeleteAddress(Address address);
    }
}
