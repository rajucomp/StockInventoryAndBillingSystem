using StockInventoryAndBillingSystem.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockInventoryAndBillingSystem.ViewModels
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private ICommand _showTableCommand;
        public ICommand ShowTableCommand
        {
            get
            {
                return _showTableCommand;
            }
            set
            {
                _showTableCommand = value;
            }
        }

        private ICommand _showInventoryCommand;
        public ICommand ShowInventoryCommand
        {
            get
            {
                return _showInventoryCommand;
            }
            set
            {
                _showInventoryCommand = value;
            }
        }

        public static MainWindowViewModel Instance { get; private set; }

        static MainWindowViewModel()
        {
            Instance = new MainWindowViewModel();
        }

        private string _sourcePage;
        public string SourcePage
        {
            get
            {
                return _sourcePage;
            }
            set
            {
                if (value != null)
                {
                    _sourcePage = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged(nameof(SourcePage));
                }
            }
        }


        private Uri _frameUri;

        /// <summary>
        /// Sets and gets the FrameUri property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Uri FrameUri
        {
            get
            {
                return _frameUri;
            }
            set
            {
                _frameUri = new Uri(_sourcePage, UriKind.Relative);
            }
        }
        private MainWindowViewModel()
        {
            _sourcePage = "InventoryMainView.xaml";

            _showTableCommand = new RelayCommand(new Action<object>(ShowTable));

            _showInventoryCommand = new RelayCommand(new Action<object>(ShowInventory));
        }

        private void ShowTable(object obj)
        {
            _sourcePage = "ParentTable.xaml";
            _frameUri = new Uri(_sourcePage, UriKind.Relative);
        }

        private void ShowInventory(object obj)
        {
            _sourcePage = "InventoryMainView.xaml";
            _frameUri = new Uri(_sourcePage, UriKind.Relative);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
