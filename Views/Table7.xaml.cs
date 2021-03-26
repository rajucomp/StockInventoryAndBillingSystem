using System;
using System.Collections.Generic;
using System.Linq;
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
using StockInventoryAndBillingSystem.ViewModels;

namespace StockInventoryAndBillingSystem.Views
{
    /// <summary>
    /// Interaction logic for Table7.xaml
    /// </summary>
    public partial class Table7 : Page
    {
        public Table7()
        {
            InitializeComponent();
            this.DataContext = Table7ViewModel.Instance;
        }
    }
}
