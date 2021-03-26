using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.DashboardSqlStatements
{
    public static class ItemSQLStatements
    {
        public const string ItemSelectStatement = "SELECT itemCode, itemDescription, itemQuantity, itemPrice FROM item_tbl";
    }
}
