using static CardPortal.Domain.Helper.Account.AccountHelper;

namespace CardPortal.Domain.Dto.Account
{
    public class AccountReadDto
    {
        public int Id { get; set; }

        public double Balance { get; set; } = 0;

        public AccountTypeEnum Type { get; set; }

        public int UserId { get; set; }
    }
}
