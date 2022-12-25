using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Vendor.Address.City;
using CardPortal.Application.Query.Vendor.Address.City;
using CardPortal.Domain.Dto.Vendor.Address.City;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class CityController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllCities()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllCitiesQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetCity(int cityId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetCityQuery(cityId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCity(CityWriteDto city)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateCityCommand(city)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCity(CityWriteDto city)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateCityCommand(city)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCity(CityWriteDto city)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteCityCommand(city)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
