using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.DataAccessObjects
{
    public class OrderDAO : IOrderRepository
    {
        #region Fields

        private readonly string connectionString;

        #endregion Fields

        #region Constructors

        public OrderDAO()
        {
            this.connectionString = Util.GetConnectionString();
        }

        #endregion Constructors

        #region Methodes

        #region Create
        public void AddOrder(Order order)
        {
            AddProducts(order);

            string query = $"INSERT INTO dbo.OrderT( DateTime, PriceAlreadyPayed, Is_Checked, CustomerId )" +
                $" VALUES (  @DateTime, @PriceAlreadyPayed, @Is_Checked, @CustomerId) SELECT CAST(scope_identity() AS int);";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@DateTime", SqlDbType.DateTime);
                    cmd.Parameters.Add("@PriceAlreadyPayed", SqlDbType.Decimal);
                    cmd.Parameters.Add("@Is_Checked", SqlDbType.Bit);
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                    cmd.CommandText = query;
                    cmd.Parameters["@DateTime"].Value = order.DateTime;
                    cmd.Parameters["@PriceAlreadyPayed"].Value = order.PriceAlreadyPayed;
                    cmd.Parameters["@Is_Checked"].Value = order.IsPayed;
                    if (order.Customer != null)
                    {
                        cmd.Parameters["@CustomerId"].Value = order.Customer.Id;
                    }
                    else
                    {
                        cmd.Parameters["@CustomerId"].Value = (object)DBNull.Value;
                    }
                    order.SetId((Int32)cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                AddOrderProductEntries(order);
            }
        }
        #endregion

        #region Read
        public Order GetOrder(int id)
        {
            string query = $"Select orderId, DateTime, Is_Checked, PriceAlreadyPayed, CustomerId from dbo.OrderT where OrderId = @Id";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            Order order = null;
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.CommandText = query;
                    cmd.Parameters["@Id"].Value = id;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            int orderId = (int)dataReader["OrderId"];
                            DateTime dateTime = (DateTime)dataReader["DateTime"];
                            bool isChecked = (bool)dataReader["Is_Checked"];
                            decimal priceAlreadyPayed = (decimal)dataReader["PriceAlreadyPayed"];
                            int? customerId = !Convert.IsDBNull(dataReader["CustomerId"]) ? (int?)dataReader["CustomerId"] : null;
                            Customer customer = GetCustomer(customerId);
                            order = new Order(orderId, dateTime, isChecked, priceAlreadyPayed, customer);
                        }
                    }
                    return order;
                }
                catch (Exception ex)
                {
                    throw new Exception("", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public IReadOnlyList<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            string query = $"Select orderId, DateTime, Is_Checked, PriceAlreadyPayed, CustomerId from dbo.OrderT;";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.CommandText = query;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            int orderId = (int)dataReader["OrderId"];
                            DateTime dateTime = (DateTime)dataReader["DateTime"];
                            bool isChecked = (bool)dataReader["Is_Checked"];
                            decimal priceAlreadyPayed = (decimal)dataReader["PriceAlreadyPayed"];
                            int? customerId = !Convert.IsDBNull(dataReader["CustomerId"]) ? (int?)dataReader["CustomerId"] : null;
                            Customer customer = GetCustomer(customerId);
                            orders.Add(new Order(orderId, dateTime, isChecked, priceAlreadyPayed, customer));
                        }

                    }
                    return orders.AsReadOnly();
                }
                catch (Exception ex)
                {
                    throw new Exception("", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public IReadOnlyList<Order> GetAllOrdersFromCustomer(int customerId)
        {
            List<Order> orders = new List<Order>();
            string query = $"Select orderId, DateTime, Is_Checked, PriceAlreadyPayed, CustomerId " +
                $"from dbo.OrderT where CustomerId = @Id";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.CommandText = query;
                    cmd.Parameters["@Id"].Value = customerId;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            int orderId = (int)dataReader["OrderId"];
                            DateTime dateTime = (DateTime)dataReader["DateTime"];
                            bool isChecked = (bool)dataReader["Is_Checked"];
                            decimal priceAlreadyPayed = (decimal)dataReader["PriceAlreadyPayed"];
                            int? idCustomer = !Convert.IsDBNull(dataReader["CustomerId"]) ? (int?)dataReader["CustomerId"] : null;
                            Customer customer = GetCustomer(idCustomer);
                            orders.Add(new Order(orderId, dateTime, isChecked, priceAlreadyPayed, customer));
                        }

                    }
                    return orders.AsReadOnly();
                }
                catch (Exception ex)
                {
                    throw new Exception("", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        #endregion

        #region Delete
        public void RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion Methodes

        #region HulpMethodes
        private Customer GetCustomer(int? customerId)
        {
            Customer customer = null;
            if (customerId != null)
            {
                CustomerDAO customerDao = new CustomerDAO();
                customer = customerDao.GetCustomer((int)customerId);
            }
            return customer;
        }

        private void AddProducts(Order order)
        {
            foreach (var product in order.GetProducts().Keys)
            {
                var productWithId = new ProductDAO().GetProductByName(product.Name);
                if (productWithId == null)
                {
                    productWithId = product;
                    new ProductDAO().AddProduct(productWithId);
                };
                product.SetId(productWithId.Id);
            }
        }

        private void AddOrderProductEntries(Order order)
        {
            foreach (var product in order.GetProducts())
            {
                string sql = "INSERT INTO OrderProduct ( OrderId, ProductId, Amount ) VALUES ( @OrderId,  @ProductId, @Amount );";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@OrderId", SqlDbType.Int);
                    cmd.Parameters.Add("@ProductId", SqlDbType.Int);
                    cmd.Parameters.Add("@Amount", SqlDbType.Int);
                    cmd.Parameters["@OrderId"].Value = order.Id;
                    cmd.Parameters["@ProductId"].Value = product.Key.Id;
                    cmd.Parameters["@Amount"].Value = product.Value;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        #endregion
    }
}