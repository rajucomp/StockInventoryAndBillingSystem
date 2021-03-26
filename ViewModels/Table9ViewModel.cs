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
    public class Table9ViewModel : TableViewModelBase
    {
        public static Table9ViewModel Instance { get; private set; }

        static Table9ViewModel()
        {
            Instance = new Table9ViewModel();
        }

        private Table9ViewModel()
        {
            
        }
    }
}
