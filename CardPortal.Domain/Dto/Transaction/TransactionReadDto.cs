using static CardPortal.Domain.Helper.Transaction.TransactionHelper;

namespace CardPortal.Domain.Dto.Transaction
{
    public class TransactionReadDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Amount { get; set; }

        public TransactionTypeEnum Type { get; set; }

        public string CardNumber { get; set; }= string.Empty;

        public int VendorId { get; set; }
    }
}
