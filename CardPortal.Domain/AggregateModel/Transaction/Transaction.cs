using System.ComponentModel.DataAnnotations;
using static CardPortal.Domain.Helper.Transaction.TransactionHelper;

namespace CardPortal.Domain.AggregateModel.Transaction
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public TransactionTypeEnum Type { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int UserId { get; set; }

        #region ModelInit

        // Transaction - Set
        public Transaction(
            DateTime date, 
            double amount, 
            TransactionTypeEnum type, 
            string cardNumber, 
            int vendorId,
            int userId)
        {
            Date = date;
            Amount = amount;
            Type = type;
            CardNumber = cardNumber;
            VendorId = vendorId;
            UserId = userId;
        }

        // Transaction - Init
        public Transaction()
        {

        }

        #endregion ModelInit
    }
}
