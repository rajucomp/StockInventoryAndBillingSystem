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
    public class Table10ViewModel : TableViewModelBase
    {
        public static Table10ViewModel Instance { get; private set; }

        static Table10ViewModel()
        {
            Instance = new Table10ViewModel();
        }

        private Table10ViewModel()
        {

        }
    }

}
