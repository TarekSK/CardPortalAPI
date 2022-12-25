namespace CardPortal.Domain.Helper.Card
{
    public static class CardHelper
    {
        // Card State
        public enum CardStateEnum
        {
            Active = 0,
            Inactive = 1,
            Disabled = 2,
            Expired = 3,
        }

        // Card Type
        // Might be turn into table if needed in the future
        public enum CardTypeEnum
        {
            Forint = 0,
            Currency = 1,
            Credit = 2,
        }

        // Currency
        // Might be turn into table if needed in the future
        public enum CurrencyEnum
        {
            EUR = 0,
            USD = 1,
        }
    }
}
