using System.ComponentModel.DataAnnotations;
using static CardPortal.Domain.Helper.Account.AccountHelper;

namespace CardPortal.Domain.AggregateModel.Account
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public double Balance { get; set; } = 0;

        [Required]
        public AccountTypeEnum Type { get; set; }

        [Required]
        public int UserId { get; set; }

        #region ModelInit

        // Account - Set
        public Account(double balance, AccountTypeEnum type, int userId)
        {
            Balance = balance;
            Type = type;
            UserId = userId;
        }

        // Account - Init
        public Account()
        {

        }

        #endregion ModelInit
    }
}
