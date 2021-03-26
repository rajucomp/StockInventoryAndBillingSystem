using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockInventoryAndBillingSystem.Views
{
    /// <summary>
    /// Interaction logic for StockInventory.xaml
    /// </summary>
    public partial class StockInventory : Page, INotifyPropertyChanged
    {
        public StockInventory()
        {
            InitializeComponent();
            DataContext = new StockInventoryAndBillingSystem.ViewModels.StockInventoryViewModel();
        }

        private string _language = "EN";
        public string TheLanguage
        {
            get { return _language; }
            set { _language = value; NotifyPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
