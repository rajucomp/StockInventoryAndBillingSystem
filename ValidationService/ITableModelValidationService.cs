using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockInventoryAndBillingSystem.Models;

namespace StockInventoryAndBillingSystem.ValidationService
{
    public interface ITableModelValidationService
    {
        bool ValidateItemCode(int itemCode, out ICollection<string> validationErrors);
        bool ValidateItemDescription(string itemDescription, out ICollection<string> validationErrors);
        bool ValidateItemPrice(decimal itemPrice, out ICollection<string> validationErrors);
        bool ValidateItemQuantity(decimal itemQuantity, out ICollection<string> validationErrors);
    }
}
