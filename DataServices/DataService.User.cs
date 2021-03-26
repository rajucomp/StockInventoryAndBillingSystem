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

            //    var fileName = string.Format(@"C:\Users\guptraju\Downloads\Menu Excel.xlsx");

            //    var connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=Excel 12.0;", fileName);

            //    var adapter = new OleDbDataAdapter("SELECT * FROM [Menu$]", connectionString);
            //    var ds = new DataSet();

            //    adapter.Fill(ds, "anyNameHere");

            //    DataTable data = ds.Tables["anyNameHere"];



            //    foreach (DataRow row in data.Rows)
            //    {
            //        try
            //        {
            //            Item item = new Item()
            //            {
            //                ItemCode = Convert.ToInt32(row["Item Code"]),
            //                ItemName = row["Item Name"].ToString(),
            //                Price = row["Price"] != null ? Convert.ToDecimal(row["Price"]) : 0M,
            //                Quantity = row["Quantity"] != null ? Convert.ToDecimal(row["Quantity"]) : 0M
            //            };


            //        }
            //        catch(Exception ex)
            //        {
            //            string error = ex.Message.ToString();
            //        }


            //    }

            //    return itemsList;
            //}
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
