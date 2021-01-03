using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using DataLayer.Tools;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer.DataAccessObjects
{
    public class CustomerDAO : ICustomerRepository
    {
        #region Fields

        private readonly string connectionString;

        #endregion Fields

        #region Constructors

        public CustomerDAO()
        {
            connectionString = Util.GetConnectionString();
        }

        #endregion Constructors

        #region Methodes

        #region Create
        public void AddCustomer(Customer customer)
        {
            AddOrders(customer);

            string query = $"INSERT INTO dbo.Customer( Name, Address )" +
                $" VALUES (  @Name, @Address )SELECT CAST(scope_identity() AS int);";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                    cmd.CommandText = query;
                    cmd.Parameters["@Name"].Value = customer.Name;
                    cmd.Parameters["@Address"].Value = customer.Address;
                    customer.SetId((Int32)cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                AddCustomerOrderEntries(customer);
            }
        }
        #endregion

        #region Read
        public IReadOnlyList<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = $"Select CustomerId, Name, Address from dbo.Customer";
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
                            int customerId = (int)dataReader["CustomerId"];
                            string name = (string)dataReader["Name"];
                            string address = (string)dataReader["Address"];
                            Customer customer = new Customer(customerId, name, address);
                            customers.Add(customer);
                        }

                    }
                    return customers.AsReadOnly();
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

        public IReadOnlyList<Customer> GetCustomers(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            string query = $"Select CustomerId, Name, Address from dbo.Customer where CustomerId = @Id";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            Customer customer = null;
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
                            int customerId = (int)dataReader["CustomerId"];
                            string name = (string)dataReader["Name"];
                            string address = (string)dataReader["Address"];
                            customer = new Customer(customerId, name, address);
                        }
                    }
                    return customer;
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

        public Customer GetCustomerWithOrders(int id)
        {
            string query = $"Select Customer.CustomerId, Customer.Name,Customer.Address, " +
                $"OrderT.OrderId, OrderT.DateTime, OrderT.Is_Checked, OrderT.PriceAlreadyPayed " +
                $"from dbo.Customer " +
                $"JOIN CustomerOrder ON Customer.CustomerId = CustomerOrder.CustomerId " +
                $"JOIN OrderT ON CustomerOrder.OrderId = OrderT.OrderId " +
                $"AND CustomerOrder.CustomerId like @CustomerId; ";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            Customer customer = null;
            List<Order> orders = new List<Order>();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                    cmd.CommandText = query;
                    cmd.Parameters["@CustomerId"].Value = id;
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            int customerId = (int)dataReader["CustomerId"];
                            string name = (string)dataReader["Name"];
                            string address = (string)dataReader["Address"];
                            customer = new Customer(customerId, name, address);
                            orders.Add(new Order(
                                (int)dataReader["OrderId"],
                                (DateTime)dataReader["DateTime"],
                                (bool)dataReader["Is_Checked"],
                                (decimal)dataReader["PriceAlreadyPayed"]
                                ));
                        }
                        foreach (var order in orders)
                        {
                            customer.AddOrder(order);
                        }
                        return customer;
                    }
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
            return customer;
        }
        #endregion

        #region Delete
        public void RemoveCustomer(int id)
        {
            string query = $"delete from dbo.Customer where CustomerId = @Id;";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.CommandText = query;
                    cmd.Parameters["@Id"].Value = id;
                    cmd.ExecuteNonQuery();
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

        #endregion Methodes

        #region HulpMethodes
        private void AddOrders(Customer customer)
        {
            foreach (var order in customer.GetOrders())
            {
                var orderWithId = new OrderDAO().GetOrder(order.Id);
                if (orderWithId == null)
                {
                    orderWithId = order;
                    new OrderDAO().AddOrder(orderWithId);
                };
                order.SetId(orderWithId.Id);
            }
        }

        private void AddCustomerOrderEntries(Customer customer)
        {
            foreach (var order in customer.GetOrders())
            {
                string sql = "INSERT INTO CustomerOrder ( CustomerId, OrderId ) VALUES ( @CustomerId,  @OrderId );";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int);
                    cmd.Parameters.Add("@OrderId", SqlDbType.Int);
                    cmd.Parameters["@CustomerId"].Value = customer.Id;
                    cmd.Parameters["@OrderId"].Value = order.Id;
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