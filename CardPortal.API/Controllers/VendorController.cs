using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Vendor;
using CardPortal.Application.Query.Vendor;
using CardPortal.Domain.Dto.Vendor;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class VendorController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllVendors()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllVendorsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetVendor(int vendorId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetVendorQuery(vendorId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateVendor(VendorWriteDto vendor)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateVendorCommand(vendor)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateVendor(VendorWriteDto vendor)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateVendorCommand(vendor)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteVendor(VendorWriteDto vendor)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteVendorCommand(vendor)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
