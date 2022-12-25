using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Vendor.Address.Area;
using CardPortal.Application.Query.Vendor.Address.Area;
using CardPortal.Application.Query.Vendor.Address.Areas;
using CardPortal.Domain.Dto.Vendor.Address.Area;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class AreaController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllAreas()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllAreasQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetCityAreas(int cityId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetCityAreasQuery(cityId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetArea(int areaId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetAreaQuery(areaId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateArea(AreaWriteDto area)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateAreaCommand(area)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateArea(AreaWriteDto area)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateAreaCommand(area)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteArea(AreaWriteDto area)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteAreaCommand(area)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
