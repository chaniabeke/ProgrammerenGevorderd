using BusinessLayer.Exceptions;
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
           if (id <= 0) throw new CustomerManagerException("CustomerManager - invalid id");
           return _customers.GetCustomer(id);
        }

        public IReadOnlyList<Customer> GetAllCustomers()
        {
            return _customers.GetAllCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            //TODO MANAGER exception if name & address combo exist => exception
            if(customer == null) throw new CustomerManagerException("CustomerManager - customer is null");
            _customers.AddCustomer(customer);
        }

        public void RemoveCustomer(int id)
        {
            if (id <= 0) throw new CustomerManagerException("CustomerManager - invalid id");
            if (GetCustomer(id) == null) throw new CustomerManagerException("CustomerManager - customer doesn't exist");
            if(GetCustomer(id).GetOrders().Count != 0) throw new CustomerManagerException("CustomerManager - customer has orders!");
            _customers.RemoveCustomer(id);
        }
        #endregion Methodes
    }
}