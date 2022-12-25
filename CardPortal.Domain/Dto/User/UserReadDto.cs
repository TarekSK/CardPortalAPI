using CardPortal.Domain.Dto.Account;

namespace CardPortal.Domain.Dto.User
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public DateTime? LastLoginTime { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastPasswordChangeDate { get; set; }

        public List<AccountReadDto>? Accounts { get; set; }
    }
}
