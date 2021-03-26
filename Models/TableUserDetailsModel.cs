using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.Models
{
    public class TableUserDetailsModel
    {
        private string _customerName;
        public string CustomerName
        {
            get
            {
                return _customerName;
            }
            set
            {
                if(_customerName != value)
                {
                    _customerName = value;
                }
            }
        }
    }
}
