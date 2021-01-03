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
            string query = $"INSERT INTO dbo.OrderT( DateTime, PriceAlreadyPayed, Is_Checked )" +
                $" VALUES (  @DateTime, @PriceAlreadyPayed, @Is_Checked)SELECT CAST(scope_identity() AS int);";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@DateTime", SqlDbType.DateTime);
                    cmd.Parameters.Add("@PriceAlreadyPayed", SqlDbType.Decimal);
                    cmd.Parameters.Add("@Is_Checked", SqlDbType.Bit);
                    cmd.CommandText = query;
                    cmd.Parameters["@DateTime"].Value = order.DateTime;
                    cmd.Parameters["@PriceAlreadyPayed"].Value = order.PriceAlreadyPayed;
                    cmd.Parameters["@Is_Checked"].Value = order.IsPayed;
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
            }
        }
        #endregion

        #region Read
        public Order GetOrder(int id)
        {
            string query = $"Select orderId, DateTime, Is_Checked, PriceAlreadyPayed from dbo.OrderT where OrderId = @Id";
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
                            order = new Order(orderId, dateTime);
                            order.IsPayed = isChecked;
                            order.PriceAlreadyPayed = priceAlreadyPayed;
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
            string query = $"Select orderId, DateTime, Is_Checked, PriceAlreadyPayed from dbo.OrderT;";
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
                            orders.Add(new Order(orderId, dateTime, isChecked, priceAlreadyPayed));
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

        public IReadOnlyList<Order> GetOrders(Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public void RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion Methodes
    }
}