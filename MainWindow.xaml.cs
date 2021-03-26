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

namespace StockInventoryAndBillingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Uri _tableUri = new Uri(@"Views\ParentTable.xaml", UriKind.Relative);

        private readonly Uri _inventoryUri = new Uri(@"Views\InventoryMainView.xaml", UriKind.Relative);

        public MainWindow()
        {
            InitializeComponent();

            //this.DataContext = MainWindowViewModel.Instance;

            frmMainContent.Source = _tableUri;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _tableUri;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _inventoryUri;
        }
    }
}
