using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Vendor.Address.Address;
using CardPortal.Application.Query.Vendor.Address.Address;
using CardPortal.Domain.Dto.Vendor.Address.Address;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class AddressController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetVendorAddresses(int vendorId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetVendorAddressesQuery(vendorId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAddress(int addressId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetAddressQuery(addressId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateAddress(AddressWriteDto address)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateAddressCommand(address)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAddress(AddressWriteDto address)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateAddressCommand(address)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAddress(AddressWriteDto address)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteAddressCommand(address)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
