using StockInventoryAndBillingSystem.DataServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.Models
{
    public class TableDetails : INotifyPropertyChanged
    {
        public TableDetails()
        {
            _itemsList = new ObservableCollection<Item>(GetItems());
        }

        private readonly ObservableCollection<Item> _itemsList;

        public ObservableCollection<Item> ItemsList
        {
            get
            {
                return _itemsList;
            }
        }

        private IEnumerable<Item> GetItems()
        {
            return DataService.Items;
        }

        private Item _selectedMenuItem;

        public Item SelectedMenuItem
        {
            get
            {
                return _selectedMenuItem;
            }
            set
            {
                if (_selectedMenuItem != value)
                {
                    _selectedMenuItem = value;
                    PopulateCurrentRowAccordingToSelectedValue(_selectedMenuItem);

                    NotifyPropertyChanged();
                }
            }
        }

        private void PopulateCurrentRowAccordingToSelectedValue(Item selectedItem)
        {
            ItemCode = selectedItem.ItemCode;
            ItemDescription = selectedItem.ItemName;
            ItemQuantity = selectedItem.Quantity;
            ItemPrice = selectedItem.Price;
        }

        private int _itemCode;
        public int ItemCode
        {
            get
            {
                return _itemCode;
            }
            set
            {
                if (_itemCode != value)
                {
                    _itemCode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string ItemDescription { get; set; }


        private decimal _itemQuantity;
        public decimal ItemQuantity 
        { 
            get
            {
                return _itemQuantity;
            }
        
            set
            {
                if(_itemQuantity != value)
                {
                    _itemQuantity = value;
                    _itemAmount = _itemQuantity * _itemPrice;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(ItemAmount));
                }
            }
        }

        private decimal _itemPrice;
        public decimal ItemPrice
        {
            get
            {
                return _itemPrice;
            }

            set
            {
                if (_itemPrice != value)
                {
                    _itemPrice = value;
                    _itemAmount = _itemQuantity * _itemPrice;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(ItemAmount));
                }
            }
        }

        private decimal _itemAmount;
        public decimal ItemAmount
        {
            get
            {
                _itemAmount = _itemQuantity * _itemPrice;
                return _itemAmount;
            }
        }

        //public TableDetails()
        //{

        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
