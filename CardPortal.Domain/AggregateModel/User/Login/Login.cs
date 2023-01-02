using System.ComponentModel.DataAnnotations;

namespace CardPortal.Domain.AggregateModel.User
{
    public class Login
    {
        [Required]
        [MaxLength(25)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
