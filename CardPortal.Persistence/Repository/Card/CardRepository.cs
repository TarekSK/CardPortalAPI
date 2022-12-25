using CardPortal.Domain.AggregateModel.Card;
using CardPortal.Domain.Helper.ServiceResponse;
using Microsoft.EntityFrameworkCore;
using System.Net;
using CardModel = CardPortal.Domain.AggregateModel.Card.Card;

namespace CardPortal.Persistence.Repository.Card
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _dataContext;

        public CardRepository(AppDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        // User Cards - Get
        public async Task<ServiceResponse<List<CardModel>>> GetUserCards(int userId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<List<CardModel>>();

            try
            {
                // Get Data
                var result = await _dataContext.Cards.Where(x => x.UserId == userId).ToListAsync();

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

        // Card - Get
        public async Task<ServiceResponse<CardModel>> GetCard(int cardId)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<CardModel>();

            try
            {
                // Get Data
                var result = await _dataContext.Cards.FirstOrDefaultAsync(x => x.Id == cardId);

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
        
        // Card - Create
        public async Task<ServiceResponse<CardModel>> CreateCard(CardModel card)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<CardModel>();

            try
            {
                // Create
                _dataContext.Cards.Add(card);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = card;
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

        // Card - Update
        public async Task<ServiceResponse<CardModel>> UpdateCard(CardModel card)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse<CardModel>();

            try
            {
                // Update
                _dataContext.Cards.Update(card);
                // Save
                await _dataContext.SaveChangesAsync();

                // Service Response - OK
                serviceResponse.Data = card;
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

        // Card - Delete
        public async Task<ServiceResponse> DeleteCard(CardModel card)
        {
            // Service Response - Init
            var serviceResponse = new ServiceResponse();

            try
            {
                // Delete
                _dataContext.Cards.Remove(card);
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
