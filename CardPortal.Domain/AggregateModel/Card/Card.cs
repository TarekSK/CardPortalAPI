using CardPortal.Domain.Helper.Card;
using System.ComponentModel.DataAnnotations;
using static CardPortal.Domain.Helper.Card.CardHelper;

namespace CardPortal.Domain.AggregateModel.Card
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [MinLength(16)]
        [MaxLength(16)]
        [Required]
        public string CardNumber { get; set; } = string.Empty;

        public bool Valid { get; set; }

        [Required]
        public CardStateEnum State { get; set; }

        [Required]
        public CardTypeEnum Type { get; set; }

        public CurrencyEnum? Currency { get; set; } = null;

        [Required]
        public int UserId { get; set; }

        #region ModelInit

        // Card - Set
        public Card(
            string cardNumber, 
            CardStateEnum state, 
            CardTypeEnum type, 
            int userId,
            CurrencyEnum? currency = null)
        {
            CardNumber = cardNumber;
            Valid = CardValidator.CardNumberValidator(cardNumber: cardNumber);
            State = state;
            Type = type;
            UserId = userId;
            Currency = currency;
        }

        // Card - Init
        public Card()
        {

        }

        #endregion ModelInit
    }
}
