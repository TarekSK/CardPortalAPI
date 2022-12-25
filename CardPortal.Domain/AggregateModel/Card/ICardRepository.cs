using CardPortal.Domain.Helper.ServiceResponse;

namespace CardPortal.Domain.AggregateModel.Card
{
    public interface ICardRepository
    {
        Task<ServiceResponse<List<Card>>> GetUserCards(int userId);

        Task<ServiceResponse<Card>> GetCard(int cardId);

        Task<ServiceResponse<Card>> CreateCard(Card card);

        Task<ServiceResponse<Card>> UpdateCard(Card card);

        Task<ServiceResponse> DeleteCard(Card card);
    }
}
