using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.Models
{
    public class Waiter
    {
        private string _fullName;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if(_fullName != value)
                {
                    _fullName = value;
                }
            }
        }

        public Waiter(string fullName)
        {
            _fullName = fullName;
        }
    }
}
