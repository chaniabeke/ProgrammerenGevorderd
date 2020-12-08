using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer.DataAccessObjects
{
    public class ProductDAO : IProductRepository
    {
        #region Fields

        private readonly string connectionString;

        #endregion Fields

        #region Constructors

        public ProductDAO()
        {
            this.connectionString = Util.GetConnectionString();
        }

        #endregion Constructors

        #region Methodes

        public Product GetProduct(int id)
        {
            string query = $"Select ProductId, Name, Price from dbo.Product where ProductId = @Id";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            Product product = null;
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
                            int productId = (int)dataReader["ProductId"];
                            string name = (string)dataReader["Name"];
                            decimal price = (decimal)dataReader["Price"];
                            product = new Product(productId, name, price);
                        }
                    }
                    return product;
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

        public IReadOnlyList<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            string query = $"INSERT INTO Product( Name, Price ) VALUES ( @Name, @Price )SELECT CAST(scope_identity() AS int);";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    cmd.CommandText = query;
                    cmd.Parameters["@Name"].Value = product.Name;
                    cmd.Parameters["@Price"].Value = product.Price;
                    product.SetId((Int32)cmd.ExecuteScalar());
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

        public void RemoveProduct(Product product)
        {
            string query = $"delete from dbo.Product where ProductId = @Id;";
            SqlConnection conn = Util.GetSqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                try
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.CommandText = query;
                    cmd.Parameters["@Id"].Value = product.Id;
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

        #endregion Methodes
    }
}