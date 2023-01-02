namespace CardPortal.Domain.Dto.User.Profile
{
    public class ChangeNameDto
    {
        public int Id { get; set; }

        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
    }
}
