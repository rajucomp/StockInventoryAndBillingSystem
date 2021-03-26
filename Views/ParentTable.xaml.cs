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

namespace StockInventoryAndBillingSystem.Views
{
    /// <summary>
    /// Interaction logic for ParentTable.xaml
    /// </summary>
    public partial class ParentTable : Page
    {
        private readonly Uri _firstTrableUri = new Uri("Table1.xaml", UriKind.Relative);

        private readonly Uri _secondTableUri = new Uri("Table2.xaml", UriKind.Relative);

        private readonly Uri _thirdTrableUri = new Uri("Table3.xaml", UriKind.Relative);

        private readonly Uri _fourthTableUri = new Uri("Table4.xaml", UriKind.Relative);

        private readonly Uri _fifthTrableUri = new Uri("Table5.xaml", UriKind.Relative);

        private readonly Uri _sixthTableUri = new Uri("Table6.xaml", UriKind.Relative);

        private readonly Uri _seventhTrableUri = new Uri("Table7.xaml", UriKind.Relative);

        private readonly Uri _eighthTableUri = new Uri("Table8.xaml", UriKind.Relative);

        private readonly Uri _ninthTrableUri = new Uri("Table9.xaml", UriKind.Relative);

        private readonly Uri _tenthTableUri = new Uri("Table10.xaml", UriKind.Relative);
        public ParentTable()
        {
            InitializeComponent();

            frmMainContent.Source = _firstTrableUri;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //frmMainContent.Source = new Uri("Table1.xaml", UriKind.Relative);
            frmMainContent.Source = _firstTrableUri;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //frmMainContent.Source = new Uri("Table2.xaml", UriKind.Relative);
            frmMainContent.Source = _secondTableUri;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _thirdTrableUri;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _fourthTableUri;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _fifthTrableUri;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _sixthTableUri;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _seventhTrableUri;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _eighthTableUri;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _ninthTrableUri;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            frmMainContent.Source = _tenthTableUri;
        }
    }
}
