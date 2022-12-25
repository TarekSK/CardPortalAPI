using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Vendor.Contact.Contact;
using CardPortal.Application.Query.Vendor.Contact.Contact;
using CardPortal.Domain.Dto.Vendor.Contact.Contact;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class ContactController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetVendorContacts(int vendorId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetVendorContactsQuery(vendorId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetContact(int contactId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetContactQuery(contactId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact(ContactWriteDto contact)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateContactCommand(contact)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateContact(ContactWriteDto contact)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateContactCommand(contact)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteContact(ContactWriteDto contact)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteContactCommand(contact)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
