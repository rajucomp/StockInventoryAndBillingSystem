using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int ItemCode { get; set; }

        public string ItemName { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
