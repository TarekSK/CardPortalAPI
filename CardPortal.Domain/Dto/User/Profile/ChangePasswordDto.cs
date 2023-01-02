namespace CardPortal.Domain.Dto.User.Profile
{
    public class ChangePasswordDto
    {
        public int Id { get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
