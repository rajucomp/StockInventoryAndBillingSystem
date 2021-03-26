using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using StockInventoryAndBillingSystem.Models;
using StockInventoryAndBillingSystem.DataServices;
using System.Windows.Input;
using StockInventoryAndBillingSystem.ValidationService;
using System.Windows;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using StockInventoryAndBillingSystem.Commands;

namespace StockInventoryAndBillingSystem.ViewModels
{
    public class TableViewModelBase: INotifyPropertyChanged
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
                if (_customerName != value)
                {
                    _customerName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private DateTime _billDate;
        public DateTime BillDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                if (_billDate != value)
                {
                    _billDate = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private readonly ObservableCollection<User> _waiterList;

        public ObservableCollection<User> WaiterList
        {
            get
            {
                return _waiterList;
            }
        }

        private readonly ObservableCollection<User> _cashierList;

        public ObservableCollection<User> CashierList
        {
            get
            {
                return _cashierList;
            }
        }

        //private readonly ObservableCollection<Item> _itemsList;

        //public ObservableCollection<Item> ItemsList
        //{
        //    get
        //    {
        //        return _itemsList;
        //    }
        //}

        private DataService _dataService;
        protected DataService DataService
        {
            get
            {
                return _dataService;
            }
        }

        private User _selectedWaiter;
        public User SelectedWaiter
        {
            get
            {
                return _selectedWaiter;
            }
            set
            {
                if (_selectedWaiter != value)
                {
                    _selectedWaiter = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private User _selectedCashier;
        public User SelectedCashier
        {
            get
            {
                return _selectedCashier;
            }
            set
            {
                if (_selectedCashier != value)
                {
                    _selectedCashier = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private ICommand _addNewRowCommand;
        public ICommand AddNewRowCommand
        {
            get
            {
                return _addNewRowCommand;
            }
            set
            {
                _addNewRowCommand = value;
            }
        }

        private ICommand _resetViewModelCommand;
        public ICommand ResetViewModelCommand
        {
            get
            {
                return _resetViewModelCommand;
            }
            set
            {
                _resetViewModelCommand = value;
            }
        }

        private ICommand _deleteRowCommand;
        public ICommand DeleteRowCommand
        {
            get
            {
                return _deleteRowCommand;
            }
            set
            {
                _deleteRowCommand = value;
            }
        }

        private ICommand _saveOrderCommand;
        public ICommand SaveOrderCommand
        {
            get
            {
                return _saveOrderCommand;
            }
            set
            {
                _saveOrderCommand = value;
            }
        }

        private ObservableCollection<TableDetails> _tableDetails;
        public ObservableCollection<TableDetails> TableDetails
        {
            get
            {
                return _tableDetails;
            }
            set
            {
                if (_tableDetails != value)
                {
                    _tableDetails = value;
                    //foreach (var tableDetails in _tableDetails)
                    //{
                    //    tableDetails.PropertyChanged += ModelOnPropertyChanged;
                    //}
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(GrossTotal));
                }
            }
        }

        private readonly ITableModelValidationService _tableModelValidationService;

        private IEnumerable<User> GetCashiers()
        {
            return _dataService.GetCashierAsync();
        }

        private IEnumerable<User> GetWaiters()
        {
            return _dataService.GetWaitersAsync();
        }


        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(GrossTotal));
            NotifyPropertyChanged(nameof(NetTotal));
        }

        private void DeleteLastRow(object obj)
        {
            if (TableDetails.Count > 1)
            {
                TableDetails.RemoveAt(TableDetails.Count - 1);
            }
        }

        private async void AddNewTableDetail(object obj)
        {
            var validationErrors = await ValidateLastRowBeforeAdding(_tableDetails[_tableDetails.Count - 1]);

            if (validationErrors.Count != 0)
            {
                MessageBox.Show(validationErrors[0]);
                return;
            }

            _tableDetails.Add(new TableDetails());
        }

        private async Task<IList<string>> ValidateLastRowBeforeAdding(TableDetails model)
        {
            ICollection<string> validationErrors = null;

            bool isValid = await Task<bool>.Run(() =>
            {
                return _tableModelValidationService.ValidateItemCode(model.ItemCode, out validationErrors) &&
                        _tableModelValidationService.ValidateItemDescription(model.ItemDescription, out validationErrors) &&
                        _tableModelValidationService.ValidateItemQuantity(model.ItemQuantity, out validationErrors) &&
                        _tableModelValidationService.ValidateItemPrice(model.ItemPrice, out validationErrors);

            })
            .ConfigureAwait(false);

            return (IList<string>)validationErrors;

        }

        private void ResetViewModel(object obj)
        {
            _tableDetails.Clear();
            _tableDetails = GetData();
            
            //TableDetails = new ObservableCollection<TableDetails>();
        }

        private ObservableCollection<TableDetails> GetData()
        {
            return new ObservableCollection<TableDetails>()
            {
                new TableDetails()
            };
        }

        private decimal _grossTotal;
        public decimal GrossTotal
        {
            get
            {
                _grossTotal = _tableDetails.Sum(x => x.ItemAmount);
                return _grossTotal;
            }
        }

        private decimal _netTotal;
        public decimal NetTotal
        {
            get
            {
                _netTotal = GetNetTotal();
                return _netTotal;
            }
        }

        private decimal _vatPercentage;
        public decimal VatPercentage
        {
            get
            {
                return _vatPercentage;
            }
            set
            {
                if (_vatPercentage != value)
                {
                    _vatPercentage = value;
                    _netTotal = GetNetTotal();
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(NetTotal));
                }
            }
        }

        private string _modeOfPayment;
        public string ModeOfPayment
        {
            get
            {
                return _modeOfPayment;
            }
            set
            {
                if (_modeOfPayment != value)
                {
                    _modeOfPayment = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private decimal _discountAmount;
        public decimal DiscountAmount
        {
            get
            {
                return _discountAmount;
            }
            set
            {
                if (_discountAmount != value)
                {
                    _discountAmount = value;
                    _netTotal = GetNetTotal();
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(NetTotal));
                }
            }
        }

        private PaymentStatus _currentPaymentStatus;
        public PaymentStatus CurrentPaymentStatus
        {
            get
            {
                return _currentPaymentStatus;
            }
            set
            {
                if (_currentPaymentStatus != value)
                {
                    _currentPaymentStatus = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private decimal GetNetTotal()
        {
            var vatAmount = _grossTotal * _vatPercentage / 100.00M;
            return _grossTotal - _discountAmount - vatAmount;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TableViewModelBase()
        {
            _tableDetails = GetData();

            _tableModelValidationService = new TableModelValidationService();

            _dataService = new DataService();
            _waiterList = new ObservableCollection<User>(GetWaiters());
            _cashierList = new ObservableCollection<User>(GetCashiers());
            //_itemsList = new ObservableCollection<Item>(GetItems());

            _tableDetails.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);

            

            AddNewRowCommand = new RelayCommand(new Action<object>(AddNewTableDetail));

            ResetViewModelCommand = new RelayCommand(new Action<object>(ResetViewModel));

            DeleteRowCommand = new RelayCommand(new Action<object>(DeleteLastRow));

            SaveOrderCommand = new RelayCommand(new Action<object>(SaveOrder));

            _selectedWaiter = _waiterList[0];

            _selectedCashier = _cashierList[0];
        }

        private void SaveOrder(object obj)
        {
            int tableId = 2;

            var order = CreateOrder();

            order.ItemsList = new List<Item>();

            SaveItemsToOrder(order);
        }

        private void SaveItemsToOrder(Order order)
        {
            DataService.SaveItemsToOrder(order);
        }

        private Order CreateOrder()
        {
            return DataService.CreateNewOrder();
        }

        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            NotifyPropertyChanged(nameof(GrossTotal));
            NotifyPropertyChanged(nameof(NetTotal));
        }



        //private IEnumerable<Item> GetItems()
        //{
        //    return DataService.Items;
        //}
    }
}
