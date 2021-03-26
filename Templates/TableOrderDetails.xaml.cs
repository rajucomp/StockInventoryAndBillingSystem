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

namespace StockInventoryAndBillingSystem.Templates
{
    /// <summary>
    /// Interaction logic for TableOrderDetails.xaml
    /// </summary>
    public partial class TableOrderDetails : UserControl
    {
        public TableOrderDetails()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button is clicked.");

            PrintDialog printDlg = new PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                //get selected printer capabilities
                System.Printing.PrintCapabilities capabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);

                //get scale of the print wrt to screen of WPF visual
                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / this.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
                       this.ActualHeight);

                //Transform the Visual to scale
                this.LayoutTransform = new ScaleTransform(scale, scale);

                //get the size of the printer page
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

                //update the layout of the visual to the printer page size.
                this.Measure(sz);
                this.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

                //now print the visual to printer to fit on the one page.
                printDlg.PrintVisual(this.tableGrid, "First Fit to Page WPF Print");

            }
        }
    }
}
