using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardPortal.Domain.Helper.Transaction
{
    public static class TransactionHelper
    {
        // Transaction Type
        // Might be turn into table if needed in the future
        public enum TransactionTypeEnum
        {
            Normal = 0,
            Cancelled = 1,
        }
    }
}
