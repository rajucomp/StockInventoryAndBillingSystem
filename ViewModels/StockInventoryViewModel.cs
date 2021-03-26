using StockInventoryAndBillingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.ViewModels
{
    public class StockInventoryViewModel
    {
        public VacationSpots vacationSpots { get; set; }

        public StockInventoryViewModel()
        {
            vacationSpots = new VacationSpots();
        }
    }
}
