using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Managers
{
    public class CustomerManager : ICustomerRepository
    {
        #region Fields
        private readonly ICustomerRepository _customers;
        #endregion

        #region Constructors
        public CustomerManager(ICustomerRepository customers) => _customers = customers; 
        #endregion

        #region Methodes

        public Customer GetCustomer(int id)
        {
           return _customers.GetCustomer(id);
        }

        //public IReadOnlyList<Customer> GetCustomers(Func<Customer, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        public Customer GetCustomerWithOrders(int id)
        {
           return _customers.GetCustomerWithOrders(id);
        }

        public IReadOnlyList<Customer> GetAllCustomers()
        {
            return _customers.GetAllCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            _customers.AddCustomer(customer);
        }

        public void RemoveCustomer(int id)
        {
            _customers.RemoveCustomer(id);
        }
        #endregion Methodes
    }
}