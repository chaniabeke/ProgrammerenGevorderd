using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataLayer.DataAccessObjects
{
    public class CustomerDAO
    {
        #region Fields

        private readonly string connectionString;

        #endregion Fields

        #region Constructors

        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion Constructors

        #region Methodes

        public Customer GetCustomerDAO(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Customer> GetAllCustomersDAO()
        {
            throw new NotImplementedException();
        }

        public void AddCustomerDAO(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomerDAO(Customer customer)
        {
            throw new NotImplementedException();
        }

        #endregion Methodes
    }
}