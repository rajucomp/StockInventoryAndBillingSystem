using StockInventoryAndBillingSystem.Commands;
using StockInventoryAndBillingSystem.Models;
using StockInventoryAndBillingSystem.ValidationService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StockInventoryAndBillingSystem.ViewModels
{
    public class Table7ViewModel : TableViewModelBase
    {
        public static Table7ViewModel Instance { get; private set; }

        static Table7ViewModel()
        {
            Instance = new Table7ViewModel();
        }

        private Table7ViewModel()
        {
            
        }
    }
}
