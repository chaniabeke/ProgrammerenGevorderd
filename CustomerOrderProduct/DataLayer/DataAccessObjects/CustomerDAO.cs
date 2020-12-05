using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.DataAccessObjects
{
    public class CustomerDAO
    {
        #region Fields
        private readonly string connectionString;
        #endregion

        #region Constructors
        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        #region Methodes
        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
        public IReadOnlyList<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        public void RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
