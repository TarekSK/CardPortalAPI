namespace CardPortal.Domain.Helper.Account
{
    public static class AccountHelper
    {
        // Account Type
        // Might be turn into table if needed in the future
        public enum AccountTypeEnum
        {
            Deposit = 0,
            Credit = 1,
            Currency = 2,
        }
    }
}
