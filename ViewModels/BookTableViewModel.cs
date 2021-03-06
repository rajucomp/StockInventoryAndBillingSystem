using StockInventoryAndBillingSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StockInventoryAndBillingSystem.Commands;
using StockInventoryAndBillingSystem.ValidationService;
using System.Windows;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows.Documents;
using System.IO;
using System.Windows.Xps.Packaging;

namespace StockInventoryAndBillingSystem.ViewModels
{
    public class BookTableViewModel : INotifyPropertyChanged
    {
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

        

        private ObservableCollection<TableDetails> _tableDetails;
        public ObservableCollection<TableDetails> TableDetails
        {
            get
            {
                return _tableDetails;
            }
            set
            {
                if(_tableDetails != value)
                {
                    _tableDetails = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private readonly ITableModelValidationService _tableModelValidationService;

        public BookTableViewModel()
        {
            TableDetails = GetData();

            _tableModelValidationService = new TableModelValidationService();

            TableDetails.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChanged);

            AddNewRowCommand = new RelayCommand(new Action<object>(AddNewTableDetail));

            ResetViewModelCommand = new RelayCommand(new Action<object>(ResetViewModel));

            DeleteRowCommand = new RelayCommand(new Action<object>(DeleteLastRow));

            
        }

        

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(GrossTotal));
            NotifyPropertyChanged(nameof(NetTotal));
        }

        private void DeleteLastRow(object obj)
        {
            if(TableDetails.Count > 1)
            {
                TableDetails.RemoveAt(TableDetails.Count - 1);
            }
        }

        private async void AddNewTableDetail(object obj)
        {
            var validationErrors = await ValidateLastRowBeforeAdding(TableDetails[TableDetails.Count - 1]);

            if(validationErrors.Count != 0)
            {
                MessageBox.Show(validationErrors[0]);
                return;
            }

            TableDetails.Add(new TableDetails());
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
            TableDetails.Clear();
            TableDetails = GetData();
            //TableDetails = new ObservableCollection<TableDetails>();
        }

        private ObservableCollection<TableDetails> GetData()
        {
            return new ObservableCollection<TableDetails>()
            {
                new TableDetails{ItemCode = 123, ItemDescription = "Test item", ItemPrice = 123.00M, ItemQuantity = 5}
            };
        }

        private decimal _grossTotal;
        public decimal GrossTotal
        {
            get
            {
                _grossTotal = TableDetails.Sum(x => x.ItemAmount);
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
                if(_vatPercentage != value)
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



    }
}
