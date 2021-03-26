using MySql.Data.MySqlClient;
using StockInventoryAndBillingSystem.DashboardSqlStatements;
using StockInventoryAndBillingSystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInventoryAndBillingSystem.DataServices
{
    public class DataService
    {
        private static readonly string _hgiDocumentsConnectionString;
        private readonly IList<User> _users;
        public IList<User> Users
        {
            get
            {
                return _users;
            }
        }

        private static readonly IList<Item> _items;
        public static IList<Item> Items
        {
            get
            {
                return _items;
            }
        }

        static DataService()
        {
            _hgiDocumentsConnectionString = ConfigurationManager.ConnectionStrings["hgiDocumentsConnectionString"].ConnectionString;
            _items = GetItems();
        }
        public DataService()
        {
            
            _users = GetUsers();
        }

        public static Order CreateNewOrder()
        {
            Order newOrder = new Order();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_hgiDocumentsConnectionString))
                {
                    conn.Open();


                    string sql = string.Format(ItemSQLStatements.NewOrderSQLStatement, 1, 1, "NOW()", 100.00M);
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    


                    using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            newOrder.OrderId = Convert.ToInt32(mySqlDataReader["orderId"]);
                            newOrder.PaymentStatusId = Convert.ToInt32(mySqlDataReader["PaymentStatusId"]);
                            newOrder.OrderDate = Convert.ToDateTime(mySqlDataReader["OrderDate"]);
                            newOrder.OrderTotal = Convert.ToDecimal(mySqlDataReader["orderId"]);
                        }
                        mySqlDataReader.Close();
                    }

                        sql = "SELECT LAST_INSERT_ID()";
                        cmd = new MySqlCommand(sql, conn);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int r = Convert.ToInt32(result);
                        newOrder.OrderId = r;
                            Console.WriteLine("Number of countries in the world database is: " + r);
                        }



                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                string message = ex.Message.ToString();
            }

            return newOrder;
        }

        public static bool SaveItemsToOrder(Order order)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_hgiDocumentsConnectionString))
                {
                    conn.Open();

                    foreach(Item item in order.ItemsList)
                    {
                        string sql = string.Format(ItemSQLStatements.OrderDetailsInsertStatement, order.OrderId, item.ItemId, item.Quantity);
                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader())
                        {

                            mySqlDataReader.Close();
                        }
                    }

                    

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();

                return false;
            }

            return true;
        }

        private static IList<Item> GetItems()
        {
            try
            {
                IList<Item> itemsList = new List<Item>();
                MySqlConnection conn = new MySqlConnection(_hgiDocumentsConnectionString);

                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql = ItemSQLStatements.ItemSelectStatement;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    
                    using (MySqlDataReader mySqlDataReader = cmd.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            Item item = new Item()
                            {
                                ItemId = Convert.ToInt32(mySqlDataReader["itemId"]),
                                ItemCode = Convert.ToInt32(mySqlDataReader["itemCode"]),
                                ItemName = mySqlDataReader["itemDescription"].ToString(),
                                Price = mySqlDataReader["itemPrice"] != null ? Convert.ToDecimal(mySqlDataReader["itemPrice"]) : 0M,
                                Quantity = mySqlDataReader["itemQuantity"] != null ? Convert.ToDecimal(mySqlDataReader["itemQuantity"]) : 0M
                            };

                            itemsList.Add(item);
                        }
                        mySqlDataReader.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                conn.Close();


                Console.WriteLine("Done.");

                return itemsList;
            }

            catch (Exception ex)
            {
                string errorMessage = ex.Message.ToString();
                return new List<Item>();
            }

        }

        private IList<User> GetUsers()
        {
            IList<User> lst = new List<User>
            {
                new User("Pradeep", UserType.Cashier),
                new User("Raju", UserType.Cashier),
                new User("Roshan", UserType.Cashier),
                new User("Suraj", UserType.Waiter),
                new User("Suman", UserType.Waiter),
                new User("Suraj 2", UserType.Waiter)
            };

            return lst;
        }
        public IEnumerable<User> GetCashierAsync()
        {
            return _users.Where(x => x.UserType == UserType.Cashier);
        }

        public IEnumerable<User> GetWaitersAsync()
        {
            return _users.Where(x => x.UserType == UserType.Waiter);
        }
    }
}
