using static CardPortal.Domain.Helper.Card.CardHelper;

namespace CardPortal.Domain.Dto.Card
{
    public class CardReadDto
    {
        public int Id { get; set; }

        public string CardNumber { get; set; } = string.Empty;

        public bool Valid { get; set; }

        public CardStateEnum State { get; set; }

        public CardTypeEnum Type { get; set; }

        public CurrencyEnum? Currency { get; set; } = null;
    }
}
