using CardPortal.API.Controllers.BaseAPI;
using CardPortal.Application.Command.Card;
using CardPortal.Application.Query.Card;
using CardPortal.Domain.Dto.Card;
using Microsoft.AspNetCore.Mvc;

namespace CardPortal.API.Controllers
{
    public class CardController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult> GetAllCards()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAllCardsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUserCards(int userId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetUserCardsQuery(userId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetCard(int cardId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetCardQuery(cardId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCard(CardWriteDto card)
        {
            try
            {
                return Ok(await Mediator.Send(new CreateCardCommand(card)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateCard(CardWriteDto card)
        {
            try
            {
                return Ok(await Mediator.Send(new UpdateCardCommand(card)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCard(CardWriteDto card)
        {
            try
            {
                return Ok(await Mediator.Send(new DeleteCardCommand(card)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
