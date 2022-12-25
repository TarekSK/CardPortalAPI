using System.ComponentModel.DataAnnotations;

namespace CardPortal.Domain.AggregateModel.User
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(25)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }

        public List<Account.Account> Accounts { get; set; }

        #region ModelInit

        // User - Set
        public User(
            string lastName, 
            string firstName, 
            string username, 
            string password, 
            DateTime lastLoginTime, 
            DateTime createdDate, 
            DateTime lastPasswordChangeDate)
        {
            LastName = lastName;
            FirstName = firstName;
            Username = username;
            Password = password;
            LastLoginTime = lastLoginTime;
            CreatedDate = createdDate;
            LastPasswordChangeDate = lastPasswordChangeDate;
        }

        // User - Init
        public User()
        {

        }

        #endregion ModelInit
    }
}
