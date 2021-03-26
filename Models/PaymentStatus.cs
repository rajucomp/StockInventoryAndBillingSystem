using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.Models
{
    public enum PaymentStatus
    {
        NotPaid = 0,
        Paid = 1,
        OutstandingDebt = 2
    }
}
