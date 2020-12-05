using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataAccessObjects
{
    public class ProductDAO
    {
        #region Fields
        private readonly string connectionString;
        #endregion

        #region Constructors
        public ProductDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region Methodes
        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }
        public IReadOnlyList<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }
        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
