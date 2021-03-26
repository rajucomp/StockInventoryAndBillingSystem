using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using StockInventoryAndBillingSystem.Models;
using StockInventoryAndBillingSystem.ViewModels;

namespace StockInventoryAndBillingSystem.Views
{
    /// <summary>
    /// Interaction logic for BookTable.xaml
    /// </summary>
    public partial class BookTable : Page
    {
        //public ObservableCollection<TableDetails> TableDetails { get; set; }

        public BookTable()
        {
            InitializeComponent();

            //DataContext = this;

            //TableDetails = GetData();
        }

        

        private void Add_New_Row(object sender, RoutedEventArgs e)
        {
            //var data = new TableDetails { ItemCode = 123222, ItemDescription = "Test item", ItemPrice = 123.00M, ItemQuantity = 5 };

            //var newData = new TableDetails();

            //TableDetails.Add(newData);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //TableDetails.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
