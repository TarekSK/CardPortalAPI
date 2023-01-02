namespace CardPortal.Domain.AggregateModel.User.Profile
{
    public class ChangeName
    {
        public int Id { get; set; }

        public string LastName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
    }
}
