namespace CardPortal.Domain.AggregateModel.User.Profile
{
    public class ChangePassword
    {
        public int Id { get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
