using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using StockInventoryAndBillingSystem.Commands;

namespace StockInventoryAndBillingSystem.ViewModels
{
    public class InventoryMainViewViewModel : INotifyPropertyChanged
    {
        private ICommand _showDashboardCommand;
        public ICommand ShowDashboardCommand
        {
            get
            {
                return _showDashboardCommand;
            }
            set
            {
                _showDashboardCommand = value;
            }
        }

        public static InventoryMainViewViewModel Instance { get; private set; }

        static InventoryMainViewViewModel()
        {
            Instance = new InventoryMainViewViewModel();
        }

        private InventoryMainViewViewModel()
        {
            _showDashboardCommand = new RelayCommand(new Action<object>(ShowDashboard));
        }

        private void ShowDashboard(object obj)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
