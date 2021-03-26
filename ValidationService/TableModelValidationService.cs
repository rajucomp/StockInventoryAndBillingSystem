using StockInventoryAndBillingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.ValidationService
{
    class TableModelValidationService : ITableModelValidationService
    {
        public bool ValidateItemCode(int itemCode, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (itemCode == 0)
            {
                validationErrors.Add("Please fill the correct item code.");
            }

            return validationErrors.Count == 0;
        }

        public bool ValidateItemDescription(string itemDescription, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (string.IsNullOrEmpty(itemDescription))
            {
                validationErrors.Add("Please select the correct item description");
            }

            return validationErrors.Count == 0;
        }

        public bool ValidateItemPrice(decimal itemPrice, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();


            if (itemPrice <= 0)
            {
                validationErrors.Add("Please fill the price");
            }

            return validationErrors.Count == 0;
        }

        public bool ValidateItemQuantity(decimal itemQuantity, out ICollection<string> validationErrors)
        {
            validationErrors = new List<string>();

            if (itemQuantity <= 0)
            {
                validationErrors.Add("Please fill the amount");
            }

            return validationErrors.Count == 0;
        }
    }
}
