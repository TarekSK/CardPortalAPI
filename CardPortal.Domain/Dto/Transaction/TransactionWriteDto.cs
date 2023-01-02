using static CardPortal.Domain.Helper.Transaction.TransactionHelper;

namespace CardPortal.Domain.Dto.Transaction
{
    public class TransactionWriteDto
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public double Amount { get; set; }

        public TransactionTypeEnum Type { get; set; }

        public string CardNumber { get; set; } = string.Empty;

        public int VendorId { get; set; }

        public int UserId { get; set; }
    }
}
