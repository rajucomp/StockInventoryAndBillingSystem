using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.Models
{
    public class User
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
                if (_fullName != value)
                {
                    _fullName = value;
                }
            }
        }

        private UserType _userType;
        public UserType UserType
        {
            get
            {
                return _userType;
            }
        }

        public User(string fullName, UserType userType)
        {
            _fullName = fullName;
            _userType = userType;
        }
    }
}
