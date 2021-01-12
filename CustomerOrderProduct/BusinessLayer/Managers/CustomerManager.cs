using BusinessLayer.Exceptions;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Customer GetCustomerWithOrders(int id)
        {
            return _customers.GetCustomerWithOrders(id);
        }

        public void AddCustomer(Customer customer)
        {
            if(GetAllCustomers().Where(x => x.Name == customer.Name && x.Address == customer.Address).Count() > 0)
                throw new CustomerManagerException("CustomerManager - combination name and address already exists");
            if (customer == null) throw new CustomerManagerException("CustomerManager - customer is null");
            _customers.AddCustomer(customer);
        }

        public void RemoveCustomer(int id)
        {
            if (id <= 0) throw new CustomerManagerException("CustomerManager - invalid id");
            if (GetCustomer(id) == null) throw new CustomerManagerException("CustomerManager - customer doesn't exist");
            if(GetCustomerWithOrders(id).GetOrders().Count > 0) throw new CustomerManagerException("CustomerManager - customer has orders!");
            _customers.RemoveCustomer(id);
        }
        #endregion Methodes
    }
}