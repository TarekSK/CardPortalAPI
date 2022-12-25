using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Vendor.Contact.ContactType;
using CardPortal.Application.Query.Vendor.Contact.ContactType;
using CardPortal.Domain.Dto.Vendor.Contact.ContactType;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class ContactTypeController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllContactTypes()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllContactTypesQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetContactType(int contactTypeId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetContactTypeQuery(contactTypeId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateContactType(ContactTypeWriteDto ContactType)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateContactTypeCommand(ContactType)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateContactType(ContactTypeWriteDto ContactType)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateContactTypeCommand(ContactType)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteContactType(ContactTypeWriteDto ContactType)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteContactTypeCommand(ContactType)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
