namespace CardPortal.Domain.Dto.User.Login
{
    public class TokenDto
    {
        public int UserId { get; set; }

        public string Token { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }

        public TokenDto(int userId, string token, DateTime expiration)
        {
            UserId = userId;
            Token = token;
            Expiration = expiration;
        }

        public TokenDto()
        {

        }
    }
}
