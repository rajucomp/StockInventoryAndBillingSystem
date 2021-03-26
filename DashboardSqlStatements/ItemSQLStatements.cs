using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.DashboardSqlStatements
{
    public static class ItemSQLStatements
    {
        public const string ItemSelectStatement = "SELECT itemId, itemCode, itemDescription, itemQuantity, itemPrice FROM item_tbl";

        public const string NewOrderSQLStatement = @"INSERT INTO order_tbl(customerId, paymentStatusId, orderDate, orderTotal) VALUES( {0}, {1}, {2}, {3})";

        public const string OrderDetailsInsertStatement = @"INSERT INTO orderDetails_tbl (orderId, itemId, itemQuantity) VALUES( {0}, {1}, {2})";
    }
}
