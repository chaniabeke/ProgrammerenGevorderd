using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using DataLayer.Tools;

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

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Customer> GetAllCustomers()
        {
             throw new NotImplementedException();
        }

        public IReadOnlyList<Customer> GetCustomers(Func<Customer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        #endregion Methodes
    }
}